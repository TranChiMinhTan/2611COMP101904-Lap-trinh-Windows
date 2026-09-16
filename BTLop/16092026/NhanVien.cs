using System;

namespace QuanLyNhanVien
{
    // ============================================================
    // LỚP CHA: NhanVien
    // Chứa các thông tin và hành vi CHUNG cho mọi loại nhân viên.
    // ============================================================
    public class NhanVien
    {
        // ----- Các trường dữ liệu (field) được giữ private -----
        // => Đây chính là ENCAPSULATION (đóng gói):
        // dữ liệu không được truy cập trực tiếp từ bên ngoài,
        // mà phải đi qua Property (get/set) để có thể kiểm tra hợp lệ.
        private string maNV;
        private string hoTen;
        private double luongCoBan;

        // ----- Property (thuộc tính) -----
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        // Property này có kiểm tra điều kiện: Lương cơ bản phải > 0
        public double LuongCoBan
        {
            get { return luongCoBan; }
            set
            {
                if (value <= 0)
                {
                    // Nếu nhập sai, không cho gán giá trị âm/0
                    // mà báo lỗi rõ ràng cho người dùng biết.
                    throw new ArgumentException("Lương cơ bản phải lớn hơn 0.");
                }
                luongCoBan = value;
            }
        }

        // ----- Constructor (hàm khởi tạo) -----
        // Dùng để khởi tạo giá trị ban đầu cho đối tượng.
        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        // ----- Phương thức TÍNH LƯƠNG -----
        // Đánh dấu "virtual" để các lớp con có thể ghi đè (override)
        // theo cách tính lương riêng của từng loại nhân viên.
        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        // ----- Phương thức HIỂN THỊ THÔNG TIN -----
        // Cũng là "virtual" để lớp con override, in thêm thông tin riêng.
        public virtual void HienThiThongTin()
        {
            Console.WriteLine(
                $"Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Loại: Nhân viên thường      | Lương: {TinhLuong():N0} VNĐ"
            );
        }
    }
}
