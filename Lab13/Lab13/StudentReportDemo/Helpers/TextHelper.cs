using System.Globalization;
using System.Text;

namespace StudentReportDemo.Helpers
{
    public static class TextHelper
    {
        /// <summary>
        /// Bỏ dấu tiếng Việt và đổi về chữ thường: "Nguyễn Đức" -> "nguyen duc".
        /// Dùng để tìm kiếm "nguyen" vẫn ra "Nguyễn".
        /// </summary>
        public static string ChuanHoaTimKiem(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            string tach = s.Trim().Normalize(NormalizationForm.FormD);   // tách dấu ra khỏi chữ
            StringBuilder sb = new StringBuilder();
            foreach (char c in tach)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString()
                     .Normalize(NormalizationForm.FormC)
                     .Replace('đ', 'd').Replace('Đ', 'D')
                     .ToLowerInvariant();
        }
    }
}
