using System;

namespace QuanLySanPham
{
    // ============================================================
    // EXCEPTION TỰ TẠO: DuplicateProductException
    // Phát sinh khi thêm sản phẩm có mã đã tồn tại trong kho.
    // Kế thừa từ Exception để tận dụng cơ chế try-catch có sẵn của C#.
    // ============================================================
    public class DuplicateProductException : Exception
    {
        // Constructor mặc định
        public DuplicateProductException()
            : base("Sản phẩm đã tồn tại.")
        {
        }

        // Constructor có message tùy chỉnh - nơi throw exception này
        // sẽ tự soạn message (ví dụ có kèm mã sản phẩm bị trùng).
        public DuplicateProductException(string message)
            : base(message)
        {
        }
    }
}
