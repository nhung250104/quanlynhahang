namespace RestaurantManagement
{
    partial class Form_NhaCungCap
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
            dgvNCC     = new System.Windows.Forms.DataGridView();
            txtTimKiem = new System.Windows.Forms.TextBox();
            txtTenNCC  = new System.Windows.Forms.TextBox();
            txtSDT     = new System.Windows.Forms.TextBox();
            txtDiaChi  = new System.Windows.Forms.TextBox();
            lblMaNCC   = new System.Windows.Forms.Label();
            btnTimKiem = new System.Windows.Forms.Button();
            btnThem    = new System.Windows.Forms.Button();
            btnSua     = new System.Windows.Forms.Button();
            btnXoa     = new System.Windows.Forms.Button();
            btnLamMoi  = new System.Windows.Forms.Button();

            // === FORM ===
            this.Text          = "Quản lý Nhà Cung Cấp";
            this.Size          = new System.Drawing.Size(900, 620);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load         += new System.EventHandler(Form_NhaCungCap_Load);

            // === LABEL TÌM KIẾM ===
            var lblTim      = new System.Windows.Forms.Label();
            lblTim.Text     = "Tìm kiếm:";
            lblTim.Location = new System.Drawing.Point(12, 15);
            lblTim.Size     = new System.Drawing.Size(65, 23);

            // === TEXTBOX TÌM KIẾM ===
            txtTimKiem.Location = new System.Drawing.Point(80, 12);
            txtTimKiem.Size     = new System.Drawing.Size(220, 23);

            // === BUTTON TÌM KIẾM ===
            btnTimKiem.Text     = "Tìm kiếm";
            btnTimKiem.Location = new System.Drawing.Point(310, 11);
            btnTimKiem.Size     = new System.Drawing.Size(90, 27);
            btnTimKiem.Click   += new System.EventHandler(btnTimKiem_Click);

            // === DATAGRIDVIEW ===
            dgvNCC.Location  = new System.Drawing.Point(12, 45);
            dgvNCC.Size      = new System.Drawing.Size(860, 340);
            dgvNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(
                                    dgvNCC_CellClick);

            // === LABEL MÃ NCC ===
            lblMaNCC.Text      = "Mã NCC: (chưa chọn)";
            lblMaNCC.Location  = new System.Drawing.Point(12, 398);
            lblMaNCC.Size      = new System.Drawing.Size(250, 23);
            lblMaNCC.ForeColor = System.Drawing.Color.DarkBlue;
            lblMaNCC.Font      = new System.Drawing.Font("Arial", 9,
                                     System.Drawing.FontStyle.Bold);

            // === LABEL TÊN NCC ===
            var lblTen      = new System.Windows.Forms.Label();
            lblTen.Text     = "Tên NCC:";
            lblTen.Location = new System.Drawing.Point(12, 432);
            lblTen.Size     = new System.Drawing.Size(65, 23);

            // === TEXTBOX TÊN NCC ===
            txtTenNCC.Location = new System.Drawing.Point(80, 429);
            txtTenNCC.Size     = new System.Drawing.Size(350, 23);

            // === LABEL SDT ===
            var lblSDT      = new System.Windows.Forms.Label();
            lblSDT.Text     = "Số ĐT:";
            lblSDT.Location = new System.Drawing.Point(445, 432);
            lblSDT.Size     = new System.Drawing.Size(50, 23);

            // === TEXTBOX SDT ===
            txtSDT.Location = new System.Drawing.Point(498, 429);
            txtSDT.Size     = new System.Drawing.Size(150, 23);

            // === LABEL ĐỊA CHỈ ===
            var lblDC      = new System.Windows.Forms.Label();
            lblDC.Text     = "Địa chỉ:";
            lblDC.Location = new System.Drawing.Point(12, 465);
            lblDC.Size     = new System.Drawing.Size(65, 23);

            // === TEXTBOX ĐỊA CHỈ ===
            txtDiaChi.Location = new System.Drawing.Point(80, 462);
            txtDiaChi.Size     = new System.Drawing.Size(570, 23);

            // === BUTTON THÊM ===
            btnThem.Text      = "Thêm";
            btnThem.Location  = new System.Drawing.Point(12, 505);
            btnThem.Size      = new System.Drawing.Size(100, 34);
            btnThem.BackColor = System.Drawing.Color.LightGreen;
            btnThem.Click    += new System.EventHandler(btnThem_Click);

            // === BUTTON SỬA ===
            btnSua.Text      = "Sửa";
            btnSua.Location  = new System.Drawing.Point(122, 505);
            btnSua.Size      = new System.Drawing.Size(100, 34);
            btnSua.BackColor = System.Drawing.Color.LightYellow;
            btnSua.Click    += new System.EventHandler(btnSua_Click);

            // === BUTTON XÓA ===
            btnXoa.Text      = "Xóa";
            btnXoa.Location  = new System.Drawing.Point(232, 505);
            btnXoa.Size      = new System.Drawing.Size(100, 34);
            btnXoa.BackColor = System.Drawing.Color.LightCoral;
            btnXoa.Click    += new System.EventHandler(btnXoa_Click);

            // === BUTTON LÀM MỚI ===
            btnLamMoi.Text     = "Làm mới";
            btnLamMoi.Location = new System.Drawing.Point(342, 505);
            btnLamMoi.Size     = new System.Drawing.Size(100, 34);
            btnLamMoi.Click   += new System.EventHandler(btnLamMoi_Click);

            // === THÊM VÀO FORM ===
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTim, txtTimKiem, btnTimKiem,
                dgvNCC,
                lblMaNCC,
                lblTen,  txtTenNCC,
                lblSDT,  txtSDT,
                lblDC,   txtDiaChi,
                btnThem, btnSua, btnXoa, btnLamMoi
            });
        }

        private System.Windows.Forms.DataGridView dgvNCC;
        private System.Windows.Forms.TextBox      txtTimKiem;
        private System.Windows.Forms.TextBox      txtTenNCC;
        private System.Windows.Forms.TextBox      txtSDT;
        private System.Windows.Forms.TextBox      txtDiaChi;
        private System.Windows.Forms.Label        lblMaNCC;
        private System.Windows.Forms.Button       btnTimKiem;
        private System.Windows.Forms.Button       btnThem;
        private System.Windows.Forms.Button       btnSua;
        private System.Windows.Forms.Button       btnXoa;
        private System.Windows.Forms.Button       btnLamMoi;
    }
}