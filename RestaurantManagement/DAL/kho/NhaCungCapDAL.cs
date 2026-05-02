using Microsoft.Data.SqlClient;
using System.Data;

public class NhaCungCapDAL
{
    public DataTable GetAll()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            @"SELECT MaNCC, TenNCC, DiaChiNCC, SDTNCC
              FROM NHACUNGCAP
              ORDER BY MaNCC", conn);
        da.Fill(dt);
        return dt;
    }

    public DataTable Search(string keyword)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            @"SELECT MaNCC, TenNCC, DiaChiNCC, SDTNCC
              FROM NHACUNGCAP
              WHERE TenNCC LIKE @KW OR SDTNCC LIKE @KW
              ORDER BY MaNCC", conn);
        da.SelectCommand.Parameters.AddWithValue("@KW", "%" + keyword + "%");
        da.Fill(dt);
        return dt;
    }

    // Thêm NCC — gọi SP_THEM_NHACUNGCAP có sẵn
    // SP tự validate SĐT: phải bắt đầu số, dài 10-12 ký tự
    public void Insert(string tenNCC, string sdt, string diaChi)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand("SP_THEM_NHACUNGCAP", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
        cmd.Parameters.AddWithValue("@SDTNCC", sdt);
        cmd.Parameters.AddWithValue("@DiaChiNCC", diaChi);
        cmd.ExecuteNonQuery();
    }

    public bool Update(string maNCC, string tenNCC, string sdt, string diaChi)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand(
            @"UPDATE NHACUNGCAP
              SET TenNCC=@Ten, SDTNCC=@SDT, DiaChiNCC=@DiaChi
              WHERE MaNCC=@Ma", conn);
        cmd.Parameters.AddWithValue("@Ten", tenNCC);
        cmd.Parameters.AddWithValue("@SDT", sdt);
        cmd.Parameters.AddWithValue("@DiaChi", diaChi);
        cmd.Parameters.AddWithValue("@Ma", maNCC);
        return cmd.ExecuteNonQuery() > 0;
    }

    public bool Delete(string maNCC)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand(
            "DELETE FROM NHACUNGCAP WHERE MaNCC=@Ma", conn);
        cmd.Parameters.AddWithValue("@Ma", maNCC);
        return cmd.ExecuteNonQuery() > 0;
    }

    // Load ComboBox cho Form_PhieuNhap
    public DataTable GetForComboBox()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            "SELECT MaNCC, TenNCC FROM NHACUNGCAP ORDER BY TenNCC", conn);
        da.Fill(dt);
        return dt;
    }
}