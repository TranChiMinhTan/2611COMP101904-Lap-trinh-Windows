using System;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    // Form chính của ứng dụng, dạng MDI Parent (IsMdiContainer = true,
    // đặt trong Designer). Các màn hình quản lý (FrmProduct, FrmCustomer)
    // sẽ được mở BÊN TRONG Form này dưới dạng Form con MDI.
    public partial class FrmMain : Form
    {
        // Thông tin người dùng đang đăng nhập - được truyền từ FrmLogin
        // sang qua CONSTRUCTOR bên dưới (xem câu hỏi 3, 5 trong README).
        private User nguoiDungHienTai;

        // Giữ tham chiếu tới Form con đang mở (nếu có) để kiểm tra
        // "đã mở hay chưa" trước khi tạo mới - tránh mở trùng Form
        // (xem câu hỏi 4 trong README).
        private FrmProduct frmProductDangMo;
        private FrmCustomer frmCustomerDangMo;

        // true nếu FrmMain đóng vì người dùng chọn "Đăng xuất" (Program.cs đọc
        // giá trị này để biết cần mở lại FrmLogin hay thoát chương trình).
        public bool DaDangXuat { get; private set; }

        // Constructor nhận vào User đã đăng nhập thành công từ FrmLogin.
        public FrmMain(User nguoiDung)
        {
            InitializeComponent();
            nguoiDungHienTai = nguoiDung;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            HienThiThongTinNguoiDung();
            tmrDongHo.Start();
        }

        // Hiển thị tên người dùng + vai trò lên StatusStrip và tiêu đề Form
        private void HienThiThongTinNguoiDung()
        {
            if (nguoiDungHienTai == null)
            {
                return;
            }

            lblNguoiDung.Text = "Người dùng: " + nguoiDungHienTai.HoTen;
            lblVaiTro.Text = "Vai trò: " + nguoiDungHienTai.VaiTro;
            this.Text = "ShopManagerMini - Xin chào " + nguoiDungHienTai.HoTen;
        }

        // Timer chạy mỗi giây để cập nhật đồng hồ trên StatusStrip
        private void tmrDongHo_Tick(object sender, EventArgs e)
        {
            lblThoiGian.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
        }

        // ================= MỞ FORM CON MDI (KHÔNG MỞ TRÙNG) =================

        private void mnuQuanLySanPham_Click(object sender, EventArgs e)
        {
            // Nếu Form con này CHƯA từng mở, hoặc đã mở nhưng đã bị đóng
            // (IsDisposed = true) thì mới tạo đối tượng mới.
            if (frmProductDangMo == null || frmProductDangMo.IsDisposed)
            {
                frmProductDangMo = new FrmProduct();
                frmProductDangMo.MdiParent = this; // mở BÊN TRONG FrmMain, không phải cửa sổ rời
                frmProductDangMo.FormClosed += frmProductDangMo_FormClosed;
                frmProductDangMo.Show();
            }
            else
            {
                // Đã có Form đang mở -> chỉ kích hoạt lại, không tạo Form mới
                KichHoatFormCon(frmProductDangMo);
            }
        }

        private void frmProductDangMo_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Khi Form con bị đóng, trả biến về null để lần bấm menu sau
            // sẽ tạo Form mới thay vì dùng lại Form đã bị hủy.
            frmProductDangMo = null;
        }

        private void mnuQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            if (frmCustomerDangMo == null || frmCustomerDangMo.IsDisposed)
            {
                frmCustomerDangMo = new FrmCustomer();
                frmCustomerDangMo.MdiParent = this;
                frmCustomerDangMo.FormClosed += frmCustomerDangMo_FormClosed;
                frmCustomerDangMo.Show();
            }
            else
            {
                KichHoatFormCon(frmCustomerDangMo);
            }
        }

        private void frmCustomerDangMo_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCustomerDangMo = null;
        }

        // Đưa Form con đang mở lên trên cùng và phục hồi nếu đang Minimized
        private void KichHoatFormCon(Form formCon)
        {
            if (formCon.WindowState == FormWindowState.Minimized)
            {
                formCon.WindowState = FormWindowState.Normal;
            }
            formCon.Activate();
        }

        // ================= GIỚI THIỆU =================
        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            // FrmAbout chỉ là hộp thoại thông tin tĩnh nên mở bằng
            // ShowDialog() thông thường, không mở như Form con MDI.
            using (FrmAbout frmAbout = new FrmAbout())
            {
                frmAbout.ShowDialog(this);
            }
        }

        // ================= ĐĂNG XUẤT =================
        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            // Đánh dấu là đăng xuất rồi đóng FrmMain (các Form con MDI tự đóng theo).
            // Program.cs thấy DaDangXuat = true sẽ mở lại FrmLogin.
            DaDangXuat = true;
            this.Close();
        }

        // ================= THOÁT =================
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            // Chỉ cần gọi Close(); việc hỏi xác nhận đã được xử lý tập
            // trung tại sự kiện FormClosing bên dưới (áp dụng cho cả
            // trường hợp bấm nút X trên tiêu đề Form).
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Đăng xuất đã được xác nhận ở trên nên không hỏi thêm lần nữa
            if (DaDangXuat)
            {
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
