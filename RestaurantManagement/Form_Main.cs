using System;
using System.Windows.Forms;
using RestaurantManagement.banhang;   // Form_NhanVien, Form_HoaDon
using RestaurantManagement;       // Form_NhaCungCap, Form_PhieuNhap
using RestaurantManagement.sanpham;   // Form_SanPham, Form_NguyenLieu, Form_BangGia

namespace RestaurantManagement
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            lblTieuDe.Text = "HỆ THỐNG QUẢN LÝ NHÀ HÀNG";
        }

        // ── LUỒNG 1: BÁN HÀNG ──
        private void btnNhanVien_Click(object sender, EventArgs e)
            => new Form_NhanVien().ShowDialog();

        private void btnHoaDon_Click(object sender, EventArgs e)
            => new Form_HoaDon().ShowDialog();

        // ── LUỒNG 2: KHO ──
        private void btnNhaCungCap_Click(object sender, EventArgs e)
            => new Form_NhaCungCap().ShowDialog();

        private void btnPhieuNhap_Click(object sender, EventArgs e)
            => new Form_PhieuNhap().ShowDialog();

        // ── LUỒNG 3: SẢN PHẨM / NGUYÊN LIỆU / GIÁ ──
        private void btnSanPham_Click(object sender, EventArgs e)
            => new Form_SanPham().ShowDialog();

        private void btnNguyenLieu_Click(object sender, EventArgs e)
            => new Form_NguyenLieu().ShowDialog();

        private void btnBangGia_Click(object sender, EventArgs e)
            => new Form_BangGia().ShowDialog();

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var cf = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cf == DialogResult.Yes)
                Application.Exit();
        }
    }
}