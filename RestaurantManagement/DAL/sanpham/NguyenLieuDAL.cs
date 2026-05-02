using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Data;
public class NguyenLieuDAL
{
    public DataTable GetAll()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            "SELECT MaNguyenLieu, TenNguyenLieu, DVT FROM NGUYENLIEU ORDER BY MaNguyenLieu", conn);
        da.Fill(dt);
        return dt;
    }

    public DataTable Search(string keyword)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            "SELECT MaNguyenLieu, TenNguyenLieu, DVT FROM NGUYENLIEU WHERE TenNguyenLieu LIKE @KW ORDER BY MaNguyenLieu", conn);
        da.SelectCommand.Parameters.AddWithValue("@KW", "%" + keyword + "%");
        da.Fill(dt);
        return dt;
    }

    public void Insert(string tenNguyenLieu, string dvt)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand("SP_THEM_NGUYENLIEU", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TenNguyenLieu", tenNguyenLieu);
        cmd.Parameters.AddWithValue("@DVT", dvt);
        cmd.ExecuteNonQuery();
    }

    public DataTable KiemTraHanSuDung()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand("SP_KIEMTRA_HANSUDUNG", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        var da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        return dt;
    }
}