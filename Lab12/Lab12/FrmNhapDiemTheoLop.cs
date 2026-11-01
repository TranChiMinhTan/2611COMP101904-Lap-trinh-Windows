using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QLSinhVienLab12.DAL;
using QLSinhVienLab12.Helpers;
using QLSinhVienLab12.Models;

namespace QLSinhVienLab12.Forms
{
    public partial class FrmNhapDiemTheoLop : Form
    {
        private readonly KetQuaDAL _dal = new KetQuaDAL();

        // Lớp và môn của danh sách ĐANG HIỂN THỊ trên lưới. "Lưu tất cả" dùng 2 biến này,
        // không dùng giá trị hiện tại của ComboBox (người dùng có thể đã đổi ComboBox
        // mà chưa bấm Tải danh sách lại).
        private string _maLopDangTai = null;
        private string _maMonDangTai = null;

        private bool _dangNapDuLieu = false;   // true khi đang nạp lưới -> bỏ qua sự kiện sửa
        private bool _coThayDoiChuaLuu = false;

        private static readonly Color MauLoi = Color.MistyRose;

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
        }

        // ------------------------------------------------------------
        // Chức năng 1: mở Form -> nạp lớp và môn học vào ComboBox
        // ------------------------------------------------------------
        private void FrmNhapDiemTheoLop_Load(object sender, EventArgs e)
        {
            btnLuuTatCa.Enabled = false;
            NapComboBox();
        }

        private void NapComboBox()
        {
            try
            {
                // Binding: ComboBox <- BindingSource <- DataTable
                bsLop.DataSource = _dal.GetLop();
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.DataSource = bsLop;
                cboLop.SelectedIndex = -1;

                bsMonHoc.DataSource = _dal.GetMonHoc();
                cboMonHoc.DisplayMember = "TenMon";
                cboMonHoc.ValueMember = "MaMon";
                cboMonHoc.DataSource = bsMonHoc;
                cboMonHoc.SelectedIndex = -1;

                DatTrangThai("Hãy chọn lớp và môn học, rồi bấm \"Tải danh sách\".");
            }
            catch (SqlException ex)
            {
                BaoLoiCsdl(ex, "Không nạp được danh sách lớp / môn học.");
            }
        }

        // ------------------------------------------------------------
        // Chức năng 2: Tải danh sách sinh viên lên DataGridView
        // ------------------------------------------------------------
        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            TaiDanhSach();
        }

        private void TaiDanhSach()
        {
            if (cboLop.SelectedValue == null)
            {
                MessageBox.Show("Hãy chọn lớp.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLop.Focus();
                return;
            }
            if (cboMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Hãy chọn môn học.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMonHoc.Focus();
                return;
            }

            if (_coThayDoiChuaLuu)
            {
                DialogResult hoi = MessageBox.Show(
                    "Bạn đã sửa điểm nhưng chưa lưu. Tải lại danh sách sẽ mất các thay đổi này. Tiếp tục?",
                    "Thay đổi chưa lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (hoi != DialogResult.Yes)
                    return;
            }

            string maLop = Convert.ToString(cboLop.SelectedValue);
            string maMon = Convert.ToString(cboMonHoc.SelectedValue);
            string tenLop = cboLop.Text;
            string tenMon = cboMonHoc.Text;

            try
            {
                DataTable bang = _dal.GetByLopMon(maLop, maMon);

                _dangNapDuLieu = true;
                bsKetQua.DataSource = bang;
                XoaDanhDauLoi();
                _dangNapDuLieu = false;

                _maLopDangTai = maLop;
                _maMonDangTai = maMon;
                _coThayDoiChuaLuu = false;
                btnLuuTatCa.Enabled = bang.Rows.Count > 0;

                lblNguCanh.Text = "Đang nhập điểm: " + tenLop + "  -  " + tenMon;

                if (bang.Rows.Count == 0)
                    DatTrangThai("Lớp " + maLop + " chưa có sinh viên nào.");
                else
                    DatTrangThai("Đã tải " + bang.Rows.Count + " sinh viên. Nhập hoặc sửa Điểm / Ghi chú rồi bấm \"Lưu tất cả\".");
            }
            catch (SqlException ex)
            {
                _dangNapDuLieu = false;
                BaoLoiCsdl(ex, "Không tải được danh sách sinh viên.");
            }
        }

        // ------------------------------------------------------------
        // Chức năng 3 + 4: sửa Điểm/Ghi chú, kiểm tra ngay khi rời ô
        // ------------------------------------------------------------
        private void dgvKetQua_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_dangNapDuLieu && e.RowIndex >= 0)
                _coThayDoiChuaLuu = true;
        }

        private void dgvKetQua_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == colDiem.Index || e.ColumnIndex == colGhiChu.Index)
                KiemTraDong(dgvKetQua.Rows[e.RowIndex], null, null);
        }

        private void dgvKetQua_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Cột là chuỗi nên hầu như không xảy ra; phòng khi có lỗi lạ thì không để chương trình sập.
            e.ThrowException = false;
        }

        /// <summary>
        /// Kiểm tra một dòng của lưới: tô màu/ErrorText ô lỗi.
        /// Nếu hợp lệ và danhSach != null thì thêm vào danhSach để lưu.
        /// Nếu lỗi và dsLoi != null thì thêm câu mô tả lỗi vào dsLoi. Trả về true nếu dòng hợp lệ.
        /// </summary>
        private bool KiemTraDong(DataGridViewRow dong, List<KetQuaDong> danhSach, List<string> dsLoi)
        {
            string maSV = Convert.ToString(dong.Cells[colMaSV.Index].Value);
            string textDiem = Convert.ToString(dong.Cells[colDiem.Index].Value);
            string ghiChu = Convert.ToString(dong.Cells[colGhiChu.Index].Value);

            decimal diem;
            string loiDiem;
            bool diemOk = DiemValidator.TryParseDiem(textDiem, out diem, out loiDiem);
            string loiGhiChu = DiemValidator.KiemTraGhiChu(ghiChu);

            DatLoiO(dong.Cells[colDiem.Index], loiDiem);
            DatLoiO(dong.Cells[colGhiChu.Index], loiGhiChu);

            if (diemOk && loiGhiChu == null)
            {
                if (danhSach != null)
                    danhSach.Add(new KetQuaDong { MaSV = maSV, Diem = diem, GhiChu = DiemValidator.ChuanHoaGhiChu(ghiChu) });
                return true;
            }

            if (dsLoi != null)
                dsLoi.Add(maSV + ": " + (loiDiem != null ? loiDiem : loiGhiChu));
            return false;
        }

        private static void DatLoiO(DataGridViewCell o, string loi)
        {
            o.ErrorText = loi == null ? "" : loi;
            o.Style.BackColor = loi == null ? Color.Empty : MauLoi;
        }

        private void XoaDanhDauLoi()
        {
            foreach (DataGridViewRow dong in dgvKetQua.Rows)
            {
                DatLoiO(dong.Cells[colDiem.Index], null);
                DatLoiO(dong.Cells[colGhiChu.Index], null);
            }
        }

        // ------------------------------------------------------------
        // Chức năng 5 + 6 + 7: Lưu tất cả bằng transaction
        // ------------------------------------------------------------
        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            LuuTatCa();
        }

        private void LuuTatCa()
        {
            if (_maMonDangTai == null || dgvKetQua.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có danh sách để lưu. Hãy tải danh sách sinh viên trước.",
                    "Lưu tất cả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Đưa giá trị ô đang gõ dở vào dữ liệu trước khi kiểm tra.
            dgvKetQua.EndEdit();
            bsKetQua.EndEdit();

            // Bước 1: kiểm tra TOÀN BỘ dòng trước. Có lỗi thì dừng, chưa đụng tới database.
            List<KetQuaDong> danhSach = new List<KetQuaDong>();
            List<string> dsLoi = new List<string>();
            int dongLoiDauTien = -1;

            foreach (DataGridViewRow dong in dgvKetQua.Rows)
            {
                if (!KiemTraDong(dong, danhSach, dsLoi) && dongLoiDauTien < 0)
                    dongLoiDauTien = dong.Index;
            }

            if (dsLoi.Count > 0)
            {
                dgvKetQua.CurrentCell = dgvKetQua.Rows[dongLoiDauTien].Cells[colDiem.Index];
                MessageBox.Show(MoTaLoi(dsLoi) + "\n\nChưa lưu dòng nào. Hãy sửa các ô được tô màu rồi bấm lại.",
                    "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DatTrangThai("Có " + dsLoi.Count + " dòng lỗi - chưa lưu.");
                return;
            }

            // Bước 2: lưu bằng transaction (DAL tự rollback nếu có dòng lỗi).
            try
            {
                Cursor = Cursors.WaitCursor;
                KetQuaLuu kq = _dal.LuuTatCa(_maMonDangTai, danhSach);
                Cursor = Cursors.Default;

                _coThayDoiChuaLuu = false;
                MessageBox.Show("Đã lưu thành công " + kq.TongSoDong + " dòng (" +
                                kq.SoThemMoi + " thêm mới, " + kq.SoCapNhat + " cập nhật).",
                    "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DatTrangThai("Đã lưu " + kq.TongSoDong + " dòng (commit).");
            }
            catch (SqlException ex)
            {
                Cursor = Cursors.Default;
                BaoLoiLuu(ex);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lưu thất bại, đã hủy toàn bộ (rollback).\n\nChi tiết: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatTrangThai("Lưu thất bại - đã rollback.");
            }
        }

        // ------------------------------------------------------------
        // Hàm phụ
        // ------------------------------------------------------------
        private static string MoTaLoi(List<string> dsLoi)
        {
            const int toiDa = 8;
            StringBuilder sb = new StringBuilder();
            sb.Append("Có ").Append(dsLoi.Count).Append(" dòng chưa hợp lệ:\n");
            for (int i = 0; i < dsLoi.Count && i < toiDa; i++)
                sb.Append("  - ").Append(dsLoi[i]).Append('\n');
            if (dsLoi.Count > toiDa)
                sb.Append("  ... và ").Append(dsLoi.Count - toiDa).Append(" dòng nữa.");
            return sb.ToString().TrimEnd('\n');
        }

        private void DatTrangThai(string noiDung)
        {
            lblTrangThai.Text = noiDung;
        }

        private void BaoLoiLuu(SqlException ex)
        {
            string nguyenNhan;
            switch (ex.Number)
            {
                case 547:
                    nguyenNhan = "Có sinh viên hoặc môn học không còn tồn tại trong database (vi phạm khóa ngoại).";
                    break;
                case 50001:
                    nguyenNhan = "Điểm không hợp lệ theo database.";
                    break;
                case 2:
                case 53:
                case 40:
                case -1:
                    nguyenNhan = "Mất kết nối tới SQL Server.";
                    break;
                default:
                    nguyenNhan = "Lỗi cơ sở dữ liệu.";
                    break;
            }

            MessageBox.Show(nguyenNhan + "\n\nĐã hủy toàn bộ thao tác lưu (rollback), không có dòng nào được ghi.\n\nChi tiết: " + ex.Message,
                "Lưu thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DatTrangThai("Lưu thất bại - đã rollback toàn bộ.");
        }

        private void BaoLoiCsdl(SqlException ex, string tieuDe)
        {
            string goiY;
            switch (ex.Number)
            {
                case 4060:
                    goiY = "Không mở được database QLSinhVienLab12. Hãy chạy script Database\\QLSinhVienLab12.sql trong SSMS.";
                    break;
                case 2812:
                case 208:
                    goiY = "Chưa có stored procedure hoặc bảng cần thiết. Hãy chạy lại script Database\\QLSinhVienLab12.sql.";
                    break;
                case 18456:
                    goiY = "Đăng nhập SQL Server thất bại. Kiểm tra lại chuỗi kết nối trong DAL\\Database.cs.";
                    break;
                case 2:
                case 53:
                case 40:
                case -1:
                    goiY = "Không kết nối được SQL Server. Kiểm tra SQL Server đã chạy chưa và tên Server trong DAL\\Database.cs (ví dụ .\\SQLEXPRESS).";
                    break;
                default:
                    goiY = "Có lỗi khi làm việc với cơ sở dữ liệu.";
                    break;
            }

            MessageBox.Show(tieuDe + "\n" + goiY + "\n\nChi tiết: " + ex.Message,
                "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DatTrangThai("Lỗi cơ sở dữ liệu.");
        }

        private void FrmNhapDiemTheoLop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_coThayDoiChuaLuu)
                return;

            DialogResult hoi = MessageBox.Show("Bạn đã sửa điểm nhưng chưa lưu. Đóng chương trình và bỏ các thay đổi?",
                "Thay đổi chưa lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (hoi != DialogResult.Yes)
                e.Cancel = true;
        }
    }
}
