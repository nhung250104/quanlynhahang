using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Data;
public class BangGiaDAL
{
    public DataTable GetAll()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(@"
            SELECT b.MaGia, s.TenSP, b.DonGiaBan, b.NgayBD, b.NgayKT,
                   CASE WHEN b.NgayKT IS NULL THEN N'Đang áp dụng' ELSE N'Hết hiệu lực' END AS TrangThai
            FROM BANGGIA b
            JOIN SANPHAM s ON s.MaSP = b.MaSP
            ORDER BY b.NgayBD DESC", conn);
        da.Fill(dt);
        return dt;
    }

    public DataTable GetSanPham()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter("SELECT MaSP, TenSP FROM SANPHAM ORDER BY TenSP", conn);
        da.Fill(dt);
        return dt;
    }

    public void ThemGiaMoi(string maSP, decimal donGia, DateTime ngayBD)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand("SP_THEM_GIAMOI", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MaSP", maSP);
        cmd.Parameters.AddWithValue("@DonGiaBan", donGia);
        cmd.Parameters.AddWithValue("@NgayBD", ngayBD.Date);
        cmd.ExecuteNonQuery();
    }

    public void CapNhatNgayKetThuc(string maSP, DateTime ngayKT)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand("SP_CAPNHAT_NGAYKETTHUC_GIACU", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MaSP", maSP);
        cmd.Parameters.AddWithValue("@NgayKT", ngayKT.Date);
        cmd.ExecuteNonQuery();
    }

    public DataTable BaoCaoTaiChinh(DateTime tuNgay, DateTime denNgay)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand("SP_BaoCaoTaiChinh", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
        cmd.Parameters.AddWithValue("@DenNgay", denNgay.Date);
        var da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        return dt;
    }
}