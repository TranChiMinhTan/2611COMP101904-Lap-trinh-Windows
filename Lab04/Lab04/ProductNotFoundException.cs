using System;

namespace QuanLySanPham
{
    // ============================================================
    // EXCEPTION TỰ TẠO: ProductNotFoundException
    // Phát sinh khi sửa hoặc xóa một sản phẩm không tồn tại
    // trong kho (không tìm thấy theo mã).
    // ============================================================
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException()
            : base("Không tìm thấy sản phẩm.")
        {
        }

        public ProductNotFoundException(string message)
            : base(message)
        {
        }
    }
}
