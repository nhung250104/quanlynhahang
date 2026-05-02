using System;
using System.Windows.Forms;
using System.Data;

namespace RestaurantManagement.sanpham
{
    public partial class Form_SanPham : Form
    {
        private readonly SanPhamDAL _dal = new SanPhamDAL();

        public Form_SanPham()
        {
            InitializeComponent();
        }

        private void Form_SanPham_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpDenNgay.Value = DateTime.Today;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvSanPham.DataSource = _dal.GetAll();
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
            if (dgvSanPham.Columns.Contains("MaSP"))
                dgvSanPham.Columns["MaSP"].HeaderText = "Mã SP";
            if (dgvSanPham.Columns.Contains("TenSP"))
                dgvSanPham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.ReadOnly = true;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtTenSP.Text = dgvSanPham.Rows[e.RowIndex].Cells["TenSP"].Value?.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSanPham.DataSource = string.IsNullOrWhiteSpace(txtTimKiem.Text)
                    ? _dal.GetAll()
                    : _dal.Search(txtTimKiem.Text.Trim());
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _dal.Insert(txtTenSP.Text.Trim());
                MessageBox.Show("Thêm sản phẩm thành công!", "Thành công",
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

        private void btnTopBanChay_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = _dal.GetTopBanChay(dtpTuNgay.Value, dtpDenNgay.Value);
                dgvSanPham.DataSource = dt;
                if (dgvSanPham.Columns.Contains("MaSP"))
                    dgvSanPham.Columns["MaSP"].HeaderText = "Mã SP";
                if (dgvSanPham.Columns.Contains("TenSP"))
                    dgvSanPham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                if (dgvSanPham.Columns.Contains("TongSoLuong"))
                    dgvSanPham.Columns["TongSoLuong"].HeaderText = "Tổng SL bán";
                dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSanPham.ReadOnly = true;
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
            txtTenSP.Clear();
            txtTimKiem.Clear();
            dgvSanPham.ClearSelection();
        }
    }
}