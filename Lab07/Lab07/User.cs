namespace ShopManagerMini.Models
{
    // ============================================================
    // User
    // Đại diện cho 1 tài khoản đăng nhập (username/password) kèm
    // thông tin hiển thị: họ tên và vai trò (Admin / User).
    // Đây chính là đối tượng được truyền từ FrmLogin sang FrmMain
    // sau khi đăng nhập thành công (xem câu hỏi 3 trong README).
    // ============================================================
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; } // "Admin" hoặc "User"

        public User()
        {
        }

        public User(string username, string password, string hoTen, string vaiTro)
        {
            Username = username;
            Password = password;
            HoTen = hoTen;
            VaiTro = vaiTro;
        }
    }
}
