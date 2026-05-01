using Microsoft.Data.SqlClient;
using System.Data;

public class NhanVienDAL
{
    public DataTable GetAll()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            "SELECT MaNV, TenNV FROM NHANVIEN ORDER BY MaNV", conn);
        da.Fill(dt);
        return dt;
    }

    public DataTable Search(string keyword)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            "SELECT MaNV, TenNV FROM NHANVIEN WHERE TenNV LIKE @KW ORDER BY MaNV", conn);
        da.SelectCommand.Parameters.AddWithValue("@KW", "%" + keyword + "%");
        da.Fill(dt);
        return dt;
    }

    // Thêm nhân viên — sinh mã tự động qua sp_TaoMaNhanVienMoi
    public void Insert(string tenNV)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();

        // Bước 1: Gọi SP sinh mã
        var cmdMa = new SqlCommand("sp_TaoMaNhanVienMoi", conn);
        cmdMa.CommandType = CommandType.StoredProcedure;
        var pMa = new SqlParameter("@MANVMOI", SqlDbType.VarChar, 10)
        {
            Direction = ParameterDirection.Output
        };
        cmdMa.Parameters.Add(pMa);
        cmdMa.ExecuteNonQuery();
        string maNV = pMa.Value?.ToString();

        // Bước 2: Insert
        var cmd = new SqlCommand(
            "INSERT INTO NHANVIEN (MaNV, TenNV) VALUES (@MaNV, @TenNV)", conn);
        cmd.Parameters.AddWithValue("@MaNV", maNV);
        cmd.Parameters.AddWithValue("@TenNV", tenNV);
        cmd.ExecuteNonQuery();
    }

    public bool Update(string maNV, string tenNV)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand(
            "UPDATE NHANVIEN SET TenNV=@TenNV WHERE MaNV=@MaNV", conn);
        cmd.Parameters.AddWithValue("@TenNV", tenNV);
        cmd.Parameters.AddWithValue("@MaNV", maNV);
        return cmd.ExecuteNonQuery() > 0;
    }

    public bool Delete(string maNV)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand(
            "DELETE FROM NHANVIEN WHERE MaNV=@MaNV", conn);
        cmd.Parameters.AddWithValue("@MaNV", maNV);
        return cmd.ExecuteNonQuery() > 0;
    }
}