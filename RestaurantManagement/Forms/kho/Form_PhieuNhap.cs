using System;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class Form_PhieuNhap : Form
    {
        private readonly PhieuNhapDAL  _dalPN  = new PhieuNhapDAL();
        private readonly NhaCungCapDAL _dalNCC = new NhaCungCapDAL();
        private string _maPNDangChon = null;

        public Form_PhieuNhap()
        {
            InitializeComponent();
        }

        private void Form_PhieuNhap_Load(object sender, EventArgs e)
        {
            var dsNCC   = _dalNCC.GetForComboBox();
            var rowAll  = dsNCC.NewRow();
            rowAll["MaNCC"]  = "";
            rowAll["TenNCC"] = "-- Tất cả --";
            dsNCC.Rows.InsertAt(rowAll, 0);

            cboNCC.DataSource    = dsNCC;
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember   = "MaNCC";
            cboNCC.SelectedIndex = 0;

            dtpTuNgay.Value    = DateTime.Today.AddMonths(-1);
            dtpDenNgay.Value   = DateTime.Today;
            dtpThoiHanTT.Value = DateTime.Today.AddDays(30);
            nudVAT.Value       = 10;
            chkLocNgay.Checked = false;

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvPhieuNhap.DataSource = _dalPN.GetAll();
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
            var cols = new[]
            {
                ("MaPN","Mã PN"), ("TenNCC","Nhà cung cấp"),
                ("NgayNK","Ngày nhập"), ("ThoiHanTT","Hạn TT"),
                ("VAT","VAT %"), ("TamTinh","Tạm tính"),
                ("TongTien","Tổng tiền"), ("GhiChu","Ghi chú")
            };
            foreach (var (col, header) in cols)
                if (dgvPhieuNhap.Columns.Contains(col))
                    dgvPhieuNhap.Columns[col].HeaderText = header;
            dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuNhap.ReadOnly    = true;
            dgvPhieuNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _maPNDangChon = dgvPhieuNhap.Rows[e.RowIndex].Cells["MaPN"].Value?.ToString();
            lblMaPN.Text  = "Mã PN: " + _maPNDangChon;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string maNCC      = cboNCC.SelectedValue?.ToString();
                DateTime? tuNgay  = chkLocNgay.Checked ? dtpTuNgay.Value.Date  : (DateTime?)null;
                DateTime? denNgay = chkLocNgay.Checked ? dtpDenNgay.Value.Date : (DateTime?)null;

                dgvPhieuNhap.DataSource = _dalPN.Search(
                    txtTimMaPN.Text.Trim(),
                    string.IsNullOrEmpty(maNCC) ? null : maNCC,
                    tuNgay, denNgay);
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaoPN_Click(object sender, EventArgs e)
        {
            string maNCC = cboNCC.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maNCC))
            {
                MessageBox.Show("Chọn nhà cung cấp để tạo phiếu nhập.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                decimal  vat      = nudVAT.Value;
                string   ghiChu   = txtGhiChu.Text.Trim();
                DateTime thoiHan  = dtpThoiHanTT.Value;

                string maPN = _dalPN.TaoPhieuNhap(maNCC, vat, ghiChu, thoiHan);
                MessageBox.Show($"Tạo phiếu nhập {maPN} thành công!\nMở để nhập chi tiết...",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var frmCT = new Form_CTPhieuNhap(maPN);
                frmCT.ShowDialog();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo phiếu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemCT_Click(object sender, EventArgs e)
        {
            if (_maPNDangChon == null)
            {
                MessageBox.Show("Chọn phiếu nhập cần xem.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var frmCT = new Form_CTPhieuNhap(_maPNDangChon);
            frmCT.ShowDialog();
            LoadData();
        }

        private void btnSoSanhGia_Click(object sender, EventArgs e)
        {
            try
            {
                string maNCC      = cboNCC.SelectedValue?.ToString();
                DateTime? tuNgay  = chkLocNgay.Checked ? dtpTuNgay.Value.Date  : (DateTime?)null;
                DateTime? denNgay = chkLocNgay.Checked ? dtpDenNgay.Value.Date : (DateTime?)null;

                var dt = _dalPN.SoSanhGia(
                    null,
                    string.IsNullOrEmpty(maNCC) ? null : maNCC,
                    tuNgay, denNgay);

                var frmSS = new Form
                {
                    Text          = "So sánh giá nguyên liệu",
                    Width         = 900,
                    Height        = 500,
                    StartPosition = FormStartPosition.CenterParent
                };
                var dgv = new DataGridView
                {
                    Dock            = DockStyle.Fill,
                    DataSource      = dt,
                    ReadOnly        = true,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };
                dgv.DataBindingComplete += (s, ev) =>
                {
                    var headers = new[]
                    {
                        ("MaNguyenLieu","Mã NL"), ("TenNguyenLieu","Tên nguyên liệu"),
                        ("MaNCC","Mã NCC"), ("TenNCC","Nhà cung cấp"),
                        ("DonGiaNhap","Đơn giá nhập"), ("NgayNK","Ngày nhập")
                    };
                    foreach (var (col, h) in headers)
                        if (dgv.Columns.Contains(col))
                            dgv.Columns[col].HeaderText = h;
                };
                frmSS.Controls.Add(dgv);
                frmSS.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimMaPN.Clear();
            txtGhiChu.Clear();
            _maPNDangChon      = null;
            lblMaPN.Text       = "Mã PN: (chưa chọn)";
            cboNCC.SelectedIndex = 0;
            chkLocNgay.Checked = false;
            nudVAT.Value       = 10;
            dtpThoiHanTT.Value = DateTime.Today.AddDays(30);
            LoadData();
        }
    }
}