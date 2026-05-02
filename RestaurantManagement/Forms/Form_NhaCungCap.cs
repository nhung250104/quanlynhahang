using System;
using System.Windows.Forms;

public partial class Form_NhaCungCap : Form
{
    private readonly NhaCungCapDAL _dal = new NhaCungCapDAL();
    private string _maNCCDangChon = null;

    public Form_NhaCungCap()
    {
        InitializeComponent();
    }

    private void Form_NhaCungCap_Load(object sender, EventArgs e) => LoadData();

    private void LoadData()
    {
        try
        {
            dgvNCC.DataSource = _dal.GetAll();
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
        var cols = new[]
        {
            ("MaNCC","Mã NCC"), ("TenNCC","Tên nhà cung cấp"),
            ("DiaChiNCC","Địa chỉ"), ("SDTNCC","Số điện thoại")
        };
        foreach (var (col, header) in cols)
            if (dgvNCC.Columns.Contains(col))
                dgvNCC.Columns[col].HeaderText = header;
        dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvNCC.ReadOnly = true;
        dgvNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var row = dgvNCC.Rows[e.RowIndex];
        _maNCCDangChon = row.Cells["MaNCC"].Value?.ToString();
        txtTenNCC.Text = row.Cells["TenNCC"].Value?.ToString();
        txtSDT.Text = row.Cells["SDTNCC"].Value?.ToString();
        txtDiaChi.Text = row.Cells["DiaChiNCC"].Value?.ToString();
        lblMaNCC.Text = "Mã NCC: " + _maNCCDangChon;
    }

    private void btnTimKiem_Click(object sender, EventArgs e)
    {
        dgvNCC.DataSource = string.IsNullOrWhiteSpace(txtTimKiem.Text)
            ? _dal.GetAll()
            : _dal.Search(txtTimKiem.Text.Trim());
        FormatGrid();
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTenNCC.Text) ||
            string.IsNullOrWhiteSpace(txtSDT.Text) ||
            string.IsNullOrWhiteSpace(txtDiaChi.Text))
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        try
        {
            _dal.Insert(txtTenNCC.Text.Trim(),
                        txtSDT.Text.Trim(),
                        txtDiaChi.Text.Trim());
            MessageBox.Show("Thêm nhà cung cấp thành công!", "Thành công",
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
        if (_maNCCDangChon == null)
        {
            MessageBox.Show("Chọn nhà cung cấp cần sửa.", "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        try
        {
            _dal.Update(_maNCCDangChon,
                        txtTenNCC.Text.Trim(),
                        txtSDT.Text.Trim(),
                        txtDiaChi.Text.Trim());
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
        if (_maNCCDangChon == null)
        {
            MessageBox.Show("Chọn nhà cung cấp cần xóa.", "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var cf = MessageBox.Show(
            $"Xóa nhà cung cấp '{txtTenNCC.Text}'?\n" +
            "Lưu ý: Sẽ lỗi nếu NCC đã có phiếu nhập liên kết.",
            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (cf != DialogResult.Yes) return;
        try
        {
            _dal.Delete(_maNCCDangChon);
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
        txtTenNCC.Clear(); txtSDT.Clear(); txtDiaChi.Clear();
        txtTimKiem.Clear();
        _maNCCDangChon = null;
        lblMaNCC.Text = "Mã NCC: (chưa chọn)";
        dgvNCC.ClearSelection();
    }
}