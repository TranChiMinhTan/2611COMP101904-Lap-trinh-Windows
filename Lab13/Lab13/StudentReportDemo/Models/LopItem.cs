namespace StudentReportDemo.Models
{
    /// <summary>Mục của ComboBox lớp. MaLop = null nghĩa là "Tất cả các lớp".</summary>
    public class LopItem
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }

        // ComboBox hiển thị kết quả của ToString()
        public override string ToString()
        {
            return MaLop == null ? TenLop : MaLop + " - " + TenLop;
        }
    }
}
