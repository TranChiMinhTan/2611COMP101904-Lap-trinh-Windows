using System;

namespace QuanLyNhanVien
{
    // ============================================================
    // LỚP CON: NhanVienVanPhong (kế thừa từ NhanVien)
    // Lương = Lương cơ bản + Số ngày làm việc x 200.000
    // ============================================================
    public class NhanVienVanPhong : NhanVien
    {
        private int soNgayLamViec;

        public int SoNgayLamViec
        {
            get { return soNgayLamViec; }
            set
            {
                if (value < 0 || value > 31)
                {
                    throw new ArgumentException("Số ngày làm việc phải trong khoảng 0 - 31.");
                }
                soNgayLamViec = value;
            }
        }

        // Hệ số tiền lương cho mỗi ngày công (đơn vị: VNĐ)
        private const double TIEN_MOI_NGAY = 200000;

        // Constructor: dùng base(...) để gọi Constructor của lớp cha
        // (NhanVien) nhằm khởi tạo MaNV, HoTen, LuongCoBan trước.
        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        // Ghi đè (override) cách tính lương riêng cho Nhân viên văn phòng
        public override double TinhLuong()
        {
            return LuongCoBan + SoNgayLamViec * TIEN_MOI_NGAY;
        }

        // Ghi đè cách hiển thị thông tin, có thêm số ngày làm việc
        public override void HienThiThongTin()
        {
            Console.WriteLine(
                $"Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Loại: Văn phòng ({SoNgayLamViec,2} ngày công) | Lương: {TinhLuong():N0} VNĐ"
            );
        }
    }
}
