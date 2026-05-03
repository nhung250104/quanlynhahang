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

            // Hiện form đăng nhập trước
            var loginForm = new Form_Login();
            if (loginForm.ShowDialog() != DialogResult.OK)
                return; // Đóng app nếu không đăng nhập thành công

            // Mở menu chính
            Application.Run(new Form_Main());
        }
    }
}