using System;
using System.Windows.Forms;
using System.Data;

namespace RestaurantManagement.Forms.sanpham
{
    public partial class Form_BangGia : Form
    {
        private readonly BangGiaDAL _dal = new BangGiaDAL();

        public Form_BangGia()
        {
            InitializeComponent();
        }

        private void Form_BangGia_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            dtpNgayBD.Value = DateTime.Today;
            dtpNgayKT.Value = DateTime.Today;
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpDenNgay.Value = DateTime.Today;
            LoadBangGia();
        }

        private void LoadSanPham()
        {
            try
            {
                var dt = _dal.GetSanPham();
                cboSanPham.DataSource = dt;
                cboSanPham.DisplayMember = "TenSP";
                cboSanPham.ValueMember = "MaSP";

                cboSanPhamKT.DataSource = _dal.GetSanPham();
                cboSanPhamKT.DisplayMember = "TenSP";
                cboSanPhamKT.ValueMember = "MaSP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBangGia()
        {
            try
            {
                dgvBangGia.DataSource = _dal.GetAll();
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bảng giá: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvBangGia.Columns.Contains("MaGia"))
                dgvBangGia.Columns["MaGia"].HeaderText = "Mã giá";
            if (dgvBangGia.Columns.Contains("TenSP"))
                dgvBangGia.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            if (dgvBangGia.Columns.Contains("DonGiaBan"))
                dgvBangGia.Columns["DonGiaBan"].HeaderText = "Đơn giá (VNĐ)";
            if (dgvBangGia.Columns.Contains("NgayBD"))
                dgvBangGia.Columns["NgayBD"].HeaderText = "Ngày bắt đầu";
            if (dgvBangGia.Columns.Contains("NgayKT"))
                dgvBangGia.Columns["NgayKT"].HeaderText = "Ngày kết thúc";
            if (dgvBangGia.Columns.Contains("TrangThai"))
                dgvBangGia.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvBangGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBangGia.ReadOnly = true;
            dgvBangGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnThemGia_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ. Phải là số dương.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _dal.ThemGiaMoi(cboSanPham.SelectedValue.ToString(), donGia, dtpNgayBD.Value);
                MessageBox.Show("Thêm giá mới thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBangGia();
                txtDonGia.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatNgayKT_Click(object sender, EventArgs e)
        {
            if (cboSanPhamKT.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _dal.CapNhatNgayKetThuc(cboSanPhamKT.SelectedValue.ToString(), dtpNgayKT.Value);
                MessageBox.Show("Cập nhật ngày kết thúc thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBangGia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = _dal.BaoCaoTaiChinh(dtpTuNgay.Value, dtpDenNgay.Value);
                dgvBangGia.DataSource = dt;
                dgvBangGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBangGia.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDonGia.Clear();
            dtpNgayBD.Value = DateTime.Today;
            LoadBangGia();
        }
    }
}