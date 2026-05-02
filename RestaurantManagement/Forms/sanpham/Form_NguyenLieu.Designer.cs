using System.ComponentModel;
using System.Windows.Forms;

namespace RestaurantManagement.sanpham
{
    partial class Form_NguyenLieu
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
            txtTenNL = new TextBox();
            cboDVT = new ComboBox();
            btnThem = new Button();
            btnKiemTraHSD = new Button();
            btnLamMoi = new Button();
            dgvNguyenLieu = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvNguyenLieu).BeginInit();
            SuspendLayout();

            // txtTimKiem
            txtTimKiem.Location = new System.Drawing.Point(12, 20);
            txtTimKiem.Size = new System.Drawing.Size(200, 27);
            txtTimKiem.Name = "txtTimKiem";

            // btnTimKiem
            btnTimKiem.Location = new System.Drawing.Point(220, 18);
            btnTimKiem.Size = new System.Drawing.Size(120, 30);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Click += btnTimKiem_Click;

            // txtTenNL
            txtTenNL.Location = new System.Drawing.Point(12, 65);
            txtTenNL.Size = new System.Drawing.Size(200, 27);
            txtTenNL.Name = "txtTenNL";

            // cboDVT
            cboDVT.Location = new System.Drawing.Point(220, 63);
            cboDVT.Size = new System.Drawing.Size(120, 27);
            cboDVT.Name = "cboDVT";
            cboDVT.DropDownStyle = ComboBoxStyle.DropDownList;

            // btnThem
            btnThem.Location = new System.Drawing.Point(350, 63);
            btnThem.Size = new System.Drawing.Size(150, 30);
            btnThem.Text = "Thêm nguyên liệu";
            btnThem.Name = "btnThem";
            btnThem.Click += btnThem_Click;

            // btnKiemTraHSD
            btnKiemTraHSD.Location = new System.Drawing.Point(510, 63);
            btnKiemTraHSD.Size = new System.Drawing.Size(170, 30);
            btnKiemTraHSD.Text = "Kiểm tra hạn sử dụng";
            btnKiemTraHSD.Name = "btnKiemTraHSD";
            btnKiemTraHSD.Click += btnKiemTraHSD_Click;

            // btnLamMoi
            btnLamMoi.Location = new System.Drawing.Point(690, 63);
            btnLamMoi.Size = new System.Drawing.Size(90, 30);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Click += btnLamMoi_Click;

            // dgvNguyenLieu
            dgvNguyenLieu.Location = new System.Drawing.Point(12, 110);
            dgvNguyenLieu.Size = new System.Drawing.Size(776, 400);
            dgvNguyenLieu.Name = "dgvNguyenLieu";
            dgvNguyenLieu.CellClick += dgvNguyenLieu_CellClick;

            // Form
            ClientSize = new System.Drawing.Size(800, 540);
            Text = "Quản lý Nguyên liệu";
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTenNL);
            Controls.Add(cboDVT);
            Controls.Add(btnThem);
            Controls.Add(btnKiemTraHSD);
            Controls.Add(btnLamMoi);
            Controls.Add(dgvNguyenLieu);
            Load += Form_NguyenLieu_Load;

            ((System.ComponentModel.ISupportInitialize)dgvNguyenLieu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private TextBox txtTenNL;
        private ComboBox cboDVT;
        private Button btnThem;
        private Button btnKiemTraHSD;
        private Button btnLamMoi;
        private DataGridView dgvNguyenLieu;
    }
}