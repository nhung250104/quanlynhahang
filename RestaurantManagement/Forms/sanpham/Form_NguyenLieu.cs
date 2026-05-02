using System;
using System.Windows.Forms;
using System.Data;

namespace RestaurantManagement.sanpham
{
    public partial class Form_NguyenLieu : Form
    {
        private readonly NguyenLieuDAL _dal = new NguyenLieuDAL();
        private readonly string[] _dvtList = { "Kg", "Can", "Chai", "Bao", "Gói", "Hũ", "Tuýp", "Khay" };

        public Form_NguyenLieu()
        {
            InitializeComponent();
        }

        private void Form_NguyenLieu_Load(object sender, EventArgs e)
        {
            cboDVT.Items.AddRange(_dvtList);
            cboDVT.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvNguyenLieu.DataSource = _dal.GetAll();
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvNguyenLieu.Columns.Contains("MaNguyenLieu"))
                dgvNguyenLieu.Columns["MaNguyenLieu"].HeaderText = "Mã NL";
            if (dgvNguyenLieu.Columns.Contains("TenNguyenLieu"))
                dgvNguyenLieu.Columns["TenNguyenLieu"].HeaderText = "Tên nguyên liệu";
            if (dgvNguyenLieu.Columns.Contains("DVT"))
                dgvNguyenLieu.Columns["DVT"].HeaderText = "Đơn vị tính";
            dgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguyenLieu.ReadOnly = true;
            dgvNguyenLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtTenNL.Text = dgvNguyenLieu.Rows[e.RowIndex].Cells["TenNguyenLieu"].Value?.ToString();
            var dvt = dgvNguyenLieu.Rows[e.RowIndex].Cells["DVT"].Value?.ToString();
            if (dvt != null) cboDVT.SelectedItem = dvt;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvNguyenLieu.DataSource = string.IsNullOrWhiteSpace(txtTimKiem.Text)
                    ? _dal.GetAll()
                    : _dal.Search(txtTimKiem.Text.Trim());
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNL.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nguyên liệu.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _dal.Insert(txtTenNL.Text.Trim(), cboDVT.SelectedItem.ToString());
                MessageBox.Show("Thêm nguyên liệu thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKiemTraHSD_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = _dal.KiemTraHanSuDung();
                dgvNguyenLieu.DataSource = dt;
                dgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvNguyenLieu.ReadOnly = true;
                MessageBox.Show($"Tìm thấy {dt.Rows.Count} nguyên liệu sắp hết hạn hoặc đã hết hạn.",
                    "Kết quả kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadData();
        }

        private void LamMoi()
        {
            txtTenNL.Clear();
            txtTimKiem.Clear();
            cboDVT.SelectedIndex = 0;
            dgvNguyenLieu.ClearSelection();
        }
    }
}