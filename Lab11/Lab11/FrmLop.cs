using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyLop
{
    public partial class FrmLop : Form
    {
        public FrmLop()
        {
            InitializeComponent();
        }

        // ================= F1: tự động load khi mở Form =================
        private void FrmLop_Load(object sender, EventArgs e)
        {
            CauHinhLuoi();
            TaiDuLieu();
        }

        private void CauHinhLuoi()
        {
            dgvLop.ReadOnly = true;
            dgvLop.AllowUserToAddRows = false;
            dgvLop.AllowUserToDeleteRows = false;
            dgvLop.MultiSelect = false;
            dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLop.RowHeadersVisible = false;
        }

        // ================= Các hàm hỗ trợ =================
        private void TaiDuLieu()
        {
            try
            {
                dgvLop.DataSource = LopRepository.LayTatCa();
                DatTieuDeCot();
            }
            catch (SqlException ex)
            {
                HienLoi("Không thể tải dữ liệu từ SQL Server.", ex);
            }
        }

        private void DatTieuDeCot()
        {
            if (dgvLop.Columns.Contains("MaLop")) dgvLop.Columns["MaLop"].HeaderText = "Mã lớp";
            if (dgvLop.Columns.Contains("TenLop")) dgvLop.Columns["TenLop"].HeaderText = "Tên lớp";
        }

        private void XoaONhap()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtMaLop.ReadOnly = false;
            txtMaLop.Focus();
        }

        private static void HienLoi(string thongDiep, SqlException ex)
        {
            MessageBox.Show($"{thongDiep}\n\nChi tiết: {ex.Message}", "Lỗi SQL Server",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CanhBao(string noiDung) =>
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static void ThongTin(string noiDung) =>
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // ================= F2: chọn dòng -> đưa lên TextBox =================
        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvLop.Rows[e.RowIndex];
            txtMaLop.Text = Convert.ToString(row.Cells["MaLop"].Value);
            txtTenLop.Text = Convert.ToString(row.Cells["TenLop"].Value);
            txtMaLop.ReadOnly = true;   // khóa mã lớp để không sửa khóa chính
        }

        // ================= F3: Thêm =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();

            string loi = LopRepository.KiemTraDuLieu(ma, ten);
            if (loi != null) { CanhBao(loi); return; }

            try
            {
                if (LopRepository.TonTai(ma))
                {
                    CanhBao($"Mã lớp \"{ma}\" đã tồn tại.");
                    txtMaLop.Focus();
                    return;
                }

                LopRepository.Them(ma, ten);
                ThongTin("Thêm lớp thành công.");
                XoaONhap();
                TaiDuLieu();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                CanhBao($"Mã lớp \"{ma}\" đã tồn tại.");
            }
            catch (SqlException ex)
            {
                HienLoi("Không thể thêm lớp.", ex);
            }
        }

        // ================= F4: Sửa =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();

            // Chưa chọn lớp từ lưới => mã lớp đang mở khóa/rỗng
            if (!txtMaLop.ReadOnly || ma.Length == 0)
            {
                CanhBao("Vui lòng chọn một lớp trong danh sách trước khi sửa.");
                return;
            }

            string loi = LopRepository.KiemTraDuLieu(ma, ten);
            if (loi != null) { CanhBao(loi); return; }

            try
            {
                int soDong = LopRepository.Sua(ma, ten);
                if (soDong == 0)
                {
                    CanhBao("Không tìm thấy lớp để cập nhật (có thể đã bị xóa).");
                }
                else
                {
                    ThongTin("Cập nhật lớp thành công.");
                    XoaONhap();
                }
                TaiDuLieu();
            }
            catch (SqlException ex)
            {
                HienLoi("Không thể cập nhật lớp.", ex);
            }
        }

        // ================= F5: Xóa =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text.Trim();
            if (!txtMaLop.ReadOnly || ma.Length == 0)
            {
                CanhBao("Vui lòng chọn một lớp trong danh sách trước khi xóa.");
                return;
            }

            var hoi = MessageBox.Show($"Bạn có chắc muốn xóa lớp \"{ma}\"?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (hoi != DialogResult.Yes) return;

            try
            {
                if (LopRepository.CoSinhVien(ma))
                {
                    CanhBao($"Không thể xóa lớp \"{ma}\" vì lớp đang có sinh viên.");
                    return;
                }

                int soDong = LopRepository.Xoa(ma);
                if (soDong == 0) CanhBao("Không tìm thấy lớp để xóa (có thể đã bị xóa).");
                else ThongTin("Xóa lớp thành công.");

                XoaONhap();
                TaiDuLieu();
            }
            catch (SqlException ex) when (ex.Number == 547)   // vi phạm khóa ngoại
            {
                CanhBao($"Không thể xóa lớp \"{ma}\" vì đang được tham chiếu bởi dữ liệu khác.");
            }
            catch (SqlException ex)
            {
                HienLoi("Không thể xóa lớp.", ex);
            }
        }

        // ================= F6: Tìm kiếm =================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            try
            {
                if (tuKhoa.Length == 0)
                {
                    TaiDuLieu();
                    return;
                }

                var dt = LopRepository.TimKiem(tuKhoa);
                dgvLop.DataSource = dt;
                DatTieuDeCot();

                if (dt.Rows.Count == 0)
                    ThongTin("Không tìm thấy lớp nào phù hợp.");
            }
            catch (SqlException ex)
            {
                HienLoi("Không thể tìm kiếm.", ex);
            }
        }

        // ================= F7: Làm mới =================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            XoaONhap();
            TaiDuLieu();
        }
    }
}
