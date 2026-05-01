using System;
using System.Windows.Forms;

namespace RestaurantManagement.banhang
{
    public partial class Form_NhanVien : Form
    {
        private readonly NhanVienDAL _dal = new NhanVienDAL();
        private string _maNVDangChon = null;

        public Form_NhanVien()
        {
            InitializeComponent();
        }

        private void Form_NhanVien_Load(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            try
            {
                dgvNhanVien.DataSource = _dal.GetAll();
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvNhanVien.Columns.Contains("MaNV"))
                dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
            if (dgvNhanVien.Columns.Contains("TenNV"))
                dgvNhanVien.Columns["TenNV"].HeaderText = "Tên nhân viên";
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvNhanVien.Rows[e.RowIndex];
            _maNVDangChon = row.Cells["MaNV"].Value?.ToString();
            txtTenNV.Text = row.Cells["TenNV"].Value?.ToString();
            lblMaNV.Text  = "Mã NV: " + _maNVDangChon;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = string.IsNullOrWhiteSpace(txtTimKiem.Text)
                ? _dal.GetAll() : _dal.Search(txtTimKiem.Text.Trim());
            FormatGrid();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Nhập tên nhân viên.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _dal.Insert(txtTenNV.Text.Trim());
                MessageBox.Show("Thêm nhân viên thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maNVDangChon == null)
            {
                MessageBox.Show("Chọn nhân viên cần sửa.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _dal.Update(_maNVDangChon, txtTenNV.Text.Trim());
                MessageBox.Show("Cập nhật thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maNVDangChon == null)
            {
                MessageBox.Show("Chọn nhân viên cần xóa.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var cf = MessageBox.Show($"Xóa nhân viên '{txtTenNV.Text}'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cf != DialogResult.Yes) return;
            try
            {
                _dal.Delete(_maNVDangChon);
                MessageBox.Show("Xóa thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => LamMoi();

        private void LamMoi()
        {
            txtTenNV.Clear();
            txtTimKiem.Clear();
            _maNVDangChon = null;
            lblMaNV.Text  = "Mã NV: (chưa chọn)";
            dgvNhanVien.ClearSelection();
        }
    }
}