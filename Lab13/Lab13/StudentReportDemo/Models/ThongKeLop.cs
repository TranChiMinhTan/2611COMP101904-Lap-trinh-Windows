namespace StudentReportDemo.Models
{
    /// <summary>Một dòng thống kê (một lớp, hoặc dòng "Tổng cộng").</summary>
    public class ThongKeLop
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int SoSinhVien { get; set; }
        public int SoDat { get; set; }
        public int SoKhongDat { get; set; }
        public double DiemTrungBinh { get; set; }
        public double DiemCaoNhat { get; set; }
        public double DiemThapNhat { get; set; }
    }
}
