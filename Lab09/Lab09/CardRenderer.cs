using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;

namespace COMP1019_Lab09_StudentCard
{
    // ============================================================
    // CardRenderer
    // Vẽ thẻ sinh viên bằng GDI+. Đây là MỘT hàm vẽ duy nhất (Draw) được
    // dùng chung cho cả 3 nơi:
    //   - Preview trên Panel (sự kiện Paint)
    //   - In / Print Preview (sự kiện PrintPage)
    //   - Lưu ra file PNG
    // => Hình xem trước, hình in và hình lưu luôn giống hệt nhau.
    //
    // Cách vẽ KHÔNG phụ thuộc kích thước tuyệt đối: mọi tọa độ, cỡ chữ đều
    // tính theo hệ số s = chiều cao thẻ / 100. Nhờ vậy thẻ to hay nhỏ
    // (màn hình, máy in, file PNG) đều giữ đúng bố cục.
    // ============================================================
    public static class CardRenderer
    {
        // Tên trường in ở đầu thẻ (đổi thành tên trường của bạn nếu cần)
        public const string SchoolName = "TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH";

        // Thẻ ngang kích thước chuẩn ISO ID-1: 85,6 mm x 54 mm
        public const float CardAspectRatio = 85.6f / 54f;

        public static readonly Color DefaultThemeColor = Color.FromArgb(0, 94, 150);

        // ----- Tính vị trí thẻ nằm giữa 1 vùng, giữ đúng tỉ lệ -----
        public static Rectangle FitCardInto(Rectangle area, int margin)
        {
            Rectangle inner = Rectangle.Inflate(area, -margin, -margin);
            if (inner.Width <= 0 || inner.Height <= 0)
            {
                return Rectangle.Empty;
            }

            int width = inner.Width;
            int height = (int)(width / CardAspectRatio);
            if (height > inner.Height)
            {
                height = inner.Height;
                width = (int)(height * CardAspectRatio);
            }

            int x = inner.X + (inner.Width - width) / 2;
            int y = inner.Y + (inner.Height - height) / 2;
            return new Rectangle(x, y, width, height);
        }

        // ----- Tính vùng vẽ ảnh sao cho KHÔNG MÉO -----
        // Co ảnh theo cùng 1 tỉ lệ cho cả chiều rộng và chiều cao (lấy tỉ lệ nhỏ
        // hơn để ảnh vừa khít trong khung), rồi canh giữa.
        public static RectangleF FitImage(Size imageSize, RectangleF frame)
        {
            float scale = Math.Min(frame.Width / imageSize.Width, frame.Height / imageSize.Height);
            float width = imageSize.Width * scale;
            float height = imageSize.Height * scale;
            return new RectangleF(
                frame.X + (frame.Width - width) / 2f,
                frame.Y + (frame.Height - height) / 2f,
                width,
                height);
        }

