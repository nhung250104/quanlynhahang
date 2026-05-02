namespace RestaurantManagement
{
    partial class Form_Main
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
            lblTieuDe      = new System.Windows.Forms.Label();
            btnNhanVien    = new System.Windows.Forms.Button();
            btnHoaDon      = new System.Windows.Forms.Button();
            btnNhaCungCap  = new System.Windows.Forms.Button();
            btnPhieuNhap   = new System.Windows.Forms.Button();
            btnSanPham     = new System.Windows.Forms.Button();
            btnNguyenLieu  = new System.Windows.Forms.Button();
            btnBangGia     = new System.Windows.Forms.Button();
            btnThoat       = new System.Windows.Forms.Button();

            // === FORM ===
            this.Text          = "Quản Lý Nhà Hàng";
            this.Size          = new System.Drawing.Size(540, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox   = false;
            this.Load         += new System.EventHandler(Form_Main_Load);
            this.BackColor     = System.Drawing.Color.WhiteSmoke;

            // === TIÊU ĐỀ ===
            lblTieuDe.Text      = "HỆ THỐNG QUẢN LÝ NHÀ HÀNG";
            lblTieuDe.Location  = new System.Drawing.Point(0, 20);
            lblTieuDe.Size      = new System.Drawing.Size(524, 40);
            lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTieuDe.Font      = new System.Drawing.Font("Arial", 16,
                                      System.Drawing.FontStyle.Bold);
            lblTieuDe.ForeColor = System.Drawing.Color.DarkBlue;

            // === LABEL LUỒNG 1 ===
            var lbl1      = new System.Windows.Forms.Label();
            lbl1.Text     = "── BÁN HÀNG ──";
            lbl1.Location = new System.Drawing.Point(30, 80);
            lbl1.Size     = new System.Drawing.Size(460, 24);
            lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl1.Font     = new System.Drawing.Font("Arial", 10,
                                System.Drawing.FontStyle.Bold);
            lbl1.ForeColor = System.Drawing.Color.DarkGreen;

            // BUTTON NHÂN VIÊN
            btnNhanVien.Text      = "👤  Quản lý Nhân Viên";
            btnNhanVien.Location  = new System.Drawing.Point(80, 113);
            btnNhanVien.Size      = new System.Drawing.Size(360, 45);
            btnNhanVien.Font      = new System.Drawing.Font("Arial", 11);
            btnNhanVien.BackColor = System.Drawing.Color.MediumSeaGreen;
            btnNhanVien.ForeColor = System.Drawing.Color.White;
            btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNhanVien.Click    += new System.EventHandler(btnNhanVien_Click);

            // BUTTON HÓA ĐƠN
            btnHoaDon.Text      = "🧾  Quản lý Hóa Đơn";
            btnHoaDon.Location  = new System.Drawing.Point(80, 168);
            btnHoaDon.Size      = new System.Drawing.Size(360, 45);
            btnHoaDon.Font      = new System.Drawing.Font("Arial", 11);
            btnHoaDon.BackColor = System.Drawing.Color.SeaGreen;
            btnHoaDon.ForeColor = System.Drawing.Color.White;
            btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHoaDon.Click    += new System.EventHandler(btnHoaDon_Click);

            // === LABEL LUỒNG 2 ===
            var lbl2      = new System.Windows.Forms.Label();
            lbl2.Text     = "── KHO ──";
            lbl2.Location = new System.Drawing.Point(30, 228);
            lbl2.Size     = new System.Drawing.Size(460, 24);
            lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl2.Font     = new System.Drawing.Font("Arial", 10,
                                System.Drawing.FontStyle.Bold);
            lbl2.ForeColor = System.Drawing.Color.DarkOrange;

            // BUTTON NHÀ CUNG CẤP
            btnNhaCungCap.Text      = "🏭  Quản lý Nhà Cung Cấp";
            btnNhaCungCap.Location  = new System.Drawing.Point(80, 261);
            btnNhaCungCap.Size      = new System.Drawing.Size(360, 45);
            btnNhaCungCap.Font      = new System.Drawing.Font("Arial", 11);
            btnNhaCungCap.BackColor = System.Drawing.Color.DarkOrange;
            btnNhaCungCap.ForeColor = System.Drawing.Color.White;
            btnNhaCungCap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNhaCungCap.Click    += new System.EventHandler(btnNhaCungCap_Click);

            // BUTTON PHIẾU NHẬP
            btnPhieuNhap.Text      = "📦  Quản lý Phiếu Nhập";
            btnPhieuNhap.Location  = new System.Drawing.Point(80, 316);
            btnPhieuNhap.Size      = new System.Drawing.Size(360, 45);
            btnPhieuNhap.Font      = new System.Drawing.Font("Arial", 11);
            btnPhieuNhap.BackColor = System.Drawing.Color.Orange;
            btnPhieuNhap.ForeColor = System.Drawing.Color.White;
            btnPhieuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPhieuNhap.Click    += new System.EventHandler(btnPhieuNhap_Click);

            // === LABEL LUỒNG 3 ===
            var lbl3      = new System.Windows.Forms.Label();
            lbl3.Text     = "── SẢN PHẨM / NGUYÊN LIỆU / GIÁ ──";
            lbl3.Location = new System.Drawing.Point(30, 376);
            lbl3.Size     = new System.Drawing.Size(460, 24);
            lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl3.Font     = new System.Drawing.Font("Arial", 10,
                                System.Drawing.FontStyle.Bold);
            lbl3.ForeColor = System.Drawing.Color.DarkViolet;

            // BUTTON SẢN PHẨM
            btnSanPham.Text      = "🍽️  Quản lý Sản Phẩm";
            btnSanPham.Location  = new System.Drawing.Point(80, 409);
            btnSanPham.Size      = new System.Drawing.Size(110, 45);
            btnSanPham.Font      = new System.Drawing.Font("Arial", 10);
            btnSanPham.BackColor = System.Drawing.Color.MediumPurple;
            btnSanPham.ForeColor = System.Drawing.Color.White;
            btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSanPham.Click    += new System.EventHandler(btnSanPham_Click);

            // BUTTON NGUYÊN LIỆU
            btnNguyenLieu.Text      = "🌿  Nguyên Liệu";
            btnNguyenLieu.Location  = new System.Drawing.Point(205, 409);
            btnNguyenLieu.Size      = new System.Drawing.Size(110, 45);
            btnNguyenLieu.Font      = new System.Drawing.Font("Arial", 10);
            btnNguyenLieu.BackColor = System.Drawing.Color.SlateBlue;
            btnNguyenLieu.ForeColor = System.Drawing.Color.White;
            btnNguyenLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNguyenLieu.Click    += new System.EventHandler(btnNguyenLieu_Click);

            // BUTTON BẢNG GIÁ
            btnBangGia.Text      = "💰  Bảng Giá";
            btnBangGia.Location  = new System.Drawing.Point(330, 409);
            btnBangGia.Size      = new System.Drawing.Size(110, 45);
            btnBangGia.Font      = new System.Drawing.Font("Arial", 10);
            btnBangGia.BackColor = System.Drawing.Color.DarkSlateBlue;
            btnBangGia.ForeColor = System.Drawing.Color.White;
            btnBangGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBangGia.Click    += new System.EventHandler(btnBangGia_Click);

            // === BUTTON THOÁT ===
            btnThoat.Text      = "❌  Thoát";
            btnThoat.Location  = new System.Drawing.Point(190, 475);
            btnThoat.Size      = new System.Drawing.Size(150, 38);
            btnThoat.Font      = new System.Drawing.Font("Arial", 11);
            btnThoat.BackColor = System.Drawing.Color.Crimson;
            btnThoat.ForeColor = System.Drawing.Color.White;
            btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThoat.Click    += new System.EventHandler(btnThoat_Click);

            // === THÊM VÀO FORM ===
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTieuDe,
                lbl1, btnNhanVien, btnHoaDon,
                lbl2, btnNhaCungCap, btnPhieuNhap,
                lbl3, btnSanPham, btnNguyenLieu, btnBangGia,
                btnThoat
            });
        }

        private System.Windows.Forms.Label  lblTieuDe;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnNhaCungCap;
        private System.Windows.Forms.Button btnPhieuNhap;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnNguyenLieu;
        private System.Windows.Forms.Button btnBangGia;
        private System.Windows.Forms.Button btnThoat;
    }
}