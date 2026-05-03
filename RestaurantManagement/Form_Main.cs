using System;
using System.Windows.Forms;
using RestaurantManagement.banhang;
using RestaurantManagement.sanpham;

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
            PhanQuyenGiaoDien();
        }

        private void PhanQuyenGiaoDien()
        {
            if (DatabaseHelper.CurrentRole == "NV")
            {
                btnNhanVien.Visible = false;
                btnBangGia.Visible  = false;

                // BÁN HÀNG
                btnHoaDon.Location = new System.Drawing.Point(80, 113);

                // KHO
                btnNhaCungCap.Location = new System.Drawing.Point(80, 210);
                btnPhieuNhap.Location  = new System.Drawing.Point(80, 265);

                // SẢN PHẨM
                btnSanPham.Location    = new System.Drawing.Point(120, 340);
                btnNguyenLieu.Location = new System.Drawing.Point(285, 340);

                // THOÁT
                btnThoat.Location = new System.Drawing.Point(190, 400);
                this.Size = new System.Drawing.Size(540, 480);

                // Dịch labels
                foreach (System.Windows.Forms.Control c in this.Controls)
                {
                    if (c is System.Windows.Forms.Label lbl)
                    {
                        if (lbl.Text.Contains("KHO"))
                            lbl.Location = new System.Drawing.Point(30, 175);
                        if (lbl.Text.Contains("SẢN PHẨM"))
                            lbl.Location = new System.Drawing.Point(30, 310);
                    }
                }

                // Resize form vừa đủ chứa tất cả
                this.Size = new System.Drawing.Size(540, 460);
            }
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