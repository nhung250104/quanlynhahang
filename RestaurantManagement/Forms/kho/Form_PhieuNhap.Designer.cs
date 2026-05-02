namespace RestaurantManagement
{
    partial class Form_PhieuNhap
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
            dgvPhieuNhap  = new System.Windows.Forms.DataGridView();
            txtTimMaPN    = new System.Windows.Forms.TextBox();
            txtGhiChu     = new System.Windows.Forms.TextBox();
            cboNCC        = new System.Windows.Forms.ComboBox();
            dtpTuNgay     = new System.Windows.Forms.DateTimePicker();
            dtpDenNgay    = new System.Windows.Forms.DateTimePicker();
            dtpThoiHanTT  = new System.Windows.Forms.DateTimePicker();
            chkLocNgay    = new System.Windows.Forms.CheckBox();
            nudVAT        = new System.Windows.Forms.NumericUpDown();
            lblMaPN       = new System.Windows.Forms.Label();
            btnTimKiem    = new System.Windows.Forms.Button();
            btnTaoPN      = new System.Windows.Forms.Button();
            btnXemCT      = new System.Windows.Forms.Button();
            btnSoSanhGia  = new System.Windows.Forms.Button();
            btnLamMoi     = new System.Windows.Forms.Button();

            // === FORM ===
            this.Text          = "Quản lý Phiếu Nhập";
            this.Size          = new System.Drawing.Size(1100, 680);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load         += new System.EventHandler(Form_PhieuNhap_Load);

            // ── HÀNG 1: TÌM KIẾM ──
            var lblMa      = new System.Windows.Forms.Label();
            lblMa.Text     = "Mã PN:";
            lblMa.Location = new System.Drawing.Point(12, 15);
            lblMa.Size     = new System.Drawing.Size(48, 23);

            txtTimMaPN.Location = new System.Drawing.Point(63, 12);
            txtTimMaPN.Size     = new System.Drawing.Size(120, 23);

            var lblNCC      = new System.Windows.Forms.Label();
            lblNCC.Text     = "NCC:";
            lblNCC.Location = new System.Drawing.Point(193, 15);
            lblNCC.Size     = new System.Drawing.Size(35, 23);

            cboNCC.Location      = new System.Drawing.Point(231, 12);
            cboNCC.Size          = new System.Drawing.Size(220, 23);
            cboNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            chkLocNgay.Text     = "Lọc ngày";
            chkLocNgay.Location = new System.Drawing.Point(460, 13);
            chkLocNgay.Size     = new System.Drawing.Size(80, 23);

            var lblTu      = new System.Windows.Forms.Label();
            lblTu.Text     = "Từ:";
            lblTu.Location = new System.Drawing.Point(545, 15);
            lblTu.Size     = new System.Drawing.Size(25, 23);

            dtpTuNgay.Location = new System.Drawing.Point(573, 12);
            dtpTuNgay.Size     = new System.Drawing.Size(120, 23);
            dtpTuNgay.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            var lblDen      = new System.Windows.Forms.Label();
            lblDen.Text     = "Đến:";
            lblDen.Location = new System.Drawing.Point(700, 15);
            lblDen.Size     = new System.Drawing.Size(30, 23);

            dtpDenNgay.Location = new System.Drawing.Point(733, 12);
            dtpDenNgay.Size     = new System.Drawing.Size(120, 23);
            dtpDenNgay.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            btnTimKiem.Text     = "Tìm";
            btnTimKiem.Location = new System.Drawing.Point(863, 11);
            btnTimKiem.Size     = new System.Drawing.Size(70, 27);
            btnTimKiem.Click   += new System.EventHandler(btnTimKiem_Click);

            // ── DATAGRIDVIEW ──
            dgvPhieuNhap.Location  = new System.Drawing.Point(12, 48);
            dgvPhieuNhap.Size      = new System.Drawing.Size(1060, 370);
            dgvPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(
                                          dgvPhieuNhap_CellClick);

            // ── LABEL MÃ PN ──
            lblMaPN.Text      = "Mã PN: (chưa chọn)";
            lblMaPN.Location  = new System.Drawing.Point(12, 428);
            lblMaPN.Size      = new System.Drawing.Size(250, 23);
            lblMaPN.ForeColor = System.Drawing.Color.DarkBlue;
            lblMaPN.Font      = new System.Drawing.Font("Arial", 9,
                                    System.Drawing.FontStyle.Bold);

            // ── HÀNG TẠO PN: NCC + VAT + HẠN TT + GHI CHÚ ──
            var lblNCC2      = new System.Windows.Forms.Label();
            lblNCC2.Text     = "NCC tạo PN:";
            lblNCC2.Location = new System.Drawing.Point(12, 462);
            lblNCC2.Size     = new System.Drawing.Size(75, 23);

            var lblVAT      = new System.Windows.Forms.Label();
            lblVAT.Text     = "VAT (%):";
            lblVAT.Location = new System.Drawing.Point(290, 462);
            lblVAT.Size     = new System.Drawing.Size(58, 23);

            nudVAT.Location  = new System.Drawing.Point(351, 459);
            nudVAT.Size      = new System.Drawing.Size(60, 23);
            nudVAT.Minimum   = 0;
            nudVAT.Maximum   = 10;
            nudVAT.Value     = 10;

            var lblHan      = new System.Windows.Forms.Label();
            lblHan.Text     = "Hạn TT:";
            lblHan.Location = new System.Drawing.Point(425, 462);
            lblHan.Size     = new System.Drawing.Size(55, 23);

            dtpThoiHanTT.Location = new System.Drawing.Point(483, 459);
            dtpThoiHanTT.Size     = new System.Drawing.Size(130, 23);
            dtpThoiHanTT.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            var lblGC      = new System.Windows.Forms.Label();
            lblGC.Text     = "Ghi chú:";
            lblGC.Location = new System.Drawing.Point(625, 462);
            lblGC.Size     = new System.Drawing.Size(58, 23);

            txtGhiChu.Location = new System.Drawing.Point(686, 459);
            txtGhiChu.Size     = new System.Drawing.Size(250, 23);

            // ── BUTTONS ──
            btnTaoPN.Text      = "Tạo PN mới";
            btnTaoPN.Location  = new System.Drawing.Point(12, 505);
            btnTaoPN.Size      = new System.Drawing.Size(120, 34);
            btnTaoPN.BackColor = System.Drawing.Color.LightGreen;
            btnTaoPN.Click    += new System.EventHandler(btnTaoPN_Click);

            btnXemCT.Text      = "Xem chi tiết";
            btnXemCT.Location  = new System.Drawing.Point(142, 505);
            btnXemCT.Size      = new System.Drawing.Size(120, 34);
            btnXemCT.BackColor = System.Drawing.Color.LightSkyBlue;
            btnXemCT.Click    += new System.EventHandler(btnXemCT_Click);

            btnSoSanhGia.Text      = "So sánh giá";
            btnSoSanhGia.Location  = new System.Drawing.Point(272, 505);
            btnSoSanhGia.Size      = new System.Drawing.Size(120, 34);
            btnSoSanhGia.BackColor = System.Drawing.Color.LightYellow;
            btnSoSanhGia.Click    += new System.EventHandler(btnSoSanhGia_Click);

            btnLamMoi.Text     = "Làm mới";
            btnLamMoi.Location = new System.Drawing.Point(402, 505);
            btnLamMoi.Size     = new System.Drawing.Size(100, 34);
            btnLamMoi.Click   += new System.EventHandler(btnLamMoi_Click);

            // ── THÊM VÀO FORM ──
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblMa, txtTimMaPN, lblNCC, cboNCC,
                chkLocNgay, lblTu, dtpTuNgay, lblDen, dtpDenNgay,
                btnTimKiem,
                dgvPhieuNhap,
                lblMaPN,
                lblNCC2, lblVAT, nudVAT,
                lblHan, dtpThoiHanTT,
                lblGC, txtGhiChu,
                btnTaoPN, btnXemCT, btnSoSanhGia, btnLamMoi
            });
        }

        private System.Windows.Forms.DataGridView   dgvPhieuNhap;
        private System.Windows.Forms.TextBox        txtTimMaPN;
        private System.Windows.Forms.TextBox        txtGhiChu;
        private System.Windows.Forms.ComboBox       cboNCC;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpThoiHanTT;
        private System.Windows.Forms.CheckBox       chkLocNgay;
        private System.Windows.Forms.NumericUpDown  nudVAT;
        private System.Windows.Forms.Label          lblMaPN;
        private System.Windows.Forms.Button         btnTimKiem;
        private System.Windows.Forms.Button         btnTaoPN;
        private System.Windows.Forms.Button         btnXemCT;
        private System.Windows.Forms.Button         btnSoSanhGia;
        private System.Windows.Forms.Button         btnLamMoi;
    }
}