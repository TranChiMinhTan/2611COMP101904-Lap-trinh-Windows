using System;
using System.Windows.Forms;

namespace CourseRegistrationApp
{
    internal static class Program
    {
        // Điểm bắt đầu (entry point) của ứng dụng WinForms.
        [STAThread]
        static void Main()
        {
            // Bật giao diện theo phong cách Windows hiện đại (visual styles)
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy Form chính của ứng dụng
            Application.Run(new FrmDangKyKhoaHoc());
        }
    }
}
