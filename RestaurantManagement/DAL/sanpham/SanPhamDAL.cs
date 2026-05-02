using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Data;
public class SanPhamDAL
{
    public DataTable GetAll()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            "SELECT MaSP, TenSP FROM SANPHAM ORDER BY MaSP", conn);
        da.Fill(dt);
        return dt;
    }

    public DataTable Search(string keyword)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            "SELECT MaSP, TenSP FROM SANPHAM WHERE TenSP LIKE @KW ORDER BY MaSP", conn);
        da.SelectCommand.Parameters.AddWithValue("@KW", "%" + keyword + "%");
        da.Fill(dt);
        return dt;
    }

    public void Insert(string tenSP)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand("SP_ThemSanPham", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TenSP", tenSP);
        cmd.ExecuteNonQuery();
    }

    public DataTable GetTopBanChay(DateTime tuNgay, DateTime denNgay)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand("SP_TopSanPhamBanChay", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
        cmd.Parameters.AddWithValue("@DenNgay", denNgay.Date);
        var da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        return dt;
    }
}