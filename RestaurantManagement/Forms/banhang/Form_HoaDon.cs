using System;
using System.Windows.Forms;

namespace RestaurantManagement.banhang
{
    public partial class Form_HoaDon : Form
    {
        private readonly HoaDonDAL   _dalHD = new HoaDonDAL();
        private readonly NhanVienDAL _dalNV = new NhanVienDAL();
        private string _maHDDangChon = null;

        public Form_HoaDon()
        {
            InitializeComponent();
        }

        private void Form_HoaDon_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value    = DateTime.Today.AddMonths(-1);
            dtpDenNgay.Value   = DateTime.Today;
            chkLocNgay.Checked = false;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvHoaDon.DataSource = _dalHD.GetAll();
                FormatGrid();
                lblTongHD.Text = $"Tổng: {dgvHoaDon.Rows.Count} hóa đơn";
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
                ("MaHD","Mã HĐ"), ("TenNV","Nhân viên"),
                ("NgayBan","Ngày bán"), ("GioVao","Giờ vào"),
                ("GioRa","Giờ ra"), ("TongTienHang","Tiền hàng"),
                ("ChietKhau","Chiết khấu"), ("TongThanhToan","Tổng TT")
            };
            foreach (var (col, header) in cols)
                if (dgvHoaDon.Columns.Contains(col))
                    dgvHoaDon.Columns[col].HeaderText = header;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.ReadOnly    = true;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _maHDDangChon = dgvHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value?.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? tuNgay  = chkLocNgay.Checked ? dtpTuNgay.Value.Date  : (DateTime?)null;
                DateTime? denNgay = chkLocNgay.Checked ? dtpDenNgay.Value.Date : (DateTime?)null;
                dgvHoaDon.DataSource = _dalHD.Search(txtTimMaHD.Text.Trim(), tuNgay, denNgay);
                FormatGrid();
                lblTongHD.Text = $"Tổng: {dgvHoaDon.Rows.Count} hóa đơn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            var dsNV = _dalNV.GetAll();
            if (dsNV.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có nhân viên trong hệ thống!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new Form
            {
                Text          = "Chọn nhân viên",
                Width         = 320,
                Height        = 150,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox   = false
            };
            var lbl = new Label   { Text = "Nhân viên:", Left = 10,  Top = 20, Width = 80 };
            var cbo = new ComboBox
            {
                Left          = 100, Top = 16, Width = 180,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource    = dsNV,
                DisplayMember = "TenNV",
                ValueMember   = "MaNV"
            };
            var btn = new Button  { Text = "Tạo HĐ", Left = 100, Top = 60, Width = 100 };
            btn.Click += (s, ev) => { frm.DialogResult = DialogResult.OK; frm.Close(); };
            frm.Controls.AddRange(new Control[] { lbl, cbo, btn });

            if (frm.ShowDialog() != DialogResult.OK) return;

            try
            {
                string maNV = cbo.SelectedValue.ToString();
                string maHD = _dalHD.TaoHoaDon(maNV);
                var frmCT   = new Form_ChiTietHoaDon(maHD);
                frmCT.ShowDialog();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemCTHD_Click(object sender, EventArgs e)
        {
            if (_maHDDangChon == null)
            {
                MessageBox.Show("Chọn hóa đơn cần xem.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var frmCT = new Form_ChiTietHoaDon(_maHDDangChon);
            frmCT.ShowDialog();
            LoadData();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = _dalHD.BaoCaoTaiChinh(dtpTuNgay.Value, dtpDenNgay.Value);
                if (dt.Rows.Count == 0) return;

                var row     = dt.Rows[0];
                decimal dtt = Convert.ToDecimal(row["DoanhThu"]);
                decimal cp  = Convert.ToDecimal(row["ChiPhi"]);
                decimal ln  = Convert.ToDecimal(row["LoiNhuan"]);

                MessageBox.Show(
                    $"BÁO CÁO TÀI CHÍNH\n" +
                    $"Từ {dtpTuNgay.Value:dd/MM/yyyy} đến {dtpDenNgay.Value:dd/MM/yyyy}\n\n" +
                    $"Doanh thu  : {dtt:N0} đ\n" +
                    $"Chi phí    : {cp:N0} đ\n" +
                    $"Lợi nhuận : {ln:N0} đ",
                    "Báo cáo tài chính",
                    MessageBoxButtons.OK,
                    ln >= 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimMaHD.Clear();
            _maHDDangChon      = null;
            chkLocNgay.Checked = false;
            LoadData();
        }
    }
}