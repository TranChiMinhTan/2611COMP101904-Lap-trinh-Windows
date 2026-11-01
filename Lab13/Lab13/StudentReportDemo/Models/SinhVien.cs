namespace StudentReportDemo.Models
{
    /// <summary>Một sinh viên trong báo cáo.</summary>
    public class SinhVien
    {
        public const double DiemDat = 5.0;   // từ 5 điểm trở lên là Đạt

        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public double Diem { get; set; }     // điểm trung bình

        /// <summary>Chỉ đọc: tự suy ra từ Diem, không lưu riêng nên không bao giờ lệch điểm.</summary>
        public string KetQua
        {
            get { return Diem >= DiemDat ? "Đạt" : "Không đạt"; }
        }

        public SinhVien() { }

        public SinhVien(string maSV, string hoTen, string maLop, string tenLop, double diem)
        {
            MaSV = maSV;
            HoTen = hoTen;
            MaLop = maLop;
            TenLop = tenLop;
            Diem = diem;
        }
    }
}
