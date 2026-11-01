using System.Globalization;

namespace QLSinhVienLab12.Helpers
{
    /// <summary>
    /// Kiểm tra dữ liệu điểm và ghi chú. Không phụ thuộc control hay database
    /// nên có thể kiểm thử riêng. Luôn dùng InvariantCulture để "8.5" và "8,5"
    /// đều hiểu đúng dù máy đặt ngôn ngữ nào.
    /// </summary>
    public static class DiemValidator
    {
        public const decimal DiemToiThieu = 0m;
        public const decimal DiemToiDa = 10m;
        public const int GhiChuToiDa = 200;   // khớp NVARCHAR(200)

        /// <summary>
        /// Trả về true nếu hợp lệ (diem có giá trị); ngược lại false và loi chứa nội dung lỗi.
        /// Quy tắc: không rỗng, là số, từ 0 đến 10, tối đa 2 chữ số thập phân.
        /// </summary>
        public static bool TryParseDiem(string text, out decimal diem, out string loi)
        {
            diem = 0m;
            loi = null;

            if (string.IsNullOrWhiteSpace(text))
            {
                loi = "Điểm không được để trống.";
                return false;
            }

            string s = text.Trim().Replace(',', '.');

            if (!decimal.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out diem))
            {
                diem = 0m;
                loi = "Điểm phải là số (ví dụ 8 hoặc 8.5).";
                return false;
            }

            if (diem < DiemToiThieu || diem > DiemToiDa)
            {
                diem = 0m;
                loi = "Điểm phải nằm trong khoảng từ 0 đến 10.";
                return false;
            }

            if (decimal.Round(diem, 2) != diem)
            {
                diem = 0m;
                loi = "Điểm chỉ được có tối đa 2 chữ số thập phân.";
                return false;
            }

            return true;
        }

        /// <summary>Ghi chú tối đa 200 ký tự. Trả về null nếu hợp lệ.</summary>
        public static string KiemTraGhiChu(string ghiChu)
        {
            if (ghiChu != null && ghiChu.Trim().Length > GhiChuToiDa)
                return "Ghi chú tối đa " + GhiChuToiDa + " ký tự.";
            return null;
        }

        /// <summary>Ghi chú rỗng hoặc toàn khoảng trắng được lưu thành NULL.</summary>
        public static string ChuanHoaGhiChu(string ghiChu)
        {
            return string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu.Trim();
        }

        /// <summary>Hiển thị điểm lên lưới: 8.50 -> "8.5", 9.00 -> "9".</summary>
        public static string DinhDangDiem(decimal diem)
        {
            return diem.ToString("0.##", CultureInfo.InvariantCulture);
        }
    }
}
