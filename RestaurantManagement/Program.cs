using System;
using System.Windows.Forms;
using RestaurantManagement.Forms.sanpham;

namespace RestaurantManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TestKetNoi();

            Application.Run(new Form_SanPham());
        }

        static void TestKetNoi()
        {
            var ketQua = new System.Text.StringBuilder();
            int thanhCong = 0;
            int thatBai   = 0;

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                ketQua.AppendLine("✅ KẾT NỐI DB: THÀNH CÔNG");
                ketQua.AppendLine($"   Server  : {conn.DataSource}");
                ketQua.AppendLine($"   Database: {conn.Database}");
                ketQua.AppendLine();
                thanhCong++;
            }
            catch (Exception ex)
            {
                ketQua.AppendLine("❌ KẾT NỐI DB: THẤT BẠI");
                ketQua.AppendLine($"   Lỗi: {ex.Message}");
                ketQua.AppendLine();
                thatBai++;
            }

            ketQua.AppendLine("─── LUỒNG 1: BÁN HÀNG ───");
            TestBang("NHANVIEN",   ref thanhCong, ref thatBai, ketQua);
            TestBang("HOADON",     ref thanhCong, ref thatBai, ketQua);
            TestBang("CTHOADON",   ref thanhCong, ref thatBai, ketQua);
            ketQua.AppendLine();

            ketQua.AppendLine("─── LUỒNG 2: KHO ───");
            TestBang("NHACUNGCAP",  ref thanhCong, ref thatBai, ketQua);
            TestBang("PHIEUNHAP",   ref thanhCong, ref thatBai, ketQua);
            TestBang("CTPHIEUNHAP", ref thanhCong, ref thatBai, ketQua);
            ketQua.AppendLine();

            ketQua.AppendLine("─── LUỒNG 3: SẢN PHẨM / NGUYÊN LIỆU / GIÁ ───");
            TestBang("SANPHAM",    ref thanhCong, ref thatBai, ketQua);
            TestBang("NGUYENLIEU", ref thanhCong, ref thatBai, ketQua);
            TestBang("CTSANPHAM",  ref thanhCong, ref thatBai, ketQua);
            TestBang("BANGGIA",    ref thanhCong, ref thatBai, ketQua);

            ketQua.AppendLine();
            ketQua.AppendLine($"══════════════════════════════");
            ketQua.AppendLine($"✅ Thành công: {thanhCong}/11");
            ketQua.AppendLine($"❌ Thất bại : {thatBai}/11");

            MessageBox.Show(
                ketQua.ToString(),
                thatBai == 0 ? "✅ TẤT CẢ KẾT NỐI THÀNH CÔNG" : "⚠️ CÓ LỖI KẾT NỐI",
                MessageBoxButtons.OK,
                thatBai == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        static void TestBang(string tenBang, ref int thanhCong, ref int thatBai, System.Text.StringBuilder ketQua)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                    $"SELECT COUNT(*) FROM {tenBang}", conn);
                int count = (int)cmd.ExecuteScalar();
                ketQua.AppendLine($"✅ {tenBang,-15}: {count} bản ghi");
                thanhCong++;
            }
            catch (Exception ex)
            {
                ketQua.AppendLine($"❌ {tenBang,-15}: {ex.Message}");
                thatBai++;
            }
        }
    }
}