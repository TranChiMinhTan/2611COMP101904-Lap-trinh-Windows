using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Kiểm tra họ tên
        private bool KiemTraHoTen()
        {
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Họ tên không được để trống!");
                txtHoTen.Focus();
                return false;
            }

            return true;
        }

        // Kiểm tra năm sinh
        private bool KiemTraNamSinh()
        {
            int namSinh;

            if (txtNamSinh.Text.Trim() == "")
            {
                MessageBox.Show("Năm sinh không được để trống!");
                txtNamSinh.Focus();
                return false;
            }

            if (!int.TryParse(txtNamSinh.Text, out namSinh))
            {
                MessageBox.Show("Năm sinh phải là số!");
                txtNamSinh.Focus();
                return false;
            }

            int namHienTai = DateTime.Now.Year;

            if (namSinh < 1900 || namSinh > namHienTai)
            {
                MessageBox.Show("Năm sinh không hợp lệ!");
                txtNamSinh.Focus();
                return false;
            }

            return true;
        }

        // Kiểm tra Email
        private bool KiemTraEmail()
        {
            string email = txtEmail.Text.Trim();

            if (email == "")
            {
                MessageBox.Show("Email không được để trống!");
                txtEmail.Focus();
                return false;
            }

            string mauEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, mauEmail))
            {
                MessageBox.Show("Email không đúng định dạng!");
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        // Kiểm tra giới tính
        private bool KiemTraGioiTinh()
        {
            if (!rdoNam.Checked && !rdoNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return false;
            }

            return true;
        }

        // Kiểm tra Khoa/Lớp
        private bool KiemTraKhoaLop()
        {
            if (cboKhoaLop.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Khoa/Lớp!");
                cboKhoaLop.Focus();
                return false;
            }

            return true;
        }

        // Kiểm tra tất cả dữ liệu
        private bool KiemTraDuLieu()
        {
            if (!KiemTraHoTen())
            {
                return false;
            }

            if (!KiemTraNamSinh())
            {
                return false;
            }

            if (!KiemTraEmail())
            {
                return false;
            }

            if (!KiemTraGioiTinh())
            {
                return false;
            }

            if (!KiemTraKhoaLop())
            {
                return false;
            }

            return true;
        }

        // Lấy giới tính
        private string LayGioiTinh()
        {
            if (rdoNam.Checked)
            {
                return "Nam";
            }

            return "Nữ";
        }

        // Hiển thị thông tin
        private void HienThiThongTin()
        {
            string hoTen = txtHoTen.Text.Trim();
            int namSinh = int.Parse(txtNamSinh.Text.Trim());
            string email = txtEmail.Text.Trim();
            string gioiTinh = LayGioiTinh();
            string khoaLop = cboKhoaLop.Text;

            int tuoi = DateTime.Now.Year - namSinh;

            StringBuilder ketQua = new StringBuilder();

            ketQua.AppendLine("THÔNG TIN SINH VIÊN");
            ketQua.AppendLine("Họ tên: " + hoTen);
            ketQua.AppendLine("Tuổi: " + tuoi);
            ketQua.AppendLine("Email: " + email);
            ketQua.AppendLine("Giới tính: " + gioiTinh);
            ketQua.AppendLine("Khoa/Lớp: " + khoaLop);

            txtKetQua.Text = ketQua.ToString();
        }


        private void btnHienThi_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                HienThiThongTin();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();

            rdoNam.Checked = false;
            rdoNu.Checked = false;

            cboKhoaLop.SelectedIndex = -1;

            txtKetQua.Clear();

            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ketQua = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}