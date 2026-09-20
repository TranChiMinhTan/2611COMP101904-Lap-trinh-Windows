using System;

namespace Lab03_QuanLySinhVienOOP
{
    /// <summary>
    /// Class SinhVien kế thừa (inherit) từ Nguoi bằng cú pháp ": Nguoi".
    /// Nghĩa là SinhVien có đầy đủ HoTen, NgaySinh của Nguoi, cộng thêm
    /// các thuộc tính riêng như MaSinhVien, MaLop, DiemTrungBinh.
    /// </summary>
    public class SinhVien : Nguoi
    {
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }

        // Biến private để "giấu" giá trị thật, chỉ cho truy cập qua property DiemTrungBinh.
        // Đây gọi là "backing field".
        private double diemTrungBinh;

        // Property có kiểm tra dữ liệu (validation): chỉ nhận giá trị 0 - 10.
        // Nếu người dùng đưa vào giá trị sai, property sẽ ném ra lỗi (exception)
        // để nơi gọi (QuanLySinhVien) biết mà xử lý, thay vì để chương trình
        // chạy sai một cách âm thầm.
        public double DiemTrungBinh
        {
            get => diemTrungBinh;
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(DiemTrungBinh),
                        "Điểm trung bình phải nằm trong khoảng 0 đến 10.");
                }
                diemTrungBinh = value;
            }
        }

        // Constructor của SinhVien. Từ khóa "base(...)" gọi tới constructor
        // của class cha (Nguoi) để khởi tạo HoTen, NgaySinh trước.
        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh; // sẽ tự động chạy qua phần kiểm tra ở trên
        }

        // Method riêng của SinhVien: xếp loại học lực dựa trên điểm trung bình.
        public string XepLoai()
        {
            if (DiemTrungBinh >= 8.5) return "Xuất sắc";
            if (DiemTrungBinh >= 7.0) return "Giỏi";
            if (DiemTrungBinh >= 5.0) return "Trung bình / Đạt";
            return "Yếu";
        }

        // Override lại LayThongTin() của lớp cha để in đầy đủ thông tin sinh viên.
        // Từ khóa "override" bắt buộc phải đi cùng "virtual" ở lớp cha.
        public override string LayThongTin()
        {
            // base.LayThongTin() gọi lại phiên bản gốc ở class Nguoi để tái sử dụng code.
            return $"Mã SV: {MaSinhVien,-8} | {base.LayThongTin()} | Lớp: {MaLop,-8} | " +
                   $"Điểm TB: {DiemTrungBinh,4:0.0} | Xếp loại: {XepLoai()}";
        }
    }
}
