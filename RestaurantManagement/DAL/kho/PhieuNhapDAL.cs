using Microsoft.Data.SqlClient;
using System.Data;

public class PhieuNhapDAL
{
    public DataTable GetAll()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            @"SELECT pn.MaPN, ncc.TenNCC,
                     CONVERT(VARCHAR, pn.NgayNK, 103)             AS NgayNK,
                     CONVERT(VARCHAR, pn.ThoiHanThanhToan, 103)   AS ThoiHanTT,
                     pn.VAT,
                     FORMAT(pn.TamTinh,  'N0') + N' đ'            AS TamTinh,
                     FORMAT(pn.TongTien, 'N0') + N' đ'            AS TongTien,
                     ISNULL(pn.GhiChu, '')                        AS GhiChu
              FROM PHIEUNHAP pn
              JOIN NHACUNGCAP ncc ON pn.MaNCC = ncc.MaNCC
              ORDER BY pn.NgayNK DESC", conn);
        da.Fill(dt);
        return dt;
    }

    public DataTable Search(string maPN, string maNCC,
                            DateTime? tuNgay, DateTime? denNgay)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var sql =
            @"SELECT pn.MaPN, ncc.TenNCC,
                     CONVERT(VARCHAR, pn.NgayNK, 103)           AS NgayNK,
                     FORMAT(pn.TongTien,'N0') + N' đ'           AS TongTien,
                     ISNULL(pn.GhiChu,'')                       AS GhiChu
              FROM PHIEUNHAP pn
              JOIN NHACUNGCAP ncc ON pn.MaNCC = ncc.MaNCC
              WHERE (@MaPN  IS NULL OR pn.MaPN  LIKE @MaPN)
                AND (@MaNCC IS NULL OR pn.MaNCC = @MaNCC)
                AND (@TuNgay  IS NULL OR pn.NgayNK >= @TuNgay)
                AND (@DenNgay IS NULL OR pn.NgayNK <= @DenNgay)
              ORDER BY pn.NgayNK DESC";
        var da = new SqlDataAdapter(sql, conn);
        da.SelectCommand.Parameters.AddWithValue("@MaPN",
            string.IsNullOrWhiteSpace(maPN) ? (object)DBNull.Value : "%" + maPN + "%");
        da.SelectCommand.Parameters.AddWithValue("@MaNCC",
            string.IsNullOrWhiteSpace(maNCC) ? (object)DBNull.Value : maNCC);
        da.SelectCommand.Parameters.AddWithValue("@TuNgay",
            tuNgay.HasValue ? (object)tuNgay.Value : DBNull.Value);
        da.SelectCommand.Parameters.AddWithValue("@DenNgay",
            denNgay.HasValue ? (object)denNgay.Value : DBNull.Value);
        da.Fill(dt);
        return dt;
    }

    // Tạo phiếu nhập mới — sinh mã tự động
    public string TaoPhieuNhap(string maNCC, decimal vat, string ghiChu,
                               DateTime thoiHanTT)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();

        // Sinh mã PN theo pattern có trong DB
        var cmdMa = new SqlCommand(
            @"SELECT 'PN' + RIGHT('0000000' +
              CAST(ISNULL(MAX(CAST(RIGHT(MaPN,7) AS BIGINT)),0)+1 AS VARCHAR(7)),7)
              FROM PHIEUNHAP
              WHERE ISNUMERIC(RIGHT(MaPN,7))=1", conn);
        string maPN = cmdMa.ExecuteScalar()?.ToString() ?? "PN0000001";

        var cmd = new SqlCommand(
            @"INSERT INTO PHIEUNHAP
                (MaPN, MaNCC, NgayNK, ThoiHanThanhToan, VAT, TamTinh, TongTien, GhiChu)
              VALUES
                (@MaPN, @MaNCC, CAST(GETDATE() AS DATE),
                 @ThoiHanTT, @VAT, 0, 0, @GhiChu)", conn);
        cmd.Parameters.AddWithValue("@MaPN", maPN);
        cmd.Parameters.AddWithValue("@MaNCC", maNCC);
        cmd.Parameters.AddWithValue("@ThoiHanTT", thoiHanTT.Date);
        cmd.Parameters.AddWithValue("@VAT", vat);
        cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
        cmd.ExecuteNonQuery();
        return maPN;
    }

    // Cập nhật TamTinh / TongTien sau khi thêm/xóa CTPN
    public void CapNhatTongTien(string maPN)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand(
            @"UPDATE pn
              SET pn.TamTinh  = ct.TongTT,
                  pn.TongTien = ct.TongTT + (ct.TongTT * ISNULL(pn.VAT,0) / 100.0)
              FROM PHIEUNHAP pn
              JOIN (
                  SELECT MaPN, ISNULL(SUM(ThanhTien),0) AS TongTT
                  FROM CTPHIEUNHAP WHERE MaPN=@MaPN
                  GROUP BY MaPN
              ) ct ON pn.MaPN = ct.MaPN
              WHERE pn.MaPN=@MaPN", conn);
        cmd.Parameters.AddWithValue("@MaPN", maPN);
        cmd.ExecuteNonQuery();
    }

    // So sánh giá nguyên liệu giữa các NCC — gọi SP_SSGIA_NGUYENLIEU
    public DataTable SoSanhGia(string maNL = null, string maNCC = null,
                               DateTime? tuNgay = null, DateTime? denNgay = null)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand("SP_SSGIA_NGUYENLIEU", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MaNguyenLieu",
            string.IsNullOrWhiteSpace(maNL) ? (object)DBNull.Value : maNL);
        cmd.Parameters.AddWithValue("@MaNCC",
            string.IsNullOrWhiteSpace(maNCC) ? (object)DBNull.Value : maNCC);
        cmd.Parameters.AddWithValue("@NgayBatDau",
            tuNgay.HasValue ? (object)tuNgay.Value : DBNull.Value);
        cmd.Parameters.AddWithValue("@NgayKetThuc",
            denNgay.HasValue ? (object)denNgay.Value : DBNull.Value);
        new SqlDataAdapter(cmd).Fill(dt);
        return dt;
    }
}