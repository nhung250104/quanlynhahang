using System.ComponentModel;
using System.Windows.Forms;

namespace RestaurantManagement.Forms.sanpham
{
    partial class Form_SanPham
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            txtTenSP = new TextBox();
            btnThem = new Button();
            btnLamMoi = new Button();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            btnTopBanChay = new Button();
            dgvSanPham = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();

            // txtTimKiem
            txtTimKiem.Location = new System.Drawing.Point(12, 20);
            txtTimKiem.Size = new System.Drawing.Size(200, 27);
            txtTimKiem.Name = "txtTimKiem";

            // btnTimKiem
            btnTimKiem.Location = new System.Drawing.Point(220, 18);
            btnTimKiem.Size = new System.Drawing.Size(100, 30);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Click += btnTimKiem_Click;

            // txtTenSP
            txtTenSP.Location = new System.Drawing.Point(12, 65);
            txtTenSP.Size = new System.Drawing.Size(200, 27);
            txtTenSP.Name = "txtTenSP";

            // btnThem
            btnThem.Location = new System.Drawing.Point(220, 63);
            btnThem.Size = new System.Drawing.Size(140, 30);
            btnThem.Text = "Thêm sản phẩm";
            btnThem.Name = "btnThem";
            btnThem.Click += btnThem_Click;

            // btnLamMoi
            btnLamMoi.Location = new System.Drawing.Point(370, 63);
            btnLamMoi.Size = new System.Drawing.Size(90, 30);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Click += btnLamMoi_Click;

            // dtpTuNgay
            dtpTuNgay.Location = new System.Drawing.Point(12, 110);
            dtpTuNgay.Size = new System.Drawing.Size(160, 27);
            dtpTuNgay.Name = "dtpTuNgay";

            // dtpDenNgay
            dtpDenNgay.Location = new System.Drawing.Point(180, 110);
            dtpDenNgay.Size = new System.Drawing.Size(160, 27);
            dtpDenNgay.Name = "dtpDenNgay";

            // btnTopBanChay
            btnTopBanChay.Location = new System.Drawing.Point(350, 108);
            btnTopBanChay.Size = new System.Drawing.Size(120, 30);
            btnTopBanChay.Text = "Top bán chạy";
            btnTopBanChay.Name = "btnTopBanChay";
            btnTopBanChay.Click += btnTopBanChay_Click;

            // dgvSanPham
            dgvSanPham.Location = new System.Drawing.Point(12, 155);
            dgvSanPham.Size = new System.Drawing.Size(760, 400);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.CellClick += dgvSanPham_CellClick;

            // Form
            ClientSize = new System.Drawing.Size(800, 590);
            Text = "Quản lý Sản phẩm";
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTenSP);
            Controls.Add(btnThem);
            Controls.Add(btnLamMoi);
            Controls.Add(dtpTuNgay);
            Controls.Add(dtpDenNgay);
            Controls.Add(btnTopBanChay);
            Controls.Add(dgvSanPham);
            Load += Form_SanPham_Load;

            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private TextBox txtTenSP;
        private Button btnThem;
        private Button btnLamMoi;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnTopBanChay;
        private DataGridView dgvSanPham;
    }
}