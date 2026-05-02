using System.ComponentModel;
using System.Windows.Forms;

namespace RestaurantManagement.Forms.sanpham
{
    partial class Form_BangGia
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cboSanPham = new ComboBox();
            txtDonGia = new TextBox();
            dtpNgayBD = new DateTimePicker();
            btnThemGia = new Button();
            cboSanPhamKT = new ComboBox();
            dtpNgayKT = new DateTimePicker();
            btnCapNhatNgayKT = new Button();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            btnBaoCao = new Button();
            btnLamMoi = new Button();
            dgvBangGia = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBangGia).BeginInit();
            SuspendLayout();

            // --- Nhóm 1: Thêm giá mới ---
            // Label vị trí sẽ do form tự render, chỉ cần đặt controls đúng chỗ

            // cboSanPham
            cboSanPham.Location = new System.Drawing.Point(12, 20);
            cboSanPham.Size = new System.Drawing.Size(200, 27);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.DropDownStyle = ComboBoxStyle.DropDownList;

            // txtDonGia
            txtDonGia.Location = new System.Drawing.Point(220, 20);
            txtDonGia.Size = new System.Drawing.Size(120, 27);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.PlaceholderText = "Đơn giá";

            // dtpNgayBD
            dtpNgayBD.Location = new System.Drawing.Point(350, 20);
            dtpNgayBD.Size = new System.Drawing.Size(160, 27);
            dtpNgayBD.Name = "dtpNgayBD";

            // btnThemGia
            btnThemGia.Location = new System.Drawing.Point(520, 18);
            btnThemGia.Size = new System.Drawing.Size(120, 30);
            btnThemGia.Text = "Thêm giá mới";
            btnThemGia.Name = "btnThemGia";
            btnThemGia.Click += btnThemGia_Click;

            // --- Nhóm 2: Cập nhật ngày kết thúc ---

            // cboSanPhamKT
            cboSanPhamKT.Location = new System.Drawing.Point(12, 65);
            cboSanPhamKT.Size = new System.Drawing.Size(200, 27);
            cboSanPhamKT.Name = "cboSanPhamKT";
            cboSanPhamKT.DropDownStyle = ComboBoxStyle.DropDownList;

            // dtpNgayKT
            dtpNgayKT.Location = new System.Drawing.Point(220, 65);
            dtpNgayKT.Size = new System.Drawing.Size(160, 27);
            dtpNgayKT.Name = "dtpNgayKT";

            // btnCapNhatNgayKT
            btnCapNhatNgayKT.Location = new System.Drawing.Point(390, 63);
            btnCapNhatNgayKT.Size = new System.Drawing.Size(200, 30);
            btnCapNhatNgayKT.Text = "Cập nhật ngày kết thúc";
            btnCapNhatNgayKT.Name = "btnCapNhatNgayKT";
            btnCapNhatNgayKT.Click += btnCapNhatNgayKT_Click;

            // --- Nhóm 3: Báo cáo ---

            // dtpTuNgay
            dtpTuNgay.Location = new System.Drawing.Point(12, 110);
            dtpTuNgay.Size = new System.Drawing.Size(160, 27);
            dtpTuNgay.Name = "dtpTuNgay";

            // dtpDenNgay
            dtpDenNgay.Location = new System.Drawing.Point(180, 110);
            dtpDenNgay.Size = new System.Drawing.Size(160, 27);
            dtpDenNgay.Name = "dtpDenNgay";

            // btnBaoCao
            btnBaoCao.Location = new System.Drawing.Point(350, 108);
            btnBaoCao.Size = new System.Drawing.Size(200, 30);
            btnBaoCao.Text = "Xem báo cáo tài chính";
            btnBaoCao.Name = "btnBaoCao";
            btnBaoCao.Click += btnBaoCao_Click;

            // btnLamMoi
            btnLamMoi.Location = new System.Drawing.Point(560, 108);
            btnLamMoi.Size = new System.Drawing.Size(90, 30);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Click += btnLamMoi_Click;

            // dgvBangGia
            dgvBangGia.Location = new System.Drawing.Point(12, 155);
            dgvBangGia.Size = new System.Drawing.Size(776, 400);
            dgvBangGia.Name = "dgvBangGia";

            // Form
            ClientSize = new System.Drawing.Size(800, 590);
            Text = "Quản lý Bảng giá";
            Controls.Add(cboSanPham);
            Controls.Add(txtDonGia);
            Controls.Add(dtpNgayBD);
            Controls.Add(btnThemGia);
            Controls.Add(cboSanPhamKT);
            Controls.Add(dtpNgayKT);
            Controls.Add(btnCapNhatNgayKT);
            Controls.Add(dtpTuNgay);
            Controls.Add(dtpDenNgay);
            Controls.Add(btnBaoCao);
            Controls.Add(btnLamMoi);
            Controls.Add(dgvBangGia);
            Load += Form_BangGia_Load;

            ((System.ComponentModel.ISupportInitialize)dgvBangGia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cboSanPham;
        private TextBox txtDonGia;
        private DateTimePicker dtpNgayBD;
        private Button btnThemGia;
        private ComboBox cboSanPhamKT;
        private DateTimePicker dtpNgayKT;
        private Button btnCapNhatNgayKT;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnBaoCao;
        private Button btnLamMoi;
        private DataGridView dgvBangGia;
    }
}