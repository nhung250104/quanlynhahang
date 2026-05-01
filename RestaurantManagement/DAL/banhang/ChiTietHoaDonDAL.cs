using Microsoft.Data.SqlClient;
using System.Data;

public class ChiTietHoaDonDAL
{
    // Lấy chi tiết của 1 hóa đơn
    public DataTable GetByHoaDon(string maHD)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            @"SELECT ct.MaSP, sp.TenSP, ct.SoLuong,
                     FORMAT(ct.ThanhTien,'N0') + N' đ' AS ThanhTien
              FROM CTHOADON ct
              JOIN SANPHAM sp ON sp.MaSP = ct.MaSP
              WHERE ct.MaHD = @MaHD", conn);
        da.SelectCommand.Parameters.AddWithValue("@MaHD", maHD);
        da.Fill(dt);
        return dt;
    }

    // Lấy danh sách sản phẩm + giá hiện hành để chọn khi bán
    public DataTable GetSanPhamCoGia()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            @"SELECT sp.MaSP, sp.TenSP,
                     bg.DonGiaBan,
                     FORMAT(bg.DonGiaBan,'N0') + N' đ' AS GiaHienThi
              FROM SANPHAM sp
              JOIN BANGGIA bg ON bg.MaSP = sp.MaSP
              WHERE bg.NgayKT IS NULL
              ORDER BY sp.TenSP", conn);
        da.Fill(dt);
        return dt;
    }

    // Thêm món vào hóa đơn
    public void ThemChiTiet(string maHD, string maSP, int soLuong, decimal donGia)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();

        // Nếu SP đã có trong HD thì cộng dồn số lượng
        var cmdCheck = new SqlCommand(
            "SELECT COUNT(1) FROM CTHOADON WHERE MaHD=@MaHD AND MaSP=@MaSP", conn);
        cmdCheck.Parameters.AddWithValue("@MaHD", maHD);
        cmdCheck.Parameters.AddWithValue("@MaSP", maSP);
        bool exists = (int)cmdCheck.ExecuteScalar() > 0;

        if (exists)
        {
            var cmdUpdate = new SqlCommand(
                @"UPDATE CTHOADON
                  SET SoLuong   = SoLuong + @SoLuong,
                      ThanhTien = (SoLuong + @SoLuong) * @DonGia
                  WHERE MaHD=@MaHD AND MaSP=@MaSP", conn);
            cmdUpdate.Parameters.AddWithValue("@SoLuong", soLuong);
            cmdUpdate.Parameters.AddWithValue("@DonGia", donGia);
            cmdUpdate.Parameters.AddWithValue("@MaHD", maHD);
            cmdUpdate.Parameters.AddWithValue("@MaSP", maSP);
            cmdUpdate.ExecuteNonQuery();
        }
        else
        {
            var cmd = new SqlCommand(
                @"INSERT INTO CTHOADON (MaHD, MaSP, SoLuong, ThanhTien)
                  VALUES (@MaHD, @MaSP, @SoLuong, @ThanhTien)", conn);
            cmd.Parameters.AddWithValue("@MaHD", maHD);
            cmd.Parameters.AddWithValue("@MaSP", maSP);
            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
            cmd.Parameters.AddWithValue("@ThanhTien", soLuong * donGia);
            cmd.ExecuteNonQuery();
        }
    }

    // Xóa 1 dòng chi tiết
    public bool XoaChiTiet(string maHD, string maSP)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand(
            "DELETE FROM CTHOADON WHERE MaHD=@MaHD AND MaSP=@MaSP", conn);
        cmd.Parameters.AddWithValue("@MaHD", maHD);
        cmd.Parameters.AddWithValue("@MaSP", maSP);
        return cmd.ExecuteNonQuery() > 0;
    }
}