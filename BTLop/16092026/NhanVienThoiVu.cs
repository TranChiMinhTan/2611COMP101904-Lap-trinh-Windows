using System;

namespace QuanLyNhanVien
{
    // ============================================================
    // LỚP CON (BONUS): NhanVienThoiVu (kế thừa từ NhanVien)
    // Lương = Số giờ làm x Lương theo giờ
    // Lưu ý: Với loại nhân viên này, "Lương cơ bản" không dùng để
    // tính lương thực nhận, nhưng lớp cha NhanVien vẫn yêu cầu
    // LuongCoBan > 0, nên ta truyền một giá trị tượng trưng (ví dụ 1)
    // xuống base(...) để không phá vỡ ràng buộc của lớp cha.
    // ============================================================
    public class NhanVienThoiVu : NhanVien
    {
        private int soGioLam;
        private double luongTheoGio;

        public int SoGioLam
        {
            get { return soGioLam; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Số giờ làm phải >= 0.");
                }
                soGioLam = value;
            }
        }

        public double LuongTheoGio
        {
            get { return luongTheoGio; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Lương theo giờ phải >= 0.");
                }
                luongTheoGio = value;
            }
        }

        public NhanVienThoiVu(string maNV, string hoTen, int soGioLam, double luongTheoGio)
            : base(maNV, hoTen, luongCoBan: 1) // giá trị tượng trưng, không ảnh hưởng tới TinhLuong()
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine(
                $"Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Loại: Thời vụ ({SoGioLam,3} giờ x {LuongTheoGio:N0}) | Lương: {TinhLuong():N0} VNĐ"
            );
        }
    }
}
