using System;
using System.Collections.Generic;
using System.Linq;
using StudentReportDemo.Models;

namespace StudentReportDemo.Helpers
{
    /// <summary>
    /// Toàn bộ xử lý dữ liệu bằng LINQ: lọc, sắp xếp, nhóm, thống kê.
    /// Không có control nào ở đây nên dễ kiểm thử riêng.
    /// </summary>
    public static class BaoCaoService
    {
        public const string TatCa = "Tất cả";
        public const string Dat = "Đạt";
        public const string KhongDat = "Không đạt";

        /// <summary>Các lựa chọn của cboKetQua.</summary>
        public static readonly string[] CacKetQua = { TatCa, Dat, KhongDat };

        /// <summary>
        /// Lọc theo lớp (maLop null/rỗng = mọi lớp), kết quả ("Tất cả"/"Đạt"/"Không đạt")
        /// và từ khóa (tìm trong mã SV hoặc họ tên, không phân biệt hoa thường và dấu),
        /// rồi sắp xếp điểm giảm dần (điểm bằng nhau thì theo mã SV cho thứ tự ổn định).
        /// </summary>
        public static List<SinhVien> Loc(IEnumerable<SinhVien> nguon, string maLop, string ketQua, string tuKhoa)
        {
            string tk = TextHelper.ChuanHoaTimKiem(tuKhoa);

            return nguon
                .Where(sv => string.IsNullOrEmpty(maLop) || sv.MaLop == maLop)
                .Where(sv => ketQua == null || ketQua == TatCa || sv.KetQua == ketQua)
                .Where(sv => tk.Length == 0
                          || TextHelper.ChuanHoaTimKiem(sv.MaSV).Contains(tk)
                          || TextHelper.ChuanHoaTimKiem(sv.HoTen).Contains(tk))
                .OrderByDescending(sv => sv.Diem)
                .ThenBy(sv => sv.MaSV)
                .ToList();
        }

        /// <summary>Danh sách lớp (không trùng, sắp theo mã) lấy từ dữ liệu sinh viên.</summary>
        public static List<LopItem> LayDanhSachLop(IEnumerable<SinhVien> nguon)
        {
            return nguon
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .Select(g => new LopItem { MaLop = g.Key.MaLop, TenLop = g.Key.TenLop })
                .OrderBy(l => l.MaLop)
                .ToList();
        }

        /// <summary>
        /// Nhóm theo lớp: số sinh viên, số đạt, số không đạt, điểm trung bình, cao nhất, thấp nhất.
        /// Dòng cuối là "Tổng cộng" tính trên toàn bộ sinh viên (điểm TB là trung bình của mọi sinh viên,
        /// không phải trung bình của các điểm TB lớp).
        /// </summary>
        public static List<ThongKeLop> ThongKeTheoLop(IEnumerable<SinhVien> nguon)
        {
            List<SinhVien> ds = nguon.ToList();

            List<ThongKeLop> ketQua = ds
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .OrderBy(g => g.Key.MaLop)
                .Select(g => new ThongKeLop
                {
                    MaLop = g.Key.MaLop,
                    TenLop = g.Key.TenLop,
                    SoSinhVien = g.Count(),
                    SoDat = g.Count(sv => sv.KetQua == Dat),
                    SoKhongDat = g.Count(sv => sv.KetQua == KhongDat),
                    DiemTrungBinh = Math.Round(g.Average(sv => sv.Diem), 2),
                    DiemCaoNhat = g.Max(sv => sv.Diem),
                    DiemThapNhat = g.Min(sv => sv.Diem)
                })
                .ToList();

            if (ds.Any())
            {
                ketQua.Add(new ThongKeLop
                {
                    MaLop = "TỔNG",
                    TenLop = "Tất cả các lớp",
                    SoSinhVien = ds.Count,
                    SoDat = ds.Count(sv => sv.KetQua == Dat),
                    SoKhongDat = ds.Count(sv => sv.KetQua == KhongDat),
                    DiemTrungBinh = Math.Round(ds.Average(sv => sv.Diem), 2),
                    DiemCaoNhat = ds.Max(sv => sv.Diem),
                    DiemThapNhat = ds.Min(sv => sv.Diem)
                });
            }
            return ketQua;
        }

        /// <summary>Điểm trung bình; danh sách rỗng trả về 0 (Average() của danh sách rỗng sẽ ném lỗi).</summary>
        public static double DiemTrungBinh(IEnumerable<SinhVien> ds)
        {
            return ds.Any() ? ds.Average(sv => sv.Diem) : 0.0;
        }
    }
}
