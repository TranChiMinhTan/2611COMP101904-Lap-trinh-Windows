using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using StudentReportDemo.Models;

namespace StudentReportDemo.Helpers
{
    /// <summary>
    /// Tạo nội dung file CSV/TXT dưới dạng chuỗi (không ghi file ở đây) nên có thể kiểm thử dễ dàng.
    /// Số thập phân luôn dùng dấu chấm (InvariantCulture) để file giống nhau trên mọi máy.
    /// </summary>
    public static class BaoCaoExporter
    {
        private static string So(double d)
        {
            return d.ToString("0.00", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Quy tắc CSV: nếu giá trị có dấu phẩy, nháy kép hoặc xuống dòng thì đặt trong nháy kép,
        /// và mỗi nháy kép bên trong được nhân đôi.
        /// </summary>
        public static string EscapeCsv(string giaTri)
        {
            if (giaTri == null) return "";
            if (giaTri.IndexOfAny(new[] { ',', '"', '\r', '\n' }) >= 0)
                return "\"" + giaTri.Replace("\"", "\"\"") + "\"";
            return giaTri;
        }

        private static string DongCsv(params string[] cot)
        {
            return string.Join(",", cot.Select(EscapeCsv));
        }

        // ---------------- CSV ----------------

        public static string TaoCsvSinhVien(IEnumerable<SinhVien> ds)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DongCsv("STT", "MaSV", "HoTen", "MaLop", "TenLop", "Diem", "KetQua"));
            int stt = 0;
            foreach (SinhVien sv in ds)
            {
                stt++;
                sb.AppendLine(DongCsv(stt.ToString(), sv.MaSV, sv.HoTen, sv.MaLop, sv.TenLop, So(sv.Diem), sv.KetQua));
            }
            return sb.ToString();
        }

        public static string TaoCsvThongKe(IEnumerable<ThongKeLop> ds)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DongCsv("MaLop", "TenLop", "SoSinhVien", "SoDat", "SoKhongDat", "DiemTrungBinh", "DiemCaoNhat", "DiemThapNhat"));
            foreach (ThongKeLop t in ds)
            {
                sb.AppendLine(DongCsv(t.MaLop, t.TenLop, t.SoSinhVien.ToString(), t.SoDat.ToString(),
                    t.SoKhongDat.ToString(), So(t.DiemTrungBinh), So(t.DiemCaoNhat), So(t.DiemThapNhat)));
            }
            return sb.ToString();
        }

        // ---------------- TXT ----------------

        public static string TaoTxtSinhVien(IList<SinhVien> ds, string moTaBoLoc, DateTime thoiDiem)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BÁO CÁO DANH SÁCH SINH VIÊN");
            sb.AppendLine("Điều kiện lọc : " + moTaBoLoc);
            sb.AppendLine("Thời điểm xuất: " + thoiDiem.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine(new string('=', 92));
            sb.AppendLine(string.Format("{0,-4}{1,-9}{2,-26}{3,-10}{4,-26}{5,7}  {6}",
                "STT", "Mã SV", "Họ tên", "Mã lớp", "Tên lớp", "Điểm", "Kết quả"));
            sb.AppendLine(new string('-', 92));

            int stt = 0;
            foreach (SinhVien sv in ds)
            {
                stt++;
                sb.AppendLine(string.Format("{0,-4}{1,-9}{2,-26}{3,-10}{4,-26}{5,7}  {6}",
                    stt, sv.MaSV, Cat(sv.HoTen, 25), sv.MaLop, Cat(sv.TenLop, 25), So(sv.Diem), sv.KetQua));
            }

            sb.AppendLine(new string('-', 92));
            int dat = ds.Count(sv => sv.KetQua == BaoCaoService.Dat);
            sb.AppendLine("Tổng số sinh viên: " + ds.Count + "   Đạt: " + dat + "   Không đạt: " + (ds.Count - dat)
                          + "   Điểm trung bình: " + So(BaoCaoService.DiemTrungBinh(ds)));
            return sb.ToString();
        }

        public static string TaoTxtThongKe(IList<ThongKeLop> ds, DateTime thoiDiem)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("THỐNG KÊ SINH VIÊN THEO LỚP");
            sb.AppendLine("Thời điểm xuất: " + thoiDiem.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine(new string('=', 96));
            sb.AppendLine(string.Format("{0,-10}{1,-26}{2,8}{3,6}{4,12}{5,12}{6,10}{7,10}",
                "Mã lớp", "Tên lớp", "Số SV", "Đạt", "Không đạt", "Điểm TB", "Cao nhất", "Thấp nhất"));
            sb.AppendLine(new string('-', 96));
            foreach (ThongKeLop t in ds)
            {
                sb.AppendLine(string.Format("{0,-10}{1,-26}{2,8}{3,6}{4,12}{5,12}{6,10}{7,10}",
                    t.MaLop, Cat(t.TenLop, 25), t.SoSinhVien, t.SoDat, t.SoKhongDat,
                    So(t.DiemTrungBinh), So(t.DiemCaoNhat), So(t.DiemThapNhat)));
            }
            return sb.ToString();
        }

        private static string Cat(string s, int toiDa)
        {
            if (s == null) return "";
            return s.Length <= toiDa ? s : s.Substring(0, toiDa - 1) + "…";
        }
    }
}
