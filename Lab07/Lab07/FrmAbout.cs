using System;
using System.Windows.Forms;

namespace ShopManagerMini.Forms
{
    // Form giới thiệu - mở bằng ShowDialog() (hộp thoại modal thông thường),
    // KHÔNG mở như Form con MDI vì đây chỉ là thông tin tĩnh, không phải
    // màn hình làm việc. Sinh viên hãy sửa 2 dòng Text ở lblSinhVien và
    // lblLop trong FrmAbout.Designer.cs (hoặc gán lại ở đây) thành thông
    // tin thật của mình trước khi nộp bài.
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();

            // TODO: sinh viên đổi 2 dòng dưới đây thành thông tin thật của mình
            lblSinhVien.Text = "Sinh viên: (Nhập họ tên của bạn vào đây)";
            lblLop.Text = "Lớp: (Nhập lớp của bạn vào đây)";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
