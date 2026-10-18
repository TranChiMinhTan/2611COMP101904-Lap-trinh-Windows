using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    // Form đăng nhập. Form này KHÔNG tự mở FrmMain - nó chỉ kiểm tra tài
    // khoản và trả kết quả (DialogResult + property NguoiDungDangNhap) cho
    // nơi đã gọi nó (ở đây là Program.cs). Cách làm này giúp FrmLogin
    // không phụ thuộc vào FrmMain, dễ tái sử dụng/kiểm thử độc lập.
    public partial class FrmLogin : Form
    {
        // Danh sách tài khoản mẫu (lưu tạm trong bộ nhớ - mục 5 đề bài)
        private List<User> danhSachTaiKhoan;

        // Sau khi đăng nhập thành công, nơi gọi FrmLogin (Program.cs) sẽ đọc
        // property này để lấy thông tin người dùng vừa đăng nhập.
        public User NguoiDungDangNhap { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            danhSachTaiKhoan = new List<User>
            {
                new User("admin", "123", "Quản trị viên", "Admin"),
                new User("user", "123", "Nhân viên bán hàng", "User"),
            };

            txtUsername.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text;

            // Kiểm tra bỏ trống username/password (yêu cầu 7.1)
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dò trong danh sách tài khoản mẫu (so sánh username không phân
            // biệt hoa/thường, mật khẩu thì phân biệt hoa/thường cho chặt chẽ)
            User taiKhoan = danhSachTaiKhoan.FirstOrDefault(tk =>
                tk.Username.Equals(tenDangNhap, StringComparison.OrdinalIgnoreCase) &&
                tk.Password == matKhau);

            if (taiKhoan == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.",
                    "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // Đăng nhập thành công: lưu lại thông tin người dùng, đóng Form
            // với DialogResult.OK để nơi gọi (Program.cs) biết là thành công.
            NguoiDungDangNhap = taiKhoan;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
