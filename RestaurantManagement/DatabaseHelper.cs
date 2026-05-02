using Microsoft.Data.SqlClient;

public class DatabaseHelper
{
    private static readonly string ConnectionString =
        "Server=LAPTOP-CP90VKG7;" +
        "Database=QuanLyCuaHang;" +
        "Integrated Security=True;" +
        "TrustServerCertificate=True;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}