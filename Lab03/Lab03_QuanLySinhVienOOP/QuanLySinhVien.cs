using System;
using System.Collections.Generic;
using System.Linq; // cần using này để dùng được các hàm LINQ như Where, OrderBy, FirstOrDefault...

namespace Lab03_QuanLySinhVienOOP
{
    /// <summary>
    /// Class này chịu trách nhiệm quản lý List&lt;SinhVien&gt;.
    /// Program.cs (Main) sẽ KHÔNG thao tác trực tiếp lên danh sách,
    /// mà luôn gọi qua các method của class này. Đây là cách tách
    /// "logic xử lý dữ liệu" ra khỏi "logic giao diện/menu".
    /// </summary>
    public class QuanLySinhVien
    {
        // Danh sách sinh viên được lưu trong bộ nhớ (RAM), mất đi khi tắt chương trình.
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        /// <summary>
        /// Thêm sinh viên mới. Trả về false nếu mã sinh viên đã tồn tại.
        /// </summary>
        public bool Them(SinhVien sv)
        {
            bool daTonTai = danhSachSinhVien.Any(s =>
                s.MaSinhVien.Equals(sv.MaSinhVien, StringComparison.OrdinalIgnoreCase));

            if (daTonTai)
                return false;

            danhSachSinhVien.Add(sv);
            return true;
        }

        /// <summary>
        /// Sửa điểm trung bình của sinh viên theo mã.
        /// Trả về false nếu không tìm thấy mã, hoặc điểm nhập vào không hợp lệ.
        /// </summary>
        public bool Sua(string maSinhVien, double diemMoi)
        {
            SinhVien sv = TimTheoMa(maSinhVien);
            if (sv == null)
                return false;

            try
            {
                sv.DiemTrungBinh = diemMoi; // property sẽ tự kiểm tra 0-10
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        /// <summary>
        /// Xóa sinh viên theo mã. Trả về false nếu không tìm thấy.
        /// </summary>
        public bool Xoa(string maSinhVien)
        {
            SinhVien sv = TimTheoMa(maSinhVien);
            if (sv == null)
                return false;

            danhSachSinhVien.Remove(sv);
            return true;
        }

        /// <summary>
        /// Tìm 1 sinh viên theo mã (mã là duy nhất). Dùng LINQ FirstOrDefault.
        /// Trả về null nếu không tìm thấy.
        /// </summary>
        public SinhVien TimTheoMa(string maSinhVien)
        {
            return danhSachSinhVien.FirstOrDefault(s =>
                s.MaSinhVien.Equals(maSinhVien, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tìm tất cả sinh viên có họ tên chứa từ khóa (không phân biệt hoa thường).
        /// Dùng LINQ Where + Contains.
        /// </summary>
        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            return danhSachSinhVien
                .Where(s => s.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Trả về danh sách sinh viên đã sắp xếp giảm dần theo điểm trung bình.
        /// Dùng LINQ OrderByDescending.
        /// </summary>
        public List<SinhVien> SapXepTheoDiem()
        {
            return danhSachSinhVien
                .OrderByDescending(s => s.DiemTrungBinh)
                .ToList();
        }

        /// <summary>
        /// Trả về danh sách sinh viên "đạt" (điểm trung bình >= 5). Dùng LINQ Where.
        /// </summary>
        public List<SinhVien> LocSinhVienDat()
        {
            return danhSachSinhVien
                .Where(s => s.DiemTrungBinh >= 5)
                .ToList();
        }

        /// <summary>
        /// Trả về toàn bộ danh sách sinh viên hiện có.
        /// </summary>
        public List<SinhVien> LayDanhSach()
        {
            return danhSachSinhVien;
        }
    }
}
