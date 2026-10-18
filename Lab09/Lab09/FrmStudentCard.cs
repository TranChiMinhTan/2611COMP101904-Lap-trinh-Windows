using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace COMP1019_Lab09_StudentCard
{
    // Form chính: nhập thông tin -> xem trước thẻ -> xem trước in -> in.
    //
    // Ý tưởng chính của bài:
    //   1. Dữ liệu nhập chỉ nằm trên các control; mỗi lần đổi dữ liệu ta gọi
    //      pnlPreview.Invalidate() để Panel tự vẽ lại bằng GDI+ (sự kiện Paint).
    //   2. Preview, in và lưu PNG đều gọi chung CardRenderer.Draw(...).
    //   3. Ảnh đại diện được COPY sang Bitmap rồi mới dùng, nên file ảnh gốc
    //      không bị khóa và đổi ảnh nhiều lần không bị lỗi.
    public partial class FrmStudentCard : Form
    {
        // Kích thước thẻ khi in = kích thước thật 85,6 mm ~ 3,37 inch.
        // Khi in, đơn vị của Graphics là 1/100 inch => 337 đơn vị.
        private const int PrintCardWidth = 337;

        // Ảnh đại diện đang dùng (null nếu chưa chọn). Là đối tượng GDI+ nên phải Dispose.
        private Bitmap avatarImage;

        // Màu chủ đạo của thẻ (đổi bằng nút "Màu thẻ")
        private Color cardColor = CardRenderer.DefaultThemeColor;

        public FrmStudentCard()
        {
            InitializeComponent();
        }

        // ================= LOAD FORM =================
        private void FrmStudentCard_Load(object sender, EventArgs e)
        {
            // Danh sách mẫu cho các ComboBox
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboLop.Items.AddRange(new object[] { "CNTT49A", "CNTT49B", "CNTT50A", "KTPM50A", "HTTT51A", "ATTT51B" });
            cboKhoa.Items.AddRange(new object[]
            {
                "Công nghệ thông tin",
                "Toán - Tin học",
                "Vật lý",
                "Ngoại ngữ",
                "Giáo dục tiểu học"
            });
            cboKhoaHoc.Items.AddRange(new object[] { "K49", "K50", "K51" });

            // Ngày sinh không được ở tương lai
            dtpNgaySinh.MaxDate = DateTime.Today;

            ResetForm();
        }

        // ================= HÀM TIỆN ÍCH =================

        // Gom dữ liệu trên Form thành 1 đối tượng StudentInfo để truyền cho CardRenderer
        private StudentInfo GetStudentInfo()
        {
            return new StudentInfo
            {
                MaSV = txtMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = cboGioiTinh.Text,
                Lop = cboLop.Text,
                Khoa = cboKhoa.Text,
                KhoaHoc = cboKhoaHoc.Text
            };
        }

        // Thay ảnh đại diện: gán ảnh mới rồi mới Dispose ảnh cũ (newImage có thể là null để xóa ảnh)
        private void SetAvatar(Bitmap newImage)
        {
            Bitmap oldImage = avatarImage;
            avatarImage = newImage;
            picAnh.Image = avatarImage;

            if (oldImage != null)
            {
                oldImage.Dispose();
            }

            pnlPreview.Invalidate();
        }

        // Đọc ảnh từ file mà KHÔNG khóa file: đọc xong là đóng luồng, ảnh dùng là bản sao trong bộ nhớ.
        private void LoadAvatar(string filePath)
        {
            try
            {
                Bitmap copy;
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (Image original = Image.FromStream(stream))
                {
                    copy = new Bitmap(original);
                }

                SetAvatar(copy);
                lblTenFileAnh.Text = Path.GetFileName(filePath);
            }
            catch (Exception ex)
            {
                // File hỏng, không phải ảnh thật (vd đổi đuôi .txt thành .png), hết bộ nhớ, ...
                // Ảnh cũ (nếu có) vẫn được giữ nguyên.
                MessageBox.Show("Không đọc được file ảnh này.\n\nChi tiết: " + ex.Message,
                    "Lỗi mở ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // F3 - Validation: kiểm tra Mã SV, Họ tên, Ảnh. Báo tất cả lỗi cùng lúc,
        // rồi đưa con trỏ về ô lỗi đầu tiên.
        private bool ValidateRequiredFields()
        {
            List<string> errors = new List<string>();
            Control firstInvalid = null;

            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                errors.Add("- Chưa nhập Mã sinh viên.");
                firstInvalid = txtMaSV;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errors.Add("- Chưa nhập Họ tên.");
                if (firstInvalid == null)
                {
                    firstInvalid = txtHoTen;
                }
            }

            if (avatarImage == null)
            {
                errors.Add("- Chưa chọn Ảnh đại diện.");
                if (firstInvalid == null)
                {
                    firstInvalid = btnChonAnh;
                }
            }

            if (errors.Count == 0)
            {
                return true;
            }

            MessageBox.Show(
                "Vui lòng bổ sung thông tin bắt buộc:\n\n" + string.Join("\n", errors),
                "Thiếu dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            firstInvalid.Focus();
            return false;
        }

        // F6 - Đưa Form về trạng thái ban đầu
        private void ResetForm()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Today.AddYears(-20);
            cboGioiTinh.SelectedIndex = 0;
            cboLop.SelectedIndex = 0;
            cboKhoa.SelectedIndex = 0;
            cboKhoaHoc.SelectedIndex = 0;

            cardColor = CardRenderer.DefaultThemeColor;
            SetAvatar(null);
            lblTenFileAnh.Text = "(Chưa chọn ảnh)";

            pnlPreview.Invalidate();
            txtMaSV.Focus();
        }

        // ================= F2: PREVIEW THẺ BẰNG GDI+ =================

        // Mọi control nhập liệu đều dùng chung handler này: dữ liệu đổi -> vẽ lại thẻ
        private void InputChanged(object sender, EventArgs e)
        {
            pnlPreview.Invalidate();
        }

        private void pnlPreview_Paint(object sender, PaintEventArgs e)
        {
            Rectangle cardRect = CardRenderer.FitCardInto(pnlPreview.ClientRectangle, 24);
            CardRenderer.Draw(e.Graphics, cardRect, GetStudentInfo(), avatarImage, cardColor);
        }

        // ================= F1: CHỌN ẢNH =================
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn ảnh đại diện";
                dialog.Filter = "Tệp ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                dialog.CheckFileExists = true;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    LoadAvatar(dialog.FileName);
                }
            }
        }

        // ================= F4: XEM TRƯỚC KHI IN =================
        private void btnXemTruocIn_Click(object sender, EventArgs e)
        {
            if (!ValidateRequiredFields())
            {
                return;
            }

            try
            {
                using (PrintPreviewDialog previewDialog = new PrintPreviewDialog())
                {
                    previewDialog.Document = printDocument;
                    previewDialog.StartPosition = FormStartPosition.CenterParent;
                    previewDialog.Width = 900;
                    previewDialog.Height = 700;
                    previewDialog.ShowDialog(this);
                }
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("Máy tính chưa cài đặt máy in nào nên không thể xem trước bản in.\n" +
                    "Hãy cài một máy in (có thể dùng \"Microsoft Print to PDF\") rồi thử lại.",
                    "Không có máy in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ================= F5: IN =================
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!ValidateRequiredFields())
            {
                return;
            }

            try
            {
                using (PrintDialog printDialog = new PrintDialog())
                {
                    printDialog.Document = printDocument;

                    if (printDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        printDocument.Print(); // sẽ phát sinh sự kiện PrintPage bên dưới
                    }
                }
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("Máy tính chưa cài đặt máy in nào nên không thể in.",
                    "Không có máy in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show("Lỗi khi in: " + ex.Message, "Lỗi in ấn",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện PrintPage: định nghĩa NỘI DUNG của mỗi trang in.
        // Được gọi cả khi Print Preview lẫn khi in thật.
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // e.MarginBounds: vùng in bên trong lề (đơn vị 1/100 inch)
            Rectangle margin = e.MarginBounds;

            // Thẻ in đúng kích thước thật, đặt giữa trang theo chiều ngang, sát lề trên
            int cardWidth = Math.Min(PrintCardWidth, margin.Width);
            int cardHeight = (int)Math.Round(cardWidth / CardRenderer.CardAspectRatio);
            int cardLeft = margin.Left + (margin.Width - cardWidth) / 2;
            Rectangle cardRect = new Rectangle(cardLeft, margin.Top, cardWidth, cardHeight);

            // Vẽ bằng đúng hàm đã dùng cho preview => ảnh không méo, bố cục giống hệt
            CardRenderer.Draw(e.Graphics, cardRect, GetStudentInfo(), avatarImage, cardColor);

            e.HasMorePages = false; // chỉ 1 trang
        }

        // ================= LÀM MỚI / THOÁT =================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        // ================= MỞ RỘNG: MÀU THẺ & LƯU PNG =================
        private void btnMauThe_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = cardColor;
                dialog.FullOpen = true;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    cardColor = dialog.Color;
                    pnlPreview.Invalidate();
                }
            }
        }

        private void btnLuuPng_Click(object sender, EventArgs e)
        {
            if (!ValidateRequiredFields())
            {
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Lưu thẻ sinh viên";
                dialog.Filter = "Ảnh PNG (*.png)|*.png";
                dialog.FileName = "TheSinhVien.png";

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    // 1012 px ~ 300 DPI cho thẻ rộng 85,6 mm
                    int width = 1012;
                    int height = (int)Math.Round(width / CardRenderer.CardAspectRatio);

                    using (Bitmap bitmap = new Bitmap(width, height))
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.Clear(Color.Transparent);
                        CardRenderer.Draw(g, new Rectangle(0, 0, width, height), GetStudentInfo(), avatarImage, cardColor);
                        bitmap.Save(dialog.FileName, ImageFormat.Png);
                    }

                    MessageBox.Show("Đã lưu thẻ thành công.", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không lưu được file: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Giải phóng ảnh đại diện khi đóng Form
        private void FrmStudentCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (avatarImage != null)
            {
                picAnh.Image = null;
                avatarImage.Dispose();
                avatarImage = null;
            }
        }
    }
}