        // ============================================================
        // HÀM VẼ CHÍNH
        // card: hình chữ nhật của thẻ (đơn vị theo Graphics: pixel hoặc 1/100 inch khi in)
        // photo: ảnh đại diện (có thể null)
        // ============================================================
        public static void Draw(Graphics g, Rectangle card, StudentInfo info, Image photo, Color themeColor)
        {
            if (card.Width <= 0 || card.Height <= 0)
            {
                return;
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            float s = card.Height / 100f; // hệ số tỉ lệ
            RectangleF cardF = new RectangleF(card.X, card.Y, card.Width, card.Height);

            using (GraphicsPath cardPath = CreateRoundedRectangle(cardF, 5 * s))
            {
                DrawBackgroundAndHeader(g, cardPath, cardF, themeColor, s);
                DrawPhoto(g, cardF, photo, s);
                DrawStudentInfo(g, cardF, info, themeColor, s);

                // Khung ngoài của thẻ vẽ sau cùng để đè lên mép header
                using (Pen borderPen = new Pen(themeColor, 1.2f * s))
                {
                    g.DrawPath(borderPen, cardPath);
                }
            }
        }

        // ----- Nền thẻ (màu nhẹ) + dải tiêu đề -----
        private static void DrawBackgroundAndHeader(Graphics g, GraphicsPath cardPath, RectangleF cardF, Color themeColor, float s)
        {
            Color lightColor = Blend(themeColor, Color.White, 0.9f);
            using (LinearGradientBrush backBrush = new LinearGradientBrush(cardF, Color.White, lightColor, LinearGradientMode.ForwardDiagonal))
            {
                g.FillPath(backBrush, cardPath);
            }

            // Dải tiêu đề: cắt (clip) theo hình thẻ để 2 góc trên được bo tròn
            RectangleF headerRect = new RectangleF(cardF.X, cardF.Y, cardF.Width, 24 * s);
            g.SetClip(cardPath);
            using (SolidBrush headerBrush = new SolidBrush(themeColor))
            {
                g.FillRectangle(headerBrush, headerRect);
            }
            g.ResetClip();

            using (SolidBrush textBrush = new SolidBrush(GetContrastColor(themeColor)))
            using (Font schoolFont = new Font("Segoe UI", 6.4f * s, FontStyle.Regular, GraphicsUnit.Pixel))
            using (Font titleFont = new Font("Segoe UI", 9.5f * s, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                RectangleF schoolRect = new RectangleF(cardF.X + 3 * s, cardF.Y + 2.5f * s, cardF.Width - 6 * s, 9 * s);
                RectangleF titleRect = new RectangleF(cardF.X + 3 * s, cardF.Y + 11 * s, cardF.Width - 6 * s, 12 * s);
                DrawText(g, SchoolName, schoolFont, textBrush, schoolRect, StringAlignment.Center);
                DrawText(g, "THẺ SINH VIÊN", titleFont, textBrush, titleRect, StringAlignment.Center);
            }
        }

        // ----- Ảnh sinh viên (bên trái) -----
        private static void DrawPhoto(Graphics g, RectangleF cardF, Image photo, float s)
        {
            // Khung ảnh dọc tỉ lệ 3:4 (40 x 54 theo hệ số s)
            RectangleF frame = new RectangleF(cardF.X + 8 * s, cardF.Y + 30 * s, 40 * s, 54 * s);

            using (SolidBrush frameBrush = new SolidBrush(Color.White))
            {
                g.FillRectangle(frameBrush, frame);
            }

            if (photo != null)
            {
                RectangleF inner = RectangleF.Inflate(frame, -1 * s, -1 * s);
                RectangleF target = FitImage(photo.Size, inner); // giữ đúng tỉ lệ, không méo
                g.DrawImage(photo, target);
            }
            else
            {
                using (Font font = new Font("Segoe UI", 6 * s, FontStyle.Italic, GraphicsUnit.Pixel))
                using (SolidBrush grayBrush = new SolidBrush(Color.Gray))
                {
                    DrawText(g, "Chưa có ảnh", font, grayBrush, frame, StringAlignment.Center);
                }
            }

            using (Pen framePen = new Pen(Color.Gray, 0.6f * s))
            {
                g.DrawRectangle(framePen, frame.X, frame.Y, frame.Width, frame.Height);
            }
        }

        // ----- Thông tin sinh viên (bên phải) -----
        private static void DrawStudentInfo(Graphics g, RectangleF cardF, StudentInfo info, Color themeColor, float s)
        {
            float left = cardF.X + 54 * s;
            float right = cardF.Right - 7 * s;
            float labelWidth = 33 * s;

            Color nameColor = Blend(themeColor, Color.Black, 0.35f);

            using (SolidBrush darkBrush = new SolidBrush(Color.FromArgb(30, 30, 30)))
            using (SolidBrush grayBrush = new SolidBrush(Color.Gray))
            using (SolidBrush nameBrush = new SolidBrush(nameColor))
            using (Font labelFont = new Font("Segoe UI", 5.8f * s, FontStyle.Bold, GraphicsUnit.Pixel))
            using (Font valueFont = new Font("Segoe UI", 5.8f * s, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                // --- Họ tên: viết hoa, to nhất; tự thu nhỏ nếu quá dài ---
                string name = (info.HoTen ?? string.Empty).Trim().ToUpper(CultureInfo.CurrentCulture);
                bool nameEmpty = name.Length == 0;
                if (nameEmpty)
                {
                    name = "HỌ VÀ TÊN";
                }

                RectangleF nameRect = new RectangleF(left, cardF.Y + 29 * s, right - left, 11 * s);
                using (Font nameFont = CreateFittingFont(g, name, nameRect.Width, 8f * s, 4.6f * s, FontStyle.Bold))
                {
                    DrawText(g, name, nameFont, nameEmpty ? grayBrush : nameBrush, nameRect, StringAlignment.Near);
                }

                // --- Các dòng thông tin: nhãn (đậm) + giá trị ---
                string[] labels = { "MSSV:", "Ngày sinh:", "Giới tính:", "Lớp:", "Khoa:", "Khóa học:" };
                string[] values =
                {
                    info.MaSV,
                    info.NgaySinh.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    info.GioiTinh,
                    info.Lop,
                    info.Khoa,
                    info.KhoaHoc
                };

                float rowTop = cardF.Y + 42 * s;
                float rowHeight = 8.4f * s;

                for (int i = 0; i < labels.Length; i++)
                {
                    float y = rowTop + i * rowHeight;
                    RectangleF labelRect = new RectangleF(left, y, labelWidth, rowHeight);
                    RectangleF valueRect = new RectangleF(left + labelWidth, y, right - left - labelWidth, rowHeight);

                    bool empty = string.IsNullOrWhiteSpace(values[i]);
                    string text = empty ? "..." : values[i].Trim();

                    DrawText(g, labels[i], labelFont, darkBrush, labelRect, StringAlignment.Near);
                    DrawText(g, text, valueFont, empty ? grayBrush : darkBrush, valueRect, StringAlignment.Near);
                }
            }
        }

        // ============================================================
        // CÁC HÀM HỖ TRỢ
        // ============================================================

        // Vẽ 1 dòng chữ trong 1 hình chữ nhật: không xuống dòng, quá dài thì cắt và thêm "..."
        private static void DrawText(Graphics g, string text, Font font, Brush brush, RectangleF rect, StringAlignment alignment)
        {
            using (StringFormat format = new StringFormat())
            {
                format.Alignment = alignment;
                format.LineAlignment = StringAlignment.Center;
                format.Trimming = StringTrimming.EllipsisCharacter;
                format.FormatFlags = StringFormatFlags.NoWrap;
                g.DrawString(text, font, brush, rect, format);
            }
        }

        // Tạo Font có cỡ chữ giảm dần cho tới khi chữ vừa chiều rộng cho phép.
        // Người gọi chịu trách nhiệm Dispose Font trả về.
        private static Font CreateFittingFont(Graphics g, string text, float maxWidth, float startSize, float minSize, FontStyle style)
        {
            float size = startSize;
            Font font = new Font("Segoe UI", size, style, GraphicsUnit.Pixel);

            while (size > minSize && g.MeasureString(text, font).Width > maxWidth)
            {
                font.Dispose();
                size -= startSize * 0.05f;
                font = new Font("Segoe UI", size, style, GraphicsUnit.Pixel);
            }
            return font;
        }

        // Hình chữ nhật bo tròn 4 góc (dùng AddArc cho từng góc)
        private static GraphicsPath CreateRoundedRectangle(RectangleF rect, float radius)
        {
            float d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // Trộn 2 màu: ratio = 0 -> giữ màu gốc, ratio = 1 -> thành màu "other"
        private static Color Blend(Color color, Color other, float ratio)
        {
            int r = (int)(color.R * (1 - ratio) + other.R * ratio);
            int gr = (int)(color.G * (1 - ratio) + other.G * ratio);
            int b = (int)(color.B * (1 - ratio) + other.B * ratio);
            return Color.FromArgb(r, gr, b);
        }

        // Chọn màu chữ (trắng/đen) dễ đọc trên nền màu đã cho, dựa vào độ sáng
        private static Color GetContrastColor(Color background)
        {
            double brightness = 0.299 * background.R + 0.587 * background.G + 0.114 * background.B;
            return brightness > 160 ? Color.FromArgb(30, 30, 30) : Color.White;
        }
    }
}
