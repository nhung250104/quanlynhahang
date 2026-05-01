using Microsoft.Data.SqlClient;
using System.Data;

public class HoaDonDAL
{
    // Lấy danh sách hóa đơn kèm tên nhân viên
    public DataTable GetAll()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            @"SELECT hd.MaHD, nv.TenNV,
                     CONVERT(VARCHAR,hd.NgayBan,103) AS NgayBan,
                     hd.GioVao, hd.GioRa,
                     FORMAT(hd.TongTienHang,'N0') + N' đ' AS TongTienHang,
                     FORMAT(hd.ChietKhau,'N0')    + N' đ' AS ChietKhau,
                     FORMAT(hd.TongThanhToan,'N0') + N' đ' AS TongThanhToan
              FROM HOADON hd
              JOIN NHANVIEN nv ON hd.MaNV = nv.MaNV
              ORDER BY hd.NgayBan DESC", conn);
        da.Fill(dt);
        return dt;
    }

    // Tìm kiếm theo mã HD hoặc khoảng ngày
    public DataTable Search(string maHD, DateTime? tuNgay, DateTime? denNgay)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var sql = @"SELECT hd.MaHD, nv.TenNV,
                           CONVERT(VARCHAR,hd.NgayBan,103) AS NgayBan,
                           FORMAT(hd.TongThanhToan,'N0') + N' đ' AS TongThanhToan
                    FROM HOADON hd
                    JOIN NHANVIEN nv ON hd.MaNV = nv.MaNV
                    WHERE (@MaHD IS NULL OR hd.MaHD LIKE @MaHD)
                      AND (@TuNgay IS NULL OR hd.NgayBan >= @TuNgay)
                      AND (@DenNgay IS NULL OR hd.NgayBan <= @DenNgay)
                    ORDER BY hd.NgayBan DESC";
        var da = new SqlDataAdapter(sql, conn);
        da.SelectCommand.Parameters.AddWithValue("@MaHD",
            string.IsNullOrWhiteSpace(maHD) ? (object)DBNull.Value : "%" + maHD + "%");
        da.SelectCommand.Parameters.AddWithValue("@TuNgay",
            tuNgay.HasValue ? (object)tuNgay.Value : DBNull.Value);
        da.SelectCommand.Parameters.AddWithValue("@DenNgay",
            denNgay.HasValue ? (object)denNgay.Value : DBNull.Value);
        da.Fill(dt);
        return dt;
    }

    // Tạo hóa đơn mới — sinh mã tự động
    public string TaoHoaDon(string maNV)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();

        // Sinh mã HD theo pattern HD + 7 số như trong dump data
        var cmdMa = new SqlCommand(
            @"SELECT 'HD' + RIGHT('0000000' +
              CAST(ISNULL(MAX(CAST(RIGHT(MaHD,7) AS INT)),0) + 1 AS VARCHAR(7)), 7)
              FROM HOADON", conn);
        string maHD = cmdMa.ExecuteScalar()?.ToString() ?? "HD0000001";

        var cmd = new SqlCommand(
            @"INSERT INTO HOADON (MaHD, MaNV, NgayBan, GioVao, TongTienHang, ChietKhau, TongThanhToan)
              VALUES (@MaHD, @MaNV, CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME), 0, 0, 0)", conn);
        cmd.Parameters.AddWithValue("@MaHD", maHD);
        cmd.Parameters.AddWithValue("@MaNV", maNV);
        cmd.ExecuteNonQuery();
        return maHD;
    }

    // Cập nhật tổng tiền sau khi thêm/xóa chi tiết
    public void CapNhatTongTien(string maHD, decimal chietKhau = 0)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand(
            @"UPDATE HOADON
              SET TongTienHang  = (SELECT ISNULL(SUM(ThanhTien),0) FROM CTHOADON WHERE MaHD = @MaHD),
                  ChietKhau     = @ChietKhau,
                  TongThanhToan = (SELECT ISNULL(SUM(ThanhTien),0) FROM CTHOADON WHERE MaHD = @MaHD) - @ChietKhau,
                  GioRa         = CAST(GETDATE() AS TIME)
              WHERE MaHD = @MaHD", conn);
        cmd.Parameters.AddWithValue("@MaHD", maHD);
        cmd.Parameters.AddWithValue("@ChietKhau", chietKhau);
        cmd.ExecuteNonQuery();
    }

    // Báo cáo tài chính — gọi SP_BaoCaoTaiChinh có sẵn
    public DataTable BaoCaoTaiChinh(DateTime tuNgay, DateTime denNgay)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand("SP_BaoCaoTaiChinh", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
        cmd.Parameters.AddWithValue("@DenNgay", denNgay.Date);
        new SqlDataAdapter(cmd).Fill(dt);
        return dt;
    }
}