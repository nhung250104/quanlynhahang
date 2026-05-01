namespace RestaurantManagement.banhang
{
    partial class Form_HoaDon
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
            dgvHoaDon  = new System.Windows.Forms.DataGridView();
            txtTimMaHD = new System.Windows.Forms.TextBox();
            dtpTuNgay  = new System.Windows.Forms.DateTimePicker();
            dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            chkLocNgay = new System.Windows.Forms.CheckBox();
            lblTongHD  = new System.Windows.Forms.Label();
            btnTimKiem = new System.Windows.Forms.Button();
            btnTaoHD   = new System.Windows.Forms.Button();
            btnXemCTHD = new System.Windows.Forms.Button();
            btnBaoCao  = new System.Windows.Forms.Button();
            btnLamMoi  = new System.Windows.Forms.Button();

            // === FORM ===
            this.Text          = "Quản lý Hóa Đơn";
            this.Size          = new System.Drawing.Size(1000, 620);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load         += new System.EventHandler(Form_HoaDon_Load);

            // === LABEL TÌM KIẾM ===
            var lblTim      = new System.Windows.Forms.Label();
            lblTim.Text     = "Mã HĐ:";
            lblTim.Location = new System.Drawing.Point(12, 15);
            lblTim.Size     = new System.Drawing.Size(50, 23);

            // === TEXTBOX TÌM MÃ HD ===
            txtTimMaHD.Location = new System.Drawing.Point(65, 12);
            txtTimMaHD.Size     = new System.Drawing.Size(150, 23);

            // === CHECKBOX LỌC NGÀY ===
            chkLocNgay.Text     = "Lọc theo ngày";
            chkLocNgay.Location = new System.Drawing.Point(225, 13);
            chkLocNgay.Size     = new System.Drawing.Size(110, 23);

            // === LABEL TỪ NGÀY ===
            var lblTu      = new System.Windows.Forms.Label();
            lblTu.Text     = "Từ:";
            lblTu.Location = new System.Drawing.Point(340, 13);
            lblTu.Size     = new System.Drawing.Size(25, 23);

            // === DATETIMEPICKER TỪ NGÀY ===
            dtpTuNgay.Location = new System.Drawing.Point(368, 10);
            dtpTuNgay.Size     = new System.Drawing.Size(130, 23);
            dtpTuNgay.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            // === LABEL ĐẾN NGÀY ===
            var lblDen      = new System.Windows.Forms.Label();
            lblDen.Text     = "Đến:";
            lblDen.Location = new System.Drawing.Point(505, 13);
            lblDen.Size     = new System.Drawing.Size(30, 23);

            // === DATETIMEPICKER ĐẾN NGÀY ===
            dtpDenNgay.Location = new System.Drawing.Point(538, 10);
            dtpDenNgay.Size     = new System.Drawing.Size(130, 23);
            dtpDenNgay.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            // === BUTTON TÌM KIẾM ===
            btnTimKiem.Text     = "Tìm kiếm";
            btnTimKiem.Location = new System.Drawing.Point(678, 9);
            btnTimKiem.Size     = new System.Drawing.Size(90, 27);
            btnTimKiem.Click   += new System.EventHandler(btnTimKiem_Click);

            // === DATAGRIDVIEW ===
            dgvHoaDon.Location  = new System.Drawing.Point(12, 45);
            dgvHoaDon.Size      = new System.Drawing.Size(960, 440);
            dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvHoaDon_CellClick);

            // === LABEL TỔNG HD ===
            lblTongHD.Text     = "Tổng: 0 hóa đơn";
            lblTongHD.Location = new System.Drawing.Point(12, 495);
            lblTongHD.Size     = new System.Drawing.Size(200, 23);
            lblTongHD.ForeColor = System.Drawing.Color.DarkBlue;

            // === BUTTON TẠO HĐ ===
            btnTaoHD.Text      = "Tạo HĐ mới";
            btnTaoHD.Location  = new System.Drawing.Point(12, 528);
            btnTaoHD.Size      = new System.Drawing.Size(110, 32);
            btnTaoHD.BackColor = System.Drawing.Color.LightGreen;
            btnTaoHD.Click    += new System.EventHandler(btnTaoHD_Click);

            // === BUTTON XEM CHI TIẾT ===
            btnXemCTHD.Text     = "Xem chi tiết";
            btnXemCTHD.Location = new System.Drawing.Point(132, 528);
            btnXemCTHD.Size     = new System.Drawing.Size(110, 32);
            btnXemCTHD.BackColor = System.Drawing.Color.LightSkyBlue;
            btnXemCTHD.Click   += new System.EventHandler(btnXemCTHD_Click);

            // === BUTTON BÁO CÁO ===
            btnBaoCao.Text      = "Báo cáo TC";
            btnBaoCao.Location  = new System.Drawing.Point(252, 528);
            btnBaoCao.Size      = new System.Drawing.Size(110, 32);
            btnBaoCao.BackColor = System.Drawing.Color.LightYellow;
            btnBaoCao.Click    += new System.EventHandler(btnBaoCao_Click);

            // === BUTTON LÀM MỚI ===
            btnLamMoi.Text      = "Làm mới";
            btnLamMoi.Location  = new System.Drawing.Point(372, 528);
            btnLamMoi.Size      = new System.Drawing.Size(110, 32);
            btnLamMoi.Click    += new System.EventHandler(btnLamMoi_Click);

            // === THÊM VÀO FORM ===
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTim, txtTimMaHD, chkLocNgay,
                lblTu, dtpTuNgay, lblDen, dtpDenNgay,
                btnTimKiem, dgvHoaDon, lblTongHD,
                btnTaoHD, btnXemCTHD, btnBaoCao, btnLamMoi
            });
        }

        private System.Windows.Forms.DataGridView   dgvHoaDon;
        private System.Windows.Forms.TextBox        txtTimMaHD;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.CheckBox       chkLocNgay;
        private System.Windows.Forms.Label          lblTongHD;
        private System.Windows.Forms.Button         btnTimKiem;
        private System.Windows.Forms.Button         btnTaoHD;
        private System.Windows.Forms.Button         btnXemCTHD;
        private System.Windows.Forms.Button         btnBaoCao;
        private System.Windows.Forms.Button         btnLamMoi;
    }
}