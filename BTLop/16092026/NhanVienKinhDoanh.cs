using System;

namespace QuanLyNhanVien
{
    // ============================================================
    // LỚP CON: NhanVienKinhDoanh (kế thừa từ NhanVien)
    // Lương = Lương cơ bản + 5% x Doanh số
    // ============================================================
    public class NhanVienKinhDoanh : NhanVien
    {
        private double doanhSo;

        public double DoanhSo
        {
            get { return doanhSo; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Doanh số phải >= 0.");
                }
                doanhSo = value;
            }
        }

        // Tỉ lệ hoa hồng trên doanh số
        private const double TI_LE_HOA_HONG = 0.05;

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + TI_LE_HOA_HONG * DoanhSo;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine(
                $"Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Loại: Kinh doanh (DS: {DoanhSo,10:N0}) | Lương: {TinhLuong():N0} VNĐ"
            );
        }
    }
}
