using System;

namespace QuanLySanPham
{
    // ============================================================
    // LỚP Product
    // Đại diện cho 1 sản phẩm trong kho.
    // Implement IEntity để có thể được Repository<T> quản lý.
    // ============================================================
    public class Product : IEntity
    {
        // ----- Encapsulation: field private, chỉ truy cập qua property -----
        private string maSP;
        private string tenSP;
        private decimal price;
        private int quantity;

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }

        // Price không được âm
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Đơn giá không được âm.");
                }
                price = value;
            }
        }

        // Quantity không được âm
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Số lượng không được âm.");
                }
                quantity = value;
            }
        }

        // IEntity yêu cầu có Id (chỉ get) -> dùng luôn MaSP làm Id
        public string Id
        {
            get { return maSP; }
        }

        // ----- Constructor -----
        public Product(string maSP, string tenSP, decimal price, int quantity)
        {
            MaSP = maSP;
            TenSP = tenSP;
            Price = price;
            Quantity = quantity;
        }

        // Trị giá tồn kho của riêng sản phẩm này = đơn giá * số lượng
        public decimal ThanhTien()
        {
            return Price * Quantity;
        }

        // ----- Override ToString để in thông tin sản phẩm gọn gàng -----
        public override string ToString()
        {
            return $"Mã: {MaSP,-8} | Tên: {TenSP,-20} | Giá: {Price,10:N0} | SL: {Quantity,5} | Thành tiền: {ThanhTien(),15:N0}";
        }
    }
}
