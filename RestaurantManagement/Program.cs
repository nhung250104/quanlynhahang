using System;
using System.Windows.Forms;

namespace RestaurantManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Test kết nối trước khi mở hệ thống
            if (!TestKetNoi()) return; // nếu lỗi DB thì không mở

            // Mở menu chính
            Application.Run(new Form_Main());
        }

        static bool TestKetNoi()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                return true; // kết nối OK → mở hệ thống
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ KHÔNG THỂ KẾT NỐI DATABASE!\n\n{ex.Message}\n\n" +
                    "Kiểm tra lại:\n" +
                    "1. SQL Server đang chạy chưa?\n" +
                    "2. Tên Server trong DatabaseHelper.cs có đúng không?\n" +
                    "3. Tên Database 'QuanLyCuaHang' có đúng không?",
                    "Lỗi kết nối DB",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
    }
}