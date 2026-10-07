namespace CourseRegistrationApp
{
    // ============================================================
    // KhoaHoc
    // Lớp đơn giản đại diện cho 1 khóa học: tên và học phí/tháng.
    // Dùng để nạp dữ liệu vào ComboBox (cboKhoaHoc) trên Form.
    // ============================================================
    public class KhoaHoc
    {
        public string TenKhoaHoc { get; set; }
        public decimal HocPhiThang { get; set; }

        public KhoaHoc(string tenKhoaHoc, decimal hocPhiThang)
        {
            TenKhoaHoc = tenKhoaHoc;
            HocPhiThang = hocPhiThang;
        }

        // ComboBox sẽ dùng DisplayMember = "TenKhoaHoc" để hiển thị,
        // nhưng vẫn override ToString() để phòng khi cần in trực tiếp.
        public override string ToString()
        {
            return TenKhoaHoc;
        }
    }
}
