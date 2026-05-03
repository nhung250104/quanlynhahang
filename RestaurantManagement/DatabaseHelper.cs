using Microsoft.Data.SqlClient;

public class DatabaseHelper
{
    private static string _connectionString;
    public static string CurrentRole { get; private set; }

    public static bool Login(string username, string password)
    {
        _connectionString =
            $"Server=DESKTOP-JF58Q6V\\SQL2025;Database=QuanLyCuaHang;" +
            $"User Id={username};Password={password};TrustServerCertificate=True;";

        try
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            // Xác định role dựa theo username
            if (username == "ChuCuaHang")
                CurrentRole = "CCH";
            else if (username == "NhanVien")
                CurrentRole = "NV";
            else
                CurrentRole = "OTHER";

            return true;
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
}