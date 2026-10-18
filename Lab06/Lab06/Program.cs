using System;
using System.Windows.Forms;

namespace ProductManager
{
    internal static class Program
    {
        // Điểm bắt đầu (entry point) của ứng dụng WinForms.
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FrmProduct());
        }
    }
}
