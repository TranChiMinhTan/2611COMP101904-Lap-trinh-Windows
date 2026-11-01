namespace QLSinhVienLab12.Models
{
    /// <summary>Kết quả của một lần lưu thành công.</summary>
    public class KetQuaLuu
    {
        public int SoThemMoi { get; set; }
        public int SoCapNhat { get; set; }
        public int TongSoDong { get { return SoThemMoi + SoCapNhat; } }
    }
}
