namespace ShopManagerMini.Models
{
    // ============================================================
    // Customer
    // Lớp dữ liệu cho 1 khách hàng (dùng ở FrmCustomer).
    // ============================================================
    public class Customer
    {
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string LoaiKhachHang { get; set; } // Khách lẻ / Khách sỉ / VIP

        public Customer()
        {
        }

        public Customer(string maKH, string hoTen, string soDienThoai, string loaiKhachHang)
        {
            MaKH = maKH;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            LoaiKhachHang = loaiKhachHang;
        }
    }
}
