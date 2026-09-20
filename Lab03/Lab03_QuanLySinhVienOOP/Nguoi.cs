using System;

namespace Lab03_QuanLySinhVienOOP
{
    /// <summary>
    /// Class cha (base class), đại diện cho một "Người" nói chung.
    /// SinhVien sẽ kế thừa (inherit) từ class này.
    /// </summary>
    public class Nguoi
    {
        // Property tự động (auto-property): C# tự sinh ra biến ẩn để lưu giá trị.
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        // Constructor: được gọi mỗi khi tạo mới một đối tượng Nguoi.
        public Nguoi(string hoTen, DateTime ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        // Từ khóa "virtual" cho phép class con (SinhVien) override (ghi đè) lại method này.
        public virtual string LayThongTin()
        {
            return $"Họ tên: {HoTen} - Ngày sinh: {NgaySinh:dd/MM/yyyy}";
        }
    }
}
