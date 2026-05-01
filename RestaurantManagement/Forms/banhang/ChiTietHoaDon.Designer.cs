namespace RestaurantManagement.banhang
{
    partial class Form_ChiTietHoaDon
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
            lblMaHD      = new System.Windows.Forms.Label();
            dgvSanPham   = new System.Windows.Forms.DataGridView();
            dgvChiTiet   = new System.Windows.Forms.DataGridView();
            txtSoLuong   = new System.Windows.Forms.TextBox();
            txtChietKhau = new System.Windows.Forms.TextBox();
            lblTongTien  = new System.Windows.Forms.Label();
            btnThemMon   = new System.Windows.Forms.Button();
            btnXoaMon    = new System.Windows.Forms.Button();
            btnLuuHD     = new System.Windows.Forms.Button();
            btnDong      = new System.Windows.Forms.Button();

            // === FORM ===
            this.Text          = "Chi tiết hóa đơn";
            this.Size          = new System.Drawing.Size(1100, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load         += new System.EventHandler(Form_ChiTietHoaDon_Load);

            // === LABEL MÃ HD ===
            lblMaHD.Text      = "Hóa đơn: ...";
            lblMaHD.Location  = new System.Drawing.Point(12, 10);
            lblMaHD.Size      = new System.Drawing.Size(300, 25);
            lblMaHD.Font      = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            lblMaHD.ForeColor = System.Drawing.Color.DarkBlue;

            // === LABEL DANH SÁCH SP ===
            var lblSP      = new System.Windows.Forms.Label();
            lblSP.Text     = "Danh sách sản phẩm:";
            lblSP.Location = new System.Drawing.Point(12, 42);
            lblSP.Size     = new System.Drawing.Size(150, 20);

            // === DATAGRIDVIEW SẢN PHẨM (trái) ===
            dgvSanPham.Location  = new System.Drawing.Point(12, 65);
            dgvSanPham.Size      = new System.Drawing.Size(500, 430);
            dgvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvSanPham_CellClick);

            // === LABEL CHI TIẾT HD ===
            var lblCT      = new System.Windows.Forms.Label();
            lblCT.Text     = "Món đã chọn:";
            lblCT.Location = new System.Drawing.Point(530, 42);
            lblCT.Size     = new System.Drawing.Size(100, 20);

            // === DATAGRIDVIEW CHI TIẾT (phải) ===
            dgvChiTiet.Location  = new System.Drawing.Point(530, 65);
            dgvChiTiet.Size      = new System.Drawing.Size(530, 300);
            dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvChiTiet_CellClick);

            // === LABEL SỐ LƯỢNG ===
            var lblSL      = new System.Windows.Forms.Label();
            lblSL.Text     = "Số lượng:";
            lblSL.Location = new System.Drawing.Point(530, 378);
            lblSL.Size     = new System.Drawing.Size(70, 23);

            // === TEXTBOX SỐ LƯỢNG ===
            txtSoLuong.Location = new System.Drawing.Point(608, 375);
            txtSoLuong.Size     = new System.Drawing.Size(80, 23);
            txtSoLuong.Text     = "1";

            // === BUTTON THÊM MÓN ===
            btnThemMon.Text      = "Thêm món ➕";
            btnThemMon.Location  = new System.Drawing.Point(700, 373);
            btnThemMon.Size      = new System.Drawing.Size(110, 28);
            btnThemMon.BackColor = System.Drawing.Color.LightGreen;
            btnThemMon.Click    += new System.EventHandler(btnThemMon_Click);

            // === BUTTON XÓA MÓN ===
            btnXoaMon.Text      = "Xóa món ❌";
            btnXoaMon.Location  = new System.Drawing.Point(820, 373);
            btnXoaMon.Size      = new System.Drawing.Size(110, 28);
            btnXoaMon.BackColor = System.Drawing.Color.LightCoral;
            btnXoaMon.Click    += new System.EventHandler(btnXoaMon_Click);

            // === LABEL CHIẾT KHẤU ===
            var lblCK      = new System.Windows.Forms.Label();
            lblCK.Text     = "Chiết khấu (đ):";
            lblCK.Location = new System.Drawing.Point(530, 418);
            lblCK.Size     = new System.Drawing.Size(100, 23);

            // === TEXTBOX CHIẾT KHẤU ===
            txtChietKhau.Location      = new System.Drawing.Point(635, 415);
            txtChietKhau.Size          = new System.Drawing.Size(120, 23);
            txtChietKhau.Text          = "0";
            txtChietKhau.TextChanged  += new System.EventHandler(txtChietKhau_TextChanged);

            // === LABEL TỔNG TIỀN ===
            lblTongTien.Text      = "Tổng: 0 đ";
            lblTongTien.Location  = new System.Drawing.Point(530, 455);
            lblTongTien.Size      = new System.Drawing.Size(300, 28);
            lblTongTien.Font      = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            lblTongTien.ForeColor = System.Drawing.Color.DarkRed;

            // === BUTTON LƯU HD ===
            btnLuuHD.Text      = "💾 Lưu hóa đơn";
            btnLuuHD.Location  = new System.Drawing.Point(530, 500);
            btnLuuHD.Size      = new System.Drawing.Size(150, 36);
            btnLuuHD.BackColor = System.Drawing.Color.LightGreen;
            btnLuuHD.Click    += new System.EventHandler(btnLuuHD_Click);

            // === BUTTON ĐÓNG ===
            btnDong.Text      = "Đóng";
            btnDong.Location  = new System.Drawing.Point(690, 500);
            btnDong.Size      = new System.Drawing.Size(100, 36);
            btnDong.Click    += new System.EventHandler(btnDong_Click);

            // === THÊM VÀO FORM ===
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblMaHD,
                lblSP,  dgvSanPham,
                lblCT,  dgvChiTiet,
                lblSL,  txtSoLuong,
                btnThemMon, btnXoaMon,
                lblCK,  txtChietKhau,
                lblTongTien,
                btnLuuHD, btnDong
            });
        }

        private System.Windows.Forms.Label          lblMaHD;
        private System.Windows.Forms.DataGridView   dgvSanPham;
        private System.Windows.Forms.DataGridView   dgvChiTiet;
        private System.Windows.Forms.TextBox        txtSoLuong;
        private System.Windows.Forms.TextBox        txtChietKhau;
        private System.Windows.Forms.Label          lblTongTien;
        private System.Windows.Forms.Button         btnThemMon;
        private System.Windows.Forms.Button         btnXoaMon;
        private System.Windows.Forms.Button         btnLuuHD;
        private System.Windows.Forms.Button         btnDong;
    }
}