using System;

namespace ProductManager
{
    // ============================================================
    // Product
    // Lớp dữ liệu đại diện cho 1 sản phẩm trong kho.
    // Chỉ chứa dữ liệu (properties) + constructor, không chứa logic
    // xử lý nghiệp vụ (việc đó nằm bên FrmProduct.cs).
    // ============================================================
    public class Product
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string LoaiSP { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhap { get; set; }
        public bool ConKinhDoanh { get; set; }

        // Đường dẫn file ảnh trên máy (có thể để trống - theo yêu cầu đề bài)
        public string DuongDanAnh { get; set; }

        // Constructor không tham số: cần thiết để BindingList<Product>
        // có thể hoạt động đầy đủ tính năng (ví dụ AddNew) nếu sau này cần dùng tới.
        public Product()
        {
        }

        public Product(string maSP, string tenSP, string loaiSP, decimal donGia,
            int soLuong, DateTime ngayNhap, bool conKinhDoanh, string duongDanAnh)
        {
            MaSP = maSP;
            TenSP = tenSP;
            LoaiSP = loaiSP;
            DonGia = donGia;
            SoLuong = soLuong;
            NgayNhap = ngayNhap;
            ConKinhDoanh = conKinhDoanh;
            DuongDanAnh = duongDanAnh;
        }
    }
}
