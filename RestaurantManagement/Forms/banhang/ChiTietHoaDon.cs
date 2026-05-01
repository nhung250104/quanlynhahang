using System;
using System.Data;
using System.Windows.Forms;

namespace RestaurantManagement.banhang
{
    public partial class Form_ChiTietHoaDon : Form
    {
        private readonly ChiTietHoaDonDAL _dalCT = new ChiTietHoaDonDAL();
        private readonly HoaDonDAL        _dalHD = new HoaDonDAL();
        private readonly string           _maHD;
        private string  _maSPDangChon    = null;
        private decimal _donGiaDangChon  = 0;

        public Form_ChiTietHoaDon(string maHD)
        {
            InitializeComponent();
            _maHD = maHD;
        }

        private void Form_ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            lblMaHD.Text      = "Hóa đơn: " + _maHD;
            txtSoLuong.Text   = "1";
            txtChietKhau.Text = "0";
            LoadSanPham();
            LoadChiTiet();
        }

        private void LoadSanPham()
        {
            dgvSanPham.DataSource = _dalCT.GetSanPhamCoGia();
            if (dgvSanPham.Columns.Contains("MaSP"))
                dgvSanPham.Columns["MaSP"].HeaderText = "Mã SP";
            if (dgvSanPham.Columns.Contains("TenSP"))
                dgvSanPham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            if (dgvSanPham.Columns.Contains("GiaHienThi"))
                dgvSanPham.Columns["GiaHienThi"].HeaderText = "Đơn giá";
            if (dgvSanPham.Columns.Contains("DonGiaBan"))
                dgvSanPham.Columns["DonGiaBan"].Visible = false;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.ReadOnly    = true;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadChiTiet()
        {
            dgvChiTiet.DataSource = _dalCT.GetByHoaDon(_maHD);
            if (dgvChiTiet.Columns.Contains("MaSP"))
                dgvChiTiet.Columns["MaSP"].HeaderText = "Mã SP";
            if (dgvChiTiet.Columns.Contains("TenSP"))
                dgvChiTiet.Columns["TenSP"].HeaderText = "Tên món";
            if (dgvChiTiet.Columns.Contains("SoLuong"))
                dgvChiTiet.Columns["SoLuong"].HeaderText = "SL";
            if (dgvChiTiet.Columns.Contains("ThanhTien"))
            {
                dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.ReadOnly    = true;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TinhTongTien();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row         = dgvSanPham.Rows[e.RowIndex];
            _maSPDangChon   = row.Cells["MaSP"].Value?.ToString();
            _donGiaDangChon = Convert.ToDecimal(row.Cells["DonGiaBan"].Value);
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (_maSPDangChon == null)
            {
                MessageBox.Show("Chọn sản phẩm bên danh sách trái.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtSoLuong.Text, out int sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _dalCT.ThemChiTiet(_maHD, _maSPDangChon, sl, _donGiaDangChon);
                LoadChiTiet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm món: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null) return;
            string maSP = dgvChiTiet.CurrentRow.Cells["MaSP"].Value?.ToString();
            if (maSP == null) return;

            var cf = MessageBox.Show("Xóa món này khỏi hóa đơn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cf != DialogResult.Yes) return;
            try
            {
                _dalCT.XoaChiTiet(_maHD, maSP);
                LoadChiTiet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtChietKhau.Text, out decimal ck) || ck < 0)
            {
                MessageBox.Show("Chiết khấu không hợp lệ.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _dalHD.CapNhatTongTien(_maHD, ck);
                MessageBox.Show(
                    $"Lưu hóa đơn {_maHD} thành công!\nTổng: {lblTongTien.Text}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            var dt = dgvChiTiet.DataSource as DataTable;
            if (dt != null)
                foreach (DataRow row in dt.Rows)
                    if (decimal.TryParse(row["ThanhTien"].ToString(), out decimal val))
                        tong += val;
            lblTongTien.Text = "Tổng: " + tong.ToString("N0") + " đ";
        }

        private void txtChietKhau_TextChanged(object sender, EventArgs e) => TinhTongTien();

        private void btnDong_Click(object sender, EventArgs e) => this.Close();
    }
}