using System;
using System.Windows.Forms;
using ShopManagerMini.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Vòng lặp: Đăng nhập -> Form chính -> (nếu chọn Đăng xuất) quay lại Đăng nhập.
            // Thoát hẳn khi người dùng đóng/hủy FrmLogin hoặc thoát FrmMain mà không đăng xuất.
            while (true)
            {
                User nguoiDung;

                // ShowDialog() hiển thị FrmLogin dạng MODAL: chương trình dừng tại
                // đây chờ đăng nhập xong rồi mới chạy tiếp (xem câu hỏi 2 trong README).
                using (FrmLogin frmLogin = new FrmLogin())
                {
                    if (frmLogin.ShowDialog() != DialogResult.OK)
                    {
                        break; // bấm Thoát hoặc đóng FrmLogin -> kết thúc chương trình
                    }
                    nguoiDung = frmLogin.NguoiDungDangNhap;
                }

                // Truyền thông tin người dùng sang FrmMain qua CONSTRUCTOR
                // (xem câu hỏi 3 và 5 trong README).
                FrmMain frmMain = new FrmMain(nguoiDung);
                Application.Run(frmMain);

                if (!frmMain.DaDangXuat)
                {
                    break; // thoát chương trình bình thường (không phải đăng xuất)
                }
            }
        }
    }
}
