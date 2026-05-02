using System;
using System.Data;
using System.Windows.Forms;

public partial class Form_CTPhieuNhap : Form
{
    private readonly CTPhieuNhapDAL _dalCT = new CTPhieuNhapDAL();
    private readonly PhieuNhapDAL _dalPN = new PhieuNhapDAL();
    private readonly string _maPN;

    private string _maNLDangChon = null;

    public Form_CTPhieuNhap(string maPN)
    {
        InitializeComponent();
        _maPN = maPN;
    }

    private void Form_CTPhieuNhap_Load(object sender, EventArgs e)
    {
        lblMaPN.Text = "Phiếu nhập: " + _maPN;
        nudSoLuong.Value = 1;
        dtpNSX.Value = DateTime.Today.AddDays(-1);
        dtpHSD.Value = DateTime.Today.AddDays(90);

        LoadNguyenLieu();
        LoadChiTiet();
    }

    private void LoadNguyenLieu()
    {
        dgvNguyenLieu.DataSource = _dalCT.GetNguyenLieuForComboBox();
        var cols = new[]
        {
            ("MaNguyenLieu","Mã NL"),
            ("TenNguyenLieu","Tên nguyên liệu"),
            ("DVT","ĐVT")
        };
        foreach (var (col, h) in cols)
            if (dgvNguyenLieu.Columns.Contains(col))
                dgvNguyenLieu.Columns[col].HeaderText = h;
        dgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvNguyenLieu.ReadOnly = true;
        dgvNguyenLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    private void LoadChiTiet()
    {
        dgvChiTiet.DataSource = _dalCT.GetByPhieuNhap(_maPN);
        var cols = new[]
        {
            ("MaNguyenLieu","Mã NL"), ("TenNguyenLieu","Tên NL"),
            ("DVT","ĐVT"), ("SLN","Số lượng"),
            ("DonGiaNhap","Đơn giá"), ("ThanhTien","Thành tiền"),
            ("NSX","Ngày SX"), ("HSD","Hạn SD")
        };
        foreach (var (col, h) in cols)
            if (dgvChiTiet.Columns.Contains(col))
                dgvChiTiet.Columns[col].HeaderText = h;
        dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvChiTiet.ReadOnly = true;
        dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        TinhTongTien();
    }

    // Click chọn NL bên trái để điền vào form nhập
    private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        _maNLDangChon = dgvNguyenLieu.Rows[e.RowIndex]
                            .Cells["MaNguyenLieu"].Value?.ToString();
    }

    private void btnThemNL_Click(object sender, EventArgs e)
    {
        if (_maNLDangChon == null)
        {
            MessageBox.Show("Chọn nguyên liệu từ danh sách bên trái.", "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
        {
            MessageBox.Show("Đơn giá phải là số dương.", "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (dtpNSX.Value.Date >= dtpHSD.Value.Date)
        {
            MessageBox.Show("Hạn sử dụng phải lớn hơn ngày sản xuất.", "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        try
        {
            string ketQua = _dalCT.ThemChiTiet(
                _maPN, _maNLDangChon,
                (int)nudSoLuong.Value, donGia,
                dtpNSX.Value, dtpHSD.Value);

            if (ketQua != "OK")
            {
                // SP_KIEMTRA_HANSUDUNG báo lỗi
                MessageBox.Show(ketQua, "Không thể nhập kho",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật tổng tiền phiếu nhập
            _dalPN.CapNhatTongTien(_maPN);
            LoadChiTiet();
            LamMoiNhapLieu();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnXoaNL_Click(object sender, EventArgs e)
    {
        if (dgvChiTiet.CurrentRow == null) return;
        string maNL = dgvChiTiet.CurrentRow.Cells["MaNguyenLieu"].Value?.ToString();
        if (maNL == null) return;

        var cf = MessageBox.Show("Xóa nguyên liệu này khỏi phiếu nhập?", "Xác nhận",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (cf != DialogResult.Yes) return;
        try
        {
            _dalCT.XoaChiTiet(_maPN, maNL);
            _dalPN.CapNhatTongTien(_maPN);
            LoadChiTiet();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Lưu phiếu nhập — cập nhật lại tổng tiền lần cuối
    private void btnLuuPN_Click(object sender, EventArgs e)
    {
        if (dgvChiTiet.Rows.Count == 0)
        {
            MessageBox.Show("Phiếu nhập chưa có nguyên liệu nào!", "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        try
        {
            _dalPN.CapNhatTongTien(_maPN);
            MessageBox.Show(
                $"Lưu phiếu nhập {_maPN} thành công!\n" +
                $"Tổng tiền: {lblTongTien.Text}",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi lưu: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Tính tổng tiền real-time từ lưới chi tiết
    private void TinhTongTien()
    {
        decimal tong = 0;
        var dt = dgvChiTiet.DataSource as DataTable;
        if (dt != null)
            foreach (DataRow row in dt.Rows)
            {
                var raw = row["ThanhTien"].ToString()
                           .Replace(" đ", "").Replace(",", "").Trim();
                if (decimal.TryParse(raw, out decimal val))
                    tong += val;
            }
        lblTongTien.Text = "Tổng: " + tong.ToString("N0") + " đ";
    }

    private void LamMoiNhapLieu()
    {
        _maNLDangChon = null;
        txtDonGia.Clear();
        nudSoLuong.Value = 1;
        dtpNSX.Value = DateTime.Today.AddDays(-1);
        dtpHSD.Value = DateTime.Today.AddDays(90);
        dgvNguyenLieu.ClearSelection();
    }

    private void btnDong_Click(object sender, EventArgs e) => this.Close();
}