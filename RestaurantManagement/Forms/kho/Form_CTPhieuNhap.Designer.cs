namespace RestaurantManagement
{
    partial class Form_CTPhieuNhap
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
            lblMaPN       = new System.Windows.Forms.Label();
            dgvNguyenLieu = new System.Windows.Forms.DataGridView();
            dgvChiTiet    = new System.Windows.Forms.DataGridView();
            txtDonGia     = new System.Windows.Forms.TextBox();
            nudSoLuong    = new System.Windows.Forms.NumericUpDown();
            dtpNSX        = new System.Windows.Forms.DateTimePicker();
            dtpHSD        = new System.Windows.Forms.DateTimePicker();
            lblTongTien   = new System.Windows.Forms.Label();
            btnThemNL     = new System.Windows.Forms.Button();
            btnXoaNL      = new System.Windows.Forms.Button();
            btnLuuPN      = new System.Windows.Forms.Button();
            btnDong       = new System.Windows.Forms.Button();

            // === FORM ===
            this.Text          = "Chi tiết phiếu nhập";
            this.Size          = new System.Drawing.Size(1100, 660);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load         += new System.EventHandler(Form_CTPhieuNhap_Load);

            // === LABEL MÃ PN ===
            lblMaPN.Text      = "Phiếu nhập: ...";
            lblMaPN.Location  = new System.Drawing.Point(12, 10);
            lblMaPN.Size      = new System.Drawing.Size(300, 25);
            lblMaPN.Font      = new System.Drawing.Font("Arial", 12,
                                    System.Drawing.FontStyle.Bold);
            lblMaPN.ForeColor = System.Drawing.Color.DarkBlue;

            // === LABEL DANH SÁCH NL ===
            var lblNL      = new System.Windows.Forms.Label();
            lblNL.Text     = "Danh sách nguyên liệu:";
            lblNL.Location = new System.Drawing.Point(12, 42);
            lblNL.Size     = new System.Drawing.Size(160, 20);

            // === DATAGRIDVIEW NGUYÊN LIỆU (trái) ===
            dgvNguyenLieu.Location  = new System.Drawing.Point(12, 65);
            dgvNguyenLieu.Size      = new System.Drawing.Size(480, 430);
            dgvNguyenLieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(
                                            dgvNguyenLieu_CellClick);

            // === LABEL CHI TIẾT ===
            var lblCT      = new System.Windows.Forms.Label();
            lblCT.Text     = "Nguyên liệu đã nhập:";
            lblCT.Location = new System.Drawing.Point(510, 42);
            lblCT.Size     = new System.Drawing.Size(150, 20);

            // === DATAGRIDVIEW CHI TIẾT (phải) ===
            dgvChiTiet.Location = new System.Drawing.Point(510, 65);
            dgvChiTiet.Size     = new System.Drawing.Size(555, 280);

            // === LABEL SỐ LƯỢNG ===
            var lblSL      = new System.Windows.Forms.Label();
            lblSL.Text     = "Số lượng:";
            lblSL.Location = new System.Drawing.Point(510, 358);
            lblSL.Size     = new System.Drawing.Size(70, 23);

            // === NUMERICUPDOWN SỐ LƯỢNG ===
            nudSoLuong.Location = new System.Drawing.Point(585, 355);
            nudSoLuong.Size     = new System.Drawing.Size(80, 23);
            nudSoLuong.Minimum  = 1;
            nudSoLuong.Maximum  = 9999;
            nudSoLuong.Value    = 1;

            // === LABEL ĐƠN GIÁ ===
            var lblGia      = new System.Windows.Forms.Label();
            lblGia.Text     = "Đơn giá (đ):";
            lblGia.Location = new System.Drawing.Point(510, 390);
            lblGia.Size     = new System.Drawing.Size(80, 23);

            // === TEXTBOX ĐƠN GIÁ ===
            txtDonGia.Location = new System.Drawing.Point(595, 387);
            txtDonGia.Size     = new System.Drawing.Size(120, 23);

            // === LABEL NGÀY SX ===
            var lblNSX      = new System.Windows.Forms.Label();
            lblNSX.Text     = "Ngày SX:";
            lblNSX.Location = new System.Drawing.Point(510, 423);
            lblNSX.Size     = new System.Drawing.Size(70, 23);

            // === DATETIMEPICKER NSX ===
            dtpNSX.Location = new System.Drawing.Point(585, 420);
            dtpNSX.Size     = new System.Drawing.Size(150, 23);
            dtpNSX.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            // === LABEL HẠN SD ===
            var lblHSD      = new System.Windows.Forms.Label();
            lblHSD.Text     = "Hạn SD:";
            lblHSD.Location = new System.Drawing.Point(510, 456);
            lblHSD.Size     = new System.Drawing.Size(70, 23);

            // === DATETIMEPICKER HSD ===
            dtpHSD.Location = new System.Drawing.Point(585, 453);
            dtpHSD.Size     = new System.Drawing.Size(150, 23);
            dtpHSD.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            // === BUTTON THÊM NL ===
            btnThemNL.Text      = "Thêm NL ➕";
            btnThemNL.Location  = new System.Drawing.Point(510, 490);
            btnThemNL.Size      = new System.Drawing.Size(120, 32);
            btnThemNL.BackColor = System.Drawing.Color.LightGreen;
            btnThemNL.Click    += new System.EventHandler(btnThemNL_Click);

            // === BUTTON XÓA NL ===
            btnXoaNL.Text      = "Xóa NL ❌";
            btnXoaNL.Location  = new System.Drawing.Point(640, 490);
            btnXoaNL.Size      = new System.Drawing.Size(120, 32);
            btnXoaNL.BackColor = System.Drawing.Color.LightCoral;
            btnXoaNL.Click    += new System.EventHandler(btnXoaNL_Click);

            // === LABEL TỔNG TIỀN ===
            lblTongTien.Text      = "Tổng: 0 đ";
            lblTongTien.Location  = new System.Drawing.Point(510, 535);
            lblTongTien.Size      = new System.Drawing.Size(300, 28);
            lblTongTien.Font      = new System.Drawing.Font("Arial", 12,
                                        System.Drawing.FontStyle.Bold);
            lblTongTien.ForeColor = System.Drawing.Color.DarkRed;

            // === BUTTON LƯU PN ===
            btnLuuPN.Text      = "💾 Lưu phiếu nhập";
            btnLuuPN.Location  = new System.Drawing.Point(510, 575);
            btnLuuPN.Size      = new System.Drawing.Size(160, 36);
            btnLuuPN.BackColor = System.Drawing.Color.LightGreen;
            btnLuuPN.Click    += new System.EventHandler(btnLuuPN_Click);

            // === BUTTON ĐÓNG ===
            btnDong.Text      = "Đóng";
            btnDong.Location  = new System.Drawing.Point(680, 575);
            btnDong.Size      = new System.Drawing.Size(100, 36);
            btnDong.Click    += new System.EventHandler(btnDong_Click);

            // === THÊM VÀO FORM ===
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblMaPN,
                lblNL,  dgvNguyenLieu,
                lblCT,  dgvChiTiet,
                lblSL,  nudSoLuong,
                lblGia, txtDonGia,
                lblNSX, dtpNSX,
                lblHSD, dtpHSD,
                btnThemNL, btnXoaNL,
                lblTongTien,
                btnLuuPN, btnDong
            });
        }

        private System.Windows.Forms.Label            lblMaPN;
        private System.Windows.Forms.DataGridView     dgvNguyenLieu;
        private System.Windows.Forms.DataGridView     dgvChiTiet;
        private System.Windows.Forms.TextBox          txtDonGia;
        private System.Windows.Forms.NumericUpDown    nudSoLuong;
        private System.Windows.Forms.DateTimePicker   dtpNSX;
        private System.Windows.Forms.DateTimePicker   dtpHSD;
        private System.Windows.Forms.Label            lblTongTien;
        private System.Windows.Forms.Button           btnThemNL;
        private System.Windows.Forms.Button           btnXoaNL;
        private System.Windows.Forms.Button           btnLuuPN;
        private System.Windows.Forms.Button           btnDong;
    }
}