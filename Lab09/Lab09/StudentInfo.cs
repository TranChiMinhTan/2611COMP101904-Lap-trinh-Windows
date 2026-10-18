using System;

namespace COMP1019_Lab09_StudentCard
{
    // Lớp dữ liệu: gom thông tin sinh viên đang nhập trên Form lại thành
    // 1 đối tượng để truyền cho CardRenderer vẽ (preview, in, lưu PNG).
    // Ảnh đại diện không để trong này vì Image cần được quản lý/giải phóng riêng.
    public class StudentInfo
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }
        public string KhoaHoc { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
    }
}
