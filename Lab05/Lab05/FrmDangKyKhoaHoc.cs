using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseRegistrationApp
{
    // Form chính: ĐĂNG KÝ KHÓA HỌC.
    // File này CHỈ chứa logic xử lý (các sự kiện). Phần khai báo và
    // bố trí control (vị trí, kích thước...) nằm ở file
    // FrmDangKyKhoaHoc.Designer.cs - đúng với cách WinForms tách 2 file.
    public partial class FrmDangKyKhoaHoc : Form
    {
        // Danh sách khóa học kèm học phí/tháng, dùng để nạp vào cboKhoaHoc
        // và tra cứu lại học phí khi tính tổng tiền.
        private List<KhoaHoc> danhSachKhoaHoc;

        public FrmDangKyKhoaHoc()
        {
            InitializeComponent();
        }

        // ================= SỰ KIỆN LOAD CỦA FORM =================
        private void FrmDangKyKhoaHoc_Load(object sender, EventArgs e)
        {
            // 1) Khởi tạo dữ liệu khóa học (mục 4 trong đề bài)
            danhSachKhoaHoc = new List<KhoaHoc>
            {
                new KhoaHoc("C# WinForms cơ bản", 800000),
                new KhoaHoc("SQL Server cơ bản", 700000),
                new KhoaHoc("Web Frontend cơ bản", 750000),
                new KhoaHoc("Lập trình Python cơ bản", 650000),
            };

            // 2) Nạp danh sách khóa học vào ComboBox, chọn khóa học đầu tiên
            cboKhoaHoc.DataSource = danhSachKhoaHoc;
            cboKhoaHoc.DisplayMember = "TenKhoaHoc";
            cboKhoaHoc.SelectedIndex = 0;

            // 3) Chọn mặc định hình thức học là Online
            radOnline.Checked = true;

            // 4) Số tháng đăng ký: tối thiểu 1, tối đa 12, mặc định 1
            numSoThang.Minimum = 1;
            numSoThang.Maximum = 12;
            numSoThang.Value = 1;

            // Ngày sinh mặc định là hôm nay, người dùng sẽ tự chọn lại
            dtpNgaySinh.Value = DateTime.Now;

            // 5) Hiển thị tổng học phí ban đầu
            CapNhatTongTien();
        }

        // ================= TÍNH & HIỂN THỊ TỔNG HỌC PHÍ =================
        // Tách thành 1 hàm riêng vì được gọi lại ở nhiều nơi:
        // khi Form Load, khi đổi khóa học, khi đổi số tháng, khi Làm mới.
        private void CapNhatTongTien()
        {
            KhoaHoc khoaHocDangChon = cboKhoaHoc.SelectedItem as KhoaHoc;
            if (khoaHocDangChon == null)
            {
                lblTongTien.Text = "0 VNĐ";
                return;
            }

            decimal tongTien = khoaHocDangChon.HocPhiThang * numSoThang.Value;
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        // Sự kiện SelectedIndexChanged: người dùng đổi khóa học
        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        // Sự kiện ValueChanged: người dùng đổi số tháng đăng ký
        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        // ================= NÚT ĐĂNG KÝ (mục 5.2) =================
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // ----- Kiểm tra họ tên -----
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            // ----- Kiểm tra số điện thoại -----
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            // ----- Kiểm tra đã chọn khóa học -----
            KhoaHoc khoaHocDangChon = cboKhoaHoc.SelectedItem as KhoaHoc;
            if (khoaHocDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn khóa học.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoaHoc.Focus();
                return;
            }

            // ----- Tính tổng học phí = học phí 1 tháng x số tháng -----
            int soThang = (int)numSoThang.Value;
            decimal tongTien = khoaHocDangChon.HocPhiThang * soThang;

            string hinhThucHoc = radOnline.Checked ? "Online" : "Trực tiếp";
            string trangThaiEmail = chkNhanEmail.Checked ? "Có" : "Không";

            // ----- Soạn nội dung phiếu đăng ký -----
            string phieuDangKy =
                "PHIẾU ĐĂNG KÝ KHÓA HỌC" + Environment.NewLine +
                "-----------------------------------" + Environment.NewLine +
                "Họ tên: " + txtHoTen.Text.Trim() + Environment.NewLine +
                "Số điện thoại: " + txtSoDienThoai.Text.Trim() + Environment.NewLine +
                "Ngày sinh: " + dtpNgaySinh.Value.ToString("dd/MM/yyyy") + Environment.NewLine +
                "Khóa học: " + khoaHocDangChon.TenKhoaHoc + Environment.NewLine +
                "Hình thức học: " + hinhThucHoc + Environment.NewLine +
                "Số tháng đăng ký: " + soThang + Environment.NewLine +
                "Tổng học phí: " + tongTien.ToString("N0") + " VNĐ" + Environment.NewLine +
                "Nhận email thông báo: " + trangThaiEmail;

            MessageBox.Show(phieuDangKy, "Đăng ký thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= NÚT LÀM MỚI (mục 5.3) =================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            chkNhanEmail.Checked = false;
            cboKhoaHoc.SelectedIndex = 0;
            radOnline.Checked = true;
            numSoThang.Value = 1;

            // Số tháng/khóa học vừa reset -> tính lại tổng tiền hiển thị
            CapNhatTongTien();

            // Đưa con trỏ về ô họ tên để người dùng nhập lại ngay
            txtHoTen.Focus();
        }

        // ================= NÚT THOÁT (mục 5.4) =================
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
