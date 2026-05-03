using Microsoft.Data.SqlClient;
using System.Data;

public class DatabaseHelper
{
    private static string _connectionString =
        "Server=LAPTOP-CP90VKG7;Database=QuanLyCuaHang;Trusted_Connection=True;TrustServerCertificate=True;";

    public static string CurrentRole { get; private set; }

    /* =====================================================
       LOGIN (GIỮ NGUYÊN CODE CỦA BẠN)
    ===================================================== */
    public static bool Login(string username, string password)
    {
        try
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT Role
                FROM NGUOIDUNG
                WHERE Username = @u AND Password = @p";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            var result = cmd.ExecuteScalar();

            if (result != null)
            {
                CurrentRole = result.ToString();
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }

    /* =====================================================
       🔹 THÊM NCC (GỌI STORE PROCEDURE)
    ===================================================== */
    public static bool ThemNhaCungCap(string ten, string sdt, string diachi)
    {
        try
        {
            using var conn = GetConnection();
            conn.Open();

            using var cmd = new SqlCommand("SP_THEM_NHACUNGCAP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TenNCC", ten);
            cmd.Parameters.AddWithValue("@SDTNCC", sdt);
            cmd.Parameters.AddWithValue("@DiaChiNCC", diachi);

            cmd.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /* =====================================================
       🔹 LOAD NCC (USER - ĐÃ CHE)
    ===================================================== */
    public static DataTable GetNhaCungCap()
    {
        using var conn = GetConnection();
        conn.Open();

        using var cmd = new SqlCommand("SP_GET_NHACUNGCAP", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        using var da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    /* =====================================================
       🔹 SEARCH NCC
    ===================================================== */
    public static DataTable TimNhaCungCap(string keyword)
    {
        using var conn = GetConnection();
        conn.Open();

        using var cmd = new SqlCommand("SP_TIM_NHACUNGCAP", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Keyword", keyword);

        using var da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    /* =====================================================
       🔹 ADMIN XEM DỮ LIỆU THẬT (GIẢI MÃ)
    ===================================================== */
    public static DataTable GetNhaCungCapFull()
    {
        using var conn = GetConnection();
        conn.Open();

        using var cmd = new SqlCommand("SP_GET_NHACUNGCAP_FULL", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        using var da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }
}