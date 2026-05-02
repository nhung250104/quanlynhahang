namespace RestaurantManagement.banhang
{
    partial class Form_NhanVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvNhanVien = new System.Windows.Forms.DataGridView();
            txtTimKiem  = new System.Windows.Forms.TextBox();
            txtTenNV    = new System.Windows.Forms.TextBox();
            lblMaNV     = new System.Windows.Forms.Label();
            btnTimKiem  = new System.Windows.Forms.Button();
            btnThem     = new System.Windows.Forms.Button();
            btnSua      = new System.Windows.Forms.Button();
            btnXoa      = new System.Windows.Forms.Button();
            btnLamMoi   = new System.Windows.Forms.Button();

            // === FORM ===
            this.Text          = "Quản lý Nhân Viên";
            this.Size          = new System.Drawing.Size(800, 550);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // === LABEL TÌM KIẾM ===
            var lblTim = new System.Windows.Forms.Label();
            lblTim.Text     = "Tìm kiếm:";
            lblTim.Location = new System.Drawing.Point(12, 15);
            lblTim.Size     = new System.Drawing.Size(70, 23);

            // === TEXTBOX TÌM KIẾM ===
            txtTimKiem.Location = new System.Drawing.Point(85, 12);
            txtTimKiem.Size     = new System.Drawing.Size(200, 23);

            // === BUTTON TÌM KIẾM ===
            btnTimKiem.Text     = "Tìm kiếm";
            btnTimKiem.Location = new System.Drawing.Point(295, 11);
            btnTimKiem.Size     = new System.Drawing.Size(90, 25);
            btnTimKiem.Click   += new System.EventHandler(btnTimKiem_Click);

            // === DATAGRIDVIEW ===
            dgvNhanVien.Location = new System.Drawing.Point(12, 45);
            dgvNhanVien.Size     = new System.Drawing.Size(760, 320);
            dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvNhanVien_CellClick);

            // === LABEL MÃ NV ===
            lblMaNV.Text     = "Mã NV: (chưa chọn)";
            lblMaNV.Location = new System.Drawing.Point(12, 378);
            lblMaNV.Size     = new System.Drawing.Size(200, 23);
            lblMaNV.ForeColor = System.Drawing.Color.DarkBlue;

            // === LABEL TÊN NV ===
            var lblTen = new System.Windows.Forms.Label();
            lblTen.Text     = "Tên nhân viên:";
            lblTen.Location = new System.Drawing.Point(12, 410);
            lblTen.Size     = new System.Drawing.Size(100, 23);

            // === TEXTBOX TÊN NV ===
            txtTenNV.Location = new System.Drawing.Point(115, 407);
            txtTenNV.Size     = new System.Drawing.Size(250, 23);

            // === CÁC BUTTON ===
            btnThem.Text     = "Thêm";
            btnThem.Location = new System.Drawing.Point(12, 450);
            btnThem.Size     = new System.Drawing.Size(90, 32);
            btnThem.BackColor = System.Drawing.Color.LightGreen;
            btnThem.Click    += new System.EventHandler(btnThem_Click);

            btnSua.Text      = "Sửa";
            btnSua.Location  = new System.Drawing.Point(112, 450);
            btnSua.Size      = new System.Drawing.Size(90, 32);
            btnSua.BackColor = System.Drawing.Color.LightYellow;
            btnSua.Click     += new System.EventHandler(btnSua_Click);

            btnXoa.Text      = "Xóa";
            btnXoa.Location  = new System.Drawing.Point(212, 450);
            btnXoa.Size      = new System.Drawing.Size(90, 32);
            btnXoa.BackColor = System.Drawing.Color.LightCoral;
            btnXoa.Click     += new System.EventHandler(btnXoa_Click);

            btnLamMoi.Text     = "Làm mới";
            btnLamMoi.Location = new System.Drawing.Point(312, 450);
            btnLamMoi.Size     = new System.Drawing.Size(90, 32);
            btnLamMoi.Click   += new System.EventHandler(btnLamMoi_Click);
            // === THÊM VÀO FORM ===
            this.Load += new System.EventHandler(this.Form_NhanVien_Load); // ← thêm dòng này
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTim, txtTimKiem, btnTimKiem,
                dgvNhanVien,
                lblMaNV, lblTen, txtTenNV,
                btnThem, btnSua, btnXoa, btnLamMoi
            });

            // === THÊM VÀO FORM ===
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTim, txtTimKiem, btnTimKiem,
                dgvNhanVien,
                lblMaNV, lblTen, txtTenNV,
                btnThem, btnSua, btnXoa, btnLamMoi
            });
        }

        // Khai báo các controls
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.TextBox      txtTimKiem;
        private System.Windows.Forms.TextBox      txtTenNV;
        private System.Windows.Forms.Label        lblMaNV;
        private System.Windows.Forms.Button       btnTimKiem;
        private System.Windows.Forms.Button       btnThem;
        private System.Windows.Forms.Button       btnSua;
        private System.Windows.Forms.Button       btnXoa;
        private System.Windows.Forms.Button       btnLamMoi;
    }
}