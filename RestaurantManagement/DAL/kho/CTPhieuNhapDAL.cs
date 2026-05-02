using Microsoft.Data.SqlClient;
using System.Data;

public class CTPhieuNhapDAL
{
    // Lấy chi tiết của 1 phiếu nhập
    public DataTable GetByPhieuNhap(string maPN)
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            @"SELECT ct.MaNguyenLieu, nl.TenNguyenLieu, nl.DVT,
                     ct.SLN,
                     FORMAT(ct.DonGiaNhap,'N0') + N' đ'  AS DonGiaNhap,
                     FORMAT(ct.ThanhTien, 'N0') + N' đ'  AS ThanhTien,
                     CONVERT(VARCHAR,ct.NSX,103)          AS NSX,
                     CONVERT(VARCHAR,ct.HSD,103)          AS HSD
              FROM CTPHIEUNHAP ct
              JOIN NGUYENLIEU nl ON nl.MaNguyenLieu = ct.MaNguyenLieu
              WHERE ct.MaPN = @MaPN", conn);
        da.SelectCommand.Parameters.AddWithValue("@MaPN", maPN);
        da.Fill(dt);
        return dt;
    }

    // Load danh sách nguyên liệu để chọn khi nhập
    public DataTable GetNguyenLieuForComboBox()
    {
        var dt = new DataTable();
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var da = new SqlDataAdapter(
            "SELECT MaNguyenLieu, TenNguyenLieu, DVT FROM NGUYENLIEU ORDER BY TenNguyenLieu",
            conn);
        da.Fill(dt);
        return dt;
    }

    // Thêm nguyên liệu vào phiếu nhập
    // Gọi SP_KIEMTRA_HANSUDUNG trước khi insert
    public string ThemChiTiet(string maPN, string maNL, int sln,
                              decimal donGia, DateTime nsx, DateTime hsd)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();

        // Bước 1: Kiểm tra hạn sử dụng qua SP có sẵn
        var messages = new System.Text.StringBuilder();
        conn.InfoMessage += (s, e) => messages.AppendLine(e.Message);
        conn.FireInfoMessageEventOnUserErrors = true;

        var cmdKT = new SqlCommand("SP_KIEMTRA_HANSUDUNG", conn);
        cmdKT.CommandType = CommandType.StoredProcedure;
        cmdKT.Parameters.AddWithValue("@MaHH", maNL);
        cmdKT.Parameters.AddWithValue("@NgaySX", nsx.Date);
        cmdKT.Parameters.AddWithValue("@HanSuDung", hsd.Date);
        cmdKT.ExecuteNonQuery();

        string msg = messages.ToString();
        // Nếu SP báo lỗi thì dừng
        if (msg.Contains("Lỗi") || msg.Contains("lỗi"))
            return msg.Trim();

        // Bước 2: Kiểm tra đã có nguyên liệu này trong phiếu chưa
        var cmdCheck = new SqlCommand(
            "SELECT COUNT(1) FROM CTPHIEUNHAP WHERE MaPN=@MaPN AND MaNguyenLieu=@MaNL",
            conn);
        cmdCheck.Parameters.AddWithValue("@MaPN", maPN);
        cmdCheck.Parameters.AddWithValue("@MaNL", maNL);
        bool exists = (int)cmdCheck.ExecuteScalar() > 0;

        if (exists)
        {
            // Cộng dồn số lượng
            var cmdUp = new SqlCommand(
                @"UPDATE CTPHIEUNHAP
                  SET SLN       = SLN + @SLN,
                      ThanhTien = (SLN + @SLN) * DonGiaNhap
                  WHERE MaPN=@MaPN AND MaNguyenLieu=@MaNL", conn);
            cmdUp.Parameters.AddWithValue("@SLN", sln);
            cmdUp.Parameters.AddWithValue("@MaPN", maPN);
            cmdUp.Parameters.AddWithValue("@MaNL", maNL);
            cmdUp.ExecuteNonQuery();
        }
        else
        {
            var cmd = new SqlCommand(
                @"INSERT INTO CTPHIEUNHAP
                    (MaPN, MaNguyenLieu, SLN, DonGiaNhap, ThanhTien, NSX, HSD)
                  VALUES
                    (@MaPN, @MaNL, @SLN, @DonGia, @ThanhTien, @NSX, @HSD)", conn);
            cmd.Parameters.AddWithValue("@MaPN", maPN);
            cmd.Parameters.AddWithValue("@MaNL", maNL);
            cmd.Parameters.AddWithValue("@SLN", sln);
            cmd.Parameters.AddWithValue("@DonGia", donGia);
            cmd.Parameters.AddWithValue("@ThanhTien", sln * donGia);
            cmd.Parameters.AddWithValue("@NSX", nsx.Date);
            cmd.Parameters.AddWithValue("@HSD", hsd.Date);
            cmd.ExecuteNonQuery();
        }

        return "OK";
    }

    public bool XoaChiTiet(string maPN, string maNL)
    {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        var cmd = new SqlCommand(
            "DELETE FROM CTPHIEUNHAP WHERE MaPN=@MaPN AND MaNguyenLieu=@MaNL", conn);
        cmd.Parameters.AddWithValue("@MaPN", maPN);
        cmd.Parameters.AddWithValue("@MaNL", maNL);
        return cmd.ExecuteNonQuery() > 0;
    }
}