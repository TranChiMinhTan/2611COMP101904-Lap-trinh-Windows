using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentReportDemo.Helpers;
using StudentReportDemo.Models;

namespace StudentReportDemo.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        private enum CheDoHienThi { BaoCao, ThongKe }

        // Toàn bộ dữ liệu (nguồn). Mọi báo cáo đều được LINQ lọc/nhóm từ danh sách này.
        private readonly List<SinhVien> _dsSinhVien;

        // "Ảnh chụp" của những gì đang hiển thị trên lưới - nút Xuất file ghi đúng dữ liệu này,
        // không đọc lại ComboBox/TextBox (người dùng có thể đã đổi điều kiện mà chưa bấm Xem báo cáo).
        private List<SinhVien> _dsBaoCaoDangHienThi = new List<SinhVien>();
        private List<ThongKeLop> _dsThongKeDangHienThi = new List<ThongKeLop>();
        private string _moTaBoLoc = "";
        private CheDoHienThi _cheDo = CheDoHienThi.BaoCao;
        private Font _fontDam = null;   // font in đậm cho dòng TỔNG, tạo một lần

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
            _dsSinhVien = TaoDuLieuMau();
        }

        // ------------------------------------------------------------
        // Chức năng 1: mở Form -> nạp ComboBox
        // ------------------------------------------------------------
        private void FrmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            XemBaoCao();   // mở lên là thấy ngay toàn bộ danh sách
        }

        /// <summary>Dữ liệu mẫu: 15 sinh viên, 4 lớp, có điểm sát ngưỡng (5.0 và 4.9), điểm 10 và điểm 0.</summary>
        private List<SinhVien> TaoDuLieuMau()
        {
            return new List<SinhVien>
            {
                // CNTT49A
                new SinhVien("SV001", "Nguyễn Văn An",     "CNTT49A", "Công nghệ thông tin 49A", 8.50),
                new SinhVien("SV002", "Trần Thị Bình",     "CNTT49A", "Công nghệ thông tin 49A", 9.25),
                new SinhVien("SV003", "Lê Minh Cường",     "CNTT49A", "Công nghệ thông tin 49A", 6.50),
                new SinhVien("SV004", "Phạm Thu Dung",     "CNTT49A", "Công nghệ thông tin 49A", 4.50),
                new SinhVien("SV005", "Hoàng Gia Huy",     "CNTT49A", "Công nghệ thông tin 49A", 5.00),
                // CNTT49B
                new SinhVien("SV006", "Đỗ Khánh Linh",     "CNTT49B", "Công nghệ thông tin 49B", 7.75),
                new SinhVien("SV007", "Vũ Quang Minh",     "CNTT49B", "Công nghệ thông tin 49B", 3.50),
                new SinhVien("SV008", "Bùi Thanh Nam",     "CNTT49B", "Công nghệ thông tin 49B", 8.00),
                new SinhVien("SV009", "Ngô Bảo Ngọc",      "CNTT49B", "Công nghệ thông tin 49B", 4.90),
                // SPTIN01
                new SinhVien("SV010", "Đặng Quốc Phong",   "SPTIN01", "Sư phạm Tin học 01",      6.00),
                new SinhVien("SV011", "Lý Thị Quỳnh",      "SPTIN01", "Sư phạm Tin học 01",      10.00),
                new SinhVien("SV012", "Dương Hoàng Sơn",   "SPTIN01", "Sư phạm Tin học 01",      2.75),
                // NN49A
                new SinhVien("SV013", "Phan Thị Thảo",     "NN49A",   "Ngoại ngữ 49A",           7.00),
                new SinhVien("SV014", "Trịnh Văn Tuấn",    "NN49A",   "Ngoại ngữ 49A",           0.00),
                new SinhVien("SV015", "Võ Mai Uyên",       "NN49A",   "Ngoại ngữ 49A",           5.50)
            };
        }

        private void LoadComboBox()
        {
            // cboLop: "Tất cả các lớp" + các lớp lấy từ dữ liệu bằng LINQ
            List<LopItem> dsLop = BaoCaoService.LayDanhSachLop(_dsSinhVien);
            dsLop.Insert(0, new LopItem { MaLop = null, TenLop = "Tất cả các lớp" });
            cboLop.DataSource = dsLop;   // hiển thị bằng LopItem.ToString()
            cboLop.SelectedIndex = 0;

            // cboKetQua: Tất cả / Đạt / Không đạt
            cboKetQua.DataSource = BaoCaoService.CacKetQua.ToList();
            cboKetQua.SelectedIndex = 0;
        }

        // ------------------------------------------------------------
        // Chức năng 2 + 3 + 6: Xem báo cáo (lọc, sắp xếp giảm dần theo điểm)
        // ------------------------------------------------------------
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            XemBaoCao();
        }

        private void XemBaoCao()
        {
            LopItem lop = (LopItem)cboLop.SelectedItem;
            string ketQua = Convert.ToString(cboKetQua.SelectedItem);
            string tuKhoa = txtTuKhoa.Text.Trim();

            List<SinhVien> ketQuaLoc = BaoCaoService.Loc(_dsSinhVien, lop.MaLop, ketQua, tuKhoa);

            _cheDo = CheDoHienThi.BaoCao;
            _dsBaoCaoDangHienThi = ketQuaLoc;
            _moTaBoLoc = "Lớp = " + lop + "; Kết quả = " + ketQua
                         + "; Từ khóa = " + (tuKhoa.Length == 0 ? "(không)" : "\"" + tuKhoa + "\"");

            HienThiLuoi(ketQuaLoc);
            lblTieuDeBang.Text = "Danh sách sinh viên (sắp xếp điểm giảm dần) - " + ketQuaLoc.Count + " kết quả";
            CapNhatThongKe(ketQuaLoc);

            if (ketQuaLoc.Count == 0)
            {
                MessageBox.Show("Không có sinh viên nào phù hợp với điều kiện đã chọn.\n\n" + _moTaBoLoc,
                    "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ------------------------------------------------------------
        // Chức năng 4: Thống kê theo lớp (nhóm bằng LINQ)
        // ------------------------------------------------------------
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            HienThiThongKeTheoLop();
        }

        private void HienThiThongKeTheoLop()
        {
            List<ThongKeLop> thongKe = BaoCaoService.ThongKeTheoLop(_dsSinhVien);

            _cheDo = CheDoHienThi.ThongKe;
            _dsThongKeDangHienThi = thongKe;

            HienThiLuoi(thongKe);
            lblTieuDeBang.Text = "Thống kê theo lớp (toàn bộ " + _dsSinhVien.Count + " sinh viên)";
            CapNhatThongKe(_dsSinhVien);
        }

        /// <summary>Cập nhật StatusStrip: tổng số, số đạt, số không đạt, điểm trung bình của danh sách.</summary>
        private void CapNhatThongKe(IList<SinhVien> ds)
        {
            int tong = ds.Count;
            int soDat = ds.Count(sv => sv.KetQua == BaoCaoService.Dat);
            int soKhongDat = ds.Count(sv => sv.KetQua == BaoCaoService.KhongDat);

            lblTong.Text = "Tổng số sinh viên: " + tong;
            lblDat.Text = "Đạt: " + soDat;
            lblKhongDat.Text = "Không đạt: " + soKhongDat;
            lblDiemTB.Text = tong == 0
                ? "Điểm trung bình: --"
                : "Điểm trung bình: " + BaoCaoService.DiemTrungBinh(ds).ToString("0.00");
        }

        // ------------------------------------------------------------
        // Chức năng 5: Xuất file CSV / TXT
        // ------------------------------------------------------------
        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            XuatFile();
        }

        private void XuatFile()
        {
            bool dangBaoCao = _cheDo == CheDoHienThi.BaoCao;
            int soDong = dangBaoCao ? _dsBaoCaoDangHienThi.Count : _dsThongKeDangHienThi.Count;

            if (soDong == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất. Hãy bấm \"Xem báo cáo\" hoặc \"Thống kê\" trước.",
                    "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog hopThoai = new SaveFileDialog())
            {
                hopThoai.Title = "Xuất báo cáo";
                hopThoai.Filter = "File CSV (*.csv)|*.csv|File văn bản (*.txt)|*.txt";
                hopThoai.DefaultExt = "csv";
                hopThoai.AddExtension = true;
                hopThoai.OverwritePrompt = true;
                hopThoai.FileName = (dangBaoCao ? "BaoCaoSinhVien_" : "ThongKeLop_") + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (hopThoai.ShowDialog(this) != DialogResult.OK)
                    return;   // người dùng bấm Cancel

                bool laCsv = string.Equals(Path.GetExtension(hopThoai.FileName), ".csv", StringComparison.OrdinalIgnoreCase);
                string noiDung = TaoNoiDungFile(dangBaoCao, laCsv);

                try
                {
                    // UTF-8 có BOM để Excel và Notepad hiển thị đúng tiếng Việt
                    File.WriteAllText(hopThoai.FileName, noiDung, new UTF8Encoding(true));
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Không có quyền ghi vào vị trí đã chọn.\nHãy chọn thư mục khác (ví dụ Documents hoặc Desktop).",
                        "Không xuất được file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (IOException ex)
                {
                    // Thường gặp nhất: file đang được mở trong Excel
                    MessageBox.Show("Không ghi được file. Có thể file đang được mở trong chương trình khác (ví dụ Excel), hãy đóng rồi thử lại.\n\nChi tiết: " + ex.Message,
                        "Không xuất được file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất file thất bại.\n\nChi tiết: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Đã xuất " + soDong + " dòng ra file:\n" + hopThoai.FileName,
                    "Xuất file thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string TaoNoiDungFile(bool dangBaoCao, bool laCsv)
        {
            if (dangBaoCao)
            {
                return laCsv
                    ? BaoCaoExporter.TaoCsvSinhVien(_dsBaoCaoDangHienThi)
                    : BaoCaoExporter.TaoTxtSinhVien(_dsBaoCaoDangHienThi, _moTaBoLoc, DateTime.Now);
            }
            return laCsv
                ? BaoCaoExporter.TaoCsvThongKe(_dsThongKeDangHienThi)
                : BaoCaoExporter.TaoTxtThongKe(_dsThongKeDangHienThi, DateTime.Now);
        }

        // ------------------------------------------------------------
        // Hàm phụ: hiển thị lưới
        // ------------------------------------------------------------
        private void HienThiLuoi<T>(List<T> nguon)
        {
            dgvBaoCao.DataSource = null;
            dgvBaoCao.DataSource = nguon;   // tự sinh cột theo thuộc tính của T

            foreach (DataGridViewColumn cot in dgvBaoCao.Columns)
            {
                DinhDangCot(cot);
            }
            dgvBaoCao.ClearSelection();
        }

        private static void DinhDangCot(DataGridViewColumn cot)
        {
            switch (cot.DataPropertyName)
            {
                case "MaSV": cot.HeaderText = "Mã SV"; cot.FillWeight = 12; break;
                case "HoTen": cot.HeaderText = "Họ tên"; cot.FillWeight = 26; break;
                case "MaLop": cot.HeaderText = "Mã lớp"; cot.FillWeight = 14; break;
                case "TenLop": cot.HeaderText = "Tên lớp"; cot.FillWeight = 30; break;
                case "Diem": cot.HeaderText = "Điểm"; cot.FillWeight = 10; AlignPhai(cot, "0.00"); break;
                case "KetQua": cot.HeaderText = "Kết quả"; cot.FillWeight = 14; break;
                case "SoSinhVien": cot.HeaderText = "Số SV"; AlignPhai(cot, null); break;
                case "SoDat": cot.HeaderText = "Đạt"; AlignPhai(cot, null); break;
                case "SoKhongDat": cot.HeaderText = "Không đạt"; AlignPhai(cot, null); break;
                case "DiemTrungBinh": cot.HeaderText = "Điểm TB"; AlignPhai(cot, "0.00"); break;
                case "DiemCaoNhat": cot.HeaderText = "Cao nhất"; AlignPhai(cot, "0.00"); break;
                case "DiemThapNhat": cot.HeaderText = "Thấp nhất"; AlignPhai(cot, "0.00"); break;
            }
        }

        private static void AlignPhai(DataGridViewColumn cot, string dinhDang)
        {
            cot.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cot.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (dinhDang != null) cot.DefaultCellStyle.Format = dinhDang;
        }

        // "Không đạt" tô chữ đỏ; dòng "TỔNG" trong thống kê in đậm
        private void dgvBaoCao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (_cheDo == CheDoHienThi.BaoCao
                && dgvBaoCao.Columns[e.ColumnIndex].DataPropertyName == "KetQua"
                && Convert.ToString(e.Value) == BaoCaoService.KhongDat)
            {
                e.CellStyle.ForeColor = Color.Firebrick;
            }
            else if (_cheDo == CheDoHienThi.ThongKe
                     && Convert.ToString(dgvBaoCao.Rows[e.RowIndex].Cells["MaLop"].Value) == "TỔNG")
            {
                if (_fontDam == null) _fontDam = new Font(dgvBaoCao.Font, FontStyle.Bold);
                e.CellStyle.Font = _fontDam;
            }
        }
    }
}
