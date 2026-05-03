using System;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class Form_NhaCungCap : Form
    {
        private string _maNCCDangChon = null;

        public Form_NhaCungCap()
        {
            InitializeComponent();
        }

        private void Form_NhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();

            // Phân quyền UI
            if (DatabaseHelper.CurrentRole != "ADMIN")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        /* =====================================================
           LOAD DATA (PHÂN QUYỀN)
        ===================================================== */
        private void LoadData()
        {
            try
            {
                if (DatabaseHelper.CurrentRole == "ADMIN")
                    dgvNCC.DataSource = DatabaseHelper.GetNhaCungCapFull();
                else
                    dgvNCC.DataSource = DatabaseHelper.GetNhaCungCap();

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        /* =====================================================
           FORMAT GRID
        ===================================================== */
        private void FormatGrid()
        {
            var cols = new[]
            {
                ("MaNCC","Mã NCC"),
                ("TenNCC","Tên nhà cung cấp"),
                ("DiaChiNCC","Địa chỉ"),
                ("SDTNCC","Số điện thoại")
            };

            foreach (var col in cols)
            {
                if (dgvNCC.Columns.Contains(col.Item1))
                    dgvNCC.Columns[col.Item1].HeaderText = col.Item2;
            }

            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNCC.ReadOnly = true;
            dgvNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ẩn địa chỉ nếu không phải admin
            if (DatabaseHelper.CurrentRole != "ADMIN")
            {
                if (dgvNCC.Columns.Contains("DiaChiNCC"))
                    dgvNCC.Columns["DiaChiNCC"].Visible = false;
            }
        }

        /* =====================================================
           CLICK GRID
        ===================================================== */
        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvNCC.Rows[e.RowIndex];

            _maNCCDangChon = row.Cells["MaNCC"].Value?.ToString();
            txtTenNCC.Text = row.Cells["TenNCC"].Value?.ToString();
            txtSDT.Text = row.Cells["SDTNCC"].Value?.ToString();

            if (dgvNCC.Columns.Contains("DiaChiNCC"))
                txtDiaChi.Text = row.Cells["DiaChiNCC"].Value?.ToString();

            lblMaNCC.Text = "Mã NCC: " + _maNCCDangChon;
        }

        /* =====================================================
           TÌM KIẾM
        ===================================================== */
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                LoadData();
                return;
            }

            dgvNCC.DataSource = DatabaseHelper.TimNhaCungCap(txtTimKiem.Text.Trim());
            FormatGrid();
        }

        /* =====================================================
           THÊM
        ===================================================== */
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            bool ok = DatabaseHelper.ThemNhaCungCap(
                txtTenNCC.Text.Trim(),
                txtSDT.Text.Trim(),
                txtDiaChi.Text.Trim()
            );

            if (ok)
            {
                MessageBox.Show("Thêm thành công!");
                LoadData();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        /* =====================================================
           SỬA (TẠM KHÓA)
        ===================================================== */
        private void btnSua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa hỗ trợ sửa (cần SP UPDATE).");
        }

        /* =====================================================
           XÓA (TẠM KHÓA)
        ===================================================== */
        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa hỗ trợ xóa (cần SP DELETE).");
        }

        /* =====================================================
           LÀM MỚI
        ===================================================== */
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtTenNCC.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtTimKiem.Clear();

            _maNCCDangChon = null;
            lblMaNCC.Text = "Mã NCC: (chưa chọn)";

            dgvNCC.ClearSelection();
        }
    }
}