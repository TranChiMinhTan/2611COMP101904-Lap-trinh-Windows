using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLySanPham
{
    // ============================================================
    // ProductService
    // Đây là tầng "nghiệp vụ" (business logic): kiểm tra dữ liệu hợp lệ,
    // kiểm tra trùng mã / không tồn tại, rồi mới gọi xuống Repository<T>
    // để thao tác dữ liệu thật sự. Đồng thời, ProductService cũng là
    // nơi PHÁT SINH (fire) các event khi thêm/xóa thành công.
    // ============================================================
    public class ProductService
    {
        private readonly Repository<Product> repository;

        // ----- DELEGATE/EVENT -----
        // Action<Product> là một delegate có sẵn của .NET, đại diện cho
        // "một hàm nhận vào 1 tham số Product và không trả về giá trị gì".
        // Khai báo "event" phía trước để chỉ Program.cs (hoặc bất kỳ lớp
        // nào khác) được ĐĂNG KÝ (+=) lắng nghe, chứ không được tự ý
        // gọi (invoke) sự kiện này từ bên ngoài ProductService.
        public event Action<Product> ProductAdded;
        public event Action<Product> ProductRemoved;

        public ProductService(Repository<Product> repository)
        {
            this.repository = repository;
        }

        // ----- Thêm sản phẩm -----
        public void AddProduct(string maSP, string tenSP, decimal price, int quantity)
        {
            // Kiểm tra mã không được rỗng
            if (string.IsNullOrWhiteSpace(maSP))
            {
                throw new ArgumentException("Mã sản phẩm không được để trống.");
            }

            // Kiểm tra trùng mã -> ném exception tự tạo
            if (repository.FindById(maSP) != null)
            {
                throw new DuplicateProductException(
                    $"Sản phẩm với mã '{maSP}' đã tồn tại trong kho.");
            }

            // Product constructor sẽ tự kiểm tra Price/Quantity không âm
            // (ném ArgumentException nếu sai) trước khi được thêm vào kho.
            Product sanPham = new Product(maSP, tenSP, price, quantity);
            repository.Add(sanPham);

            // Phát sự kiện: thông báo cho những ai đang lắng nghe
            // (ví dụ Program.cs) biết rằng vừa có 1 sản phẩm được thêm.
            // "?." đảm bảo không lỗi nếu chưa có ai đăng ký lắng nghe.
            ProductAdded?.Invoke(sanPham);
        }

        // ----- Xóa sản phẩm -----
        public void RemoveProduct(string maSP)
        {
            Product sanPham = repository.FindById(maSP);
            if (sanPham == null)
            {
                throw new ProductNotFoundException(
                    $"Không tìm thấy sản phẩm có mã '{maSP}' để xóa.");
            }

            repository.Remove(maSP);

            // Phát sự kiện: thông báo vừa xóa thành công 1 sản phẩm.
            ProductRemoved?.Invoke(sanPham);
        }

        // ----- Tìm 1 sản phẩm theo mã (dùng cho chức năng 3) -----
        public Product FindById(string maSP)
        {
            Product sanPham = repository.FindById(maSP);
            if (sanPham == null)
            {
                throw new ProductNotFoundException(
                    $"Không tìm thấy sản phẩm có mã '{maSP}'.");
            }
            return sanPham;
        }

        // ----- Tìm theo tên (dùng cho chức năng 4) -----
        // Sử dụng Func<Product, bool>: điều kiện lọc được viết dưới dạng
        // một biểu thức lambda, truyền thẳng vào Repository.Find(...).
        public List<Product> Search(string keyword)
        {
            Func<Product, bool> dieuKien = sp =>
                sp.TenSP.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;

            return repository.Find(dieuKien);
        }

        // ----- Lọc theo khoảng giá (dùng cho chức năng 5) -----
        // Cũng sử dụng Func<Product, bool> giống như yêu cầu đề bài.
        public List<Product> Filter(decimal giaMin, decimal giaMax)
        {
            if (giaMin > giaMax)
            {
                throw new ArgumentException("Giá nhỏ nhất không được lớn hơn giá lớn nhất.");
            }

            Func<Product, bool> dieuKien = sp => sp.Price >= giaMin && sp.Price <= giaMax;

            return repository.Find(dieuKien);
        }

        // ----- Lấy toàn bộ danh sách sản phẩm (dùng cho chức năng 2) -----
        public List<Product> GetAll()
        {
            return repository.GetAll();
        }

        // ----- Tính tổng giá trị kho (dùng cho chức năng 7) -----
        public decimal TinhTongGiaTriKho()
        {
            return repository.GetAll().Sum(sp => sp.ThanhTien());
        }
    }
}
