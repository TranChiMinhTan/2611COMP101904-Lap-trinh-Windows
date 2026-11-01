namespace QLSinhVienLab12.Models
{
    /// <summary>Một dòng điểm đã được kiểm tra hợp lệ, sẵn sàng lưu xuống database.</summary>
    public class KetQuaDong
    {
        public string MaSV { get; set; }
        public decimal Diem { get; set; }
        public string GhiChu { get; set; }   // null nếu để trống
    }
}
