namespace RestaurantManagement
{
    partial class Form_Login
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
            txtUsername    = new System.Windows.Forms.TextBox();
            txtPassword    = new System.Windows.Forms.TextBox();
            btnDangNhap    = new System.Windows.Forms.Button();
            btnThoat       = new System.Windows.Forms.Button();

            // === FORM ===
            this.Text            = "Đăng nhập hệ thống";
            this.Size            = new System.Drawing.Size(400, 280);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.BackColor       = System.Drawing.Color.White;
            this.Load           += new System.EventHandler((s, e) => txtUsername.Focus());

            // === TIÊU ĐỀ ===
            var lblTitle = new System.Windows.Forms.Label();
            lblTitle.Text      = "🏠 NHÀ HÀNG 369";
            lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            lblTitle.Location  = new System.Drawing.Point(80, 20);
            lblTitle.Size      = new System.Drawing.Size(250, 40);
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // === USERNAME ===
            var lblUser = new System.Windows.Forms.Label();
            lblUser.Text     = "Tên đăng nhập:";
            lblUser.Location = new System.Drawing.Point(30, 80);
            lblUser.Size     = new System.Drawing.Size(120, 23);

            txtUsername.Location    = new System.Drawing.Point(155, 77);
            txtUsername.Size        = new System.Drawing.Size(200, 23);
            txtUsername.PlaceholderText = "ChuCuaHang / NhanVien";

            // === PASSWORD ===
            var lblPass = new System.Windows.Forms.Label();
            lblPass.Text     = "Mật khẩu:";
            lblPass.Location = new System.Drawing.Point(30, 120);
            lblPass.Size     = new System.Drawing.Size(120, 23);

            txtPassword.Location     = new System.Drawing.Point(155, 117);
            txtPassword.Size         = new System.Drawing.Size(200, 23);
            txtPassword.PasswordChar = '*';
            txtPassword.KeyDown     += new System.Windows.Forms.KeyEventHandler(txtPassword_KeyDown);

            // === BUTTONS ===
            btnDangNhap.Text      = "Đăng nhập";
            btnDangNhap.Location  = new System.Drawing.Point(80, 170);
            btnDangNhap.Size      = new System.Drawing.Size(110, 35);
            btnDangNhap.BackColor = System.Drawing.Color.SeaGreen;
            btnDangNhap.ForeColor = System.Drawing.Color.White;
            btnDangNhap.Font      = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            btnDangNhap.Click    += new System.EventHandler(btnDangNhap_Click);

            btnThoat.Text      = "Thoát";
            btnThoat.Location  = new System.Drawing.Point(210, 170);
            btnThoat.Size      = new System.Drawing.Size(110, 35);
            btnThoat.BackColor = System.Drawing.Color.Crimson;
            btnThoat.ForeColor = System.Drawing.Color.White;
            btnThoat.Font      = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            btnThoat.Click    += new System.EventHandler(btnThoat_Click);

            // === THÊM VÀO FORM ===
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitle, lblUser, txtUsername,
                lblPass, txtPassword,
                btnDangNhap, btnThoat
            });
        }

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button  btnDangNhap;
        private System.Windows.Forms.Button  btnThoat;
    }
}