using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLySanPham
{
    // ============================================================
    // GENERIC CLASS: Repository<T>
    // Đóng vai trò như một "kho lưu trữ" trong bộ nhớ, có thể dùng
    // lại cho BẤT KỲ loại đối tượng nào, miễn là T implement IEntity
    // (ràng buộc "where T : IEntity" bên dưới).
    //
    // Repository<T> KHÔNG biết gì về nghiệp vụ (ví dụ không biết
    // "sản phẩm trùng mã thì phải làm gì") - việc đó do ProductService
    // đảm nhiệm. Repository<T> chỉ lo việc lưu trữ/tìm kiếm thuần túy.
    // ============================================================
    public class Repository<T> where T : IEntity
    {
        // Danh sách lưu trữ dữ liệu trong bộ nhớ
        private List<T> danhSach = new List<T>();

        // ----- Thêm một phần tử vào kho -----
        public void Add(T item)
        {
            danhSach.Add(item);
        }

        // ----- Xóa một phần tử khỏi kho -----
        // Trả về true nếu xóa thành công, false nếu không tìm thấy.
        public bool Remove(string id)
        {
            T item = FindById(id);
            if (item == null)
            {
                return false;
            }
            return danhSach.Remove(item);
        }

        // ----- Tìm một phần tử theo Id -----
        // Trả về null nếu không tìm thấy (không throw exception ở đây,
        // vì Repository<T> chỉ là kho dữ liệu thuần túy; việc quyết định
        // "không tìm thấy thì phải throw exception gì" là của tầng
        // nghiệp vụ (ProductService) - nơi hiểu rõ ngữ cảnh hơn.
        public T FindById(string id)
        {
            return danhSach.FirstOrDefault(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        // ----- Tìm kiếm theo điều kiện tùy ý -----
        // Đây chính là nơi sử dụng Func<T, bool>: người gọi truyền vào
        // một "điều kiện lọc" dưới dạng hàm, Repository<T> sẽ áp dụng
        // điều kiện đó cho từng phần tử để lọc ra kết quả phù hợp.
        public List<T> Find(Func<T, bool> dieuKien)
        {
            return danhSach.Where(dieuKien).ToList();
        }

        // ----- Lấy toàn bộ dữ liệu trong kho -----
        public List<T> GetAll()
        {
            return danhSach;
        }

        // ----- Đếm số lượng phần tử hiện có -----
        public int Count()
        {
            return danhSach.Count;
        }
    }
}
