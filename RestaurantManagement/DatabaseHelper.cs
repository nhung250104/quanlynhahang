using Microsoft.Data.SqlClient;

public class DatabaseHelper
{
    private static readonly string ConnectionString =
        "Server=DESKTOP-JF58Q6V\\SQL2025;Database=QuanLyCuaHang;Integrated Security=True;" +
        "TrustServerCertificate=True;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}