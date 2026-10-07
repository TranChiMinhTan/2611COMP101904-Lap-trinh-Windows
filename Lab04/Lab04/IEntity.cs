namespace QuanLySanPham
{
    // ============================================================
    // INTERFACE: IEntity
    // Dùng làm ràng buộc (constraint) cho generic class Repository<T>.
    // Bất kỳ lớp nào muốn được Repository<T> quản lý đều phải có
    // thuộc tính Id để có thể tìm kiếm / xác định là trùng hay không.
    // ============================================================
    public interface IEntity
    {
        string Id { get; }
    }
}
