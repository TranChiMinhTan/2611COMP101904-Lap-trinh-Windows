using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace COMP1019_Lab08_SimplePaint
{
    // Form Paint đơn giản. Nguyên tắc cốt lõi của bài lab:
    //   1. Chuột chỉ CẬP NHẬT DỮ LIỆU (danh sách drawItems / currentItem).
    //   2. Mọi thao tác VẼ thật sự chỉ diễn ra trong sự kiện canvas_Paint.
    //   3. Mỗi khi dữ liệu đổi -> gọi canvas.Invalidate() để yêu cầu vẽ lại.
    public partial class FrmPaint : Form
    {
        // Danh sách các nét đã vẽ xong (dữ liệu gốc dùng để vẽ lại)
        private readonly List<DrawItem> drawItems = new List<DrawItem>();

        // Nét đang được vẽ dở (đang giữ chuột). null nếu không có thao tác vẽ nào.
        private DrawItem currentItem;

        // Màu vẽ hiện tại (đổi bằng btnColor)
        private Color currentColor = Color.Black;

        // Ảnh nền (null nếu chưa mở ảnh). Là đối tượng GDI+ nên phải Dispose.
        private Image backgroundImage;

        public FrmPaint()
        {
            InitializeComponent();
        }

        private void FrmPaint_Load(object sender, EventArgs e)
        {
            // Nạp danh sách chế độ vẽ từ enum PaintMode vào ComboBox
            cboMode.DataSource = Enum.GetValues(typeof(PaintMode));
            cboMode.SelectedIndex = 0;

            pnlCurrentColor.BackColor = currentColor;
            UpdateButtons();
        }

        // ================= HÀM TIỆN ÍCH =================

        private PaintMode GetSelectedMode()
        {
            if (cboMode.SelectedItem is PaintMode)
            {
                return (PaintMode)cboMode.SelectedItem;
            }
            return PaintMode.Pen;
        }

        // Undo/Clear chỉ bật khi có nét vẽ để xóa
        private void UpdateButtons()
        {
            bool coNetVe = drawItems.Count > 0;
            btnUndo.Enabled = coNetVe;
            btnClear.Enabled = coNetVe;
        }

        // Vẽ toàn bộ nội dung: ảnh nền -> các nét đã lưu -> nét đang vẽ dở.
        // Dùng chung cho sự kiện Paint (vẽ lên màn hình) và cho chức năng
        // Lưu PNG (vẽ lên Bitmap) nên hình lưu ra giống hệt hình đang thấy.
        private void DrawAll(Graphics g, Rectangle area)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (backgroundImage != null)
            {
                g.DrawImage(backgroundImage, area);
            }

            foreach (DrawItem item in drawItems)
            {
                item.Draw(g);
            }

            if (currentItem != null)
            {
                currentItem.Draw(g);
            }
        }

        // Undo: bỏ nét vẽ cuối cùng khỏi danh sách (yêu cầu 8)
        private void Undo()
        {
            if (drawItems.Count == 0)
            {
                return;
            }

            drawItems.RemoveAt(drawItems.Count - 1);
            UpdateButtons();
            canvas.Invalidate();
        }

        // ================= SỰ KIỆN VẼ (PAINT) =================

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            DrawAll(e.Graphics, canvas.ClientRectangle);
        }

        // ================= SỰ KIỆN CHUỘT =================

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return; // chỉ vẽ bằng chuột trái
            }

            // chkFill chỉ có hiệu lực với Rectangle / Ellipse (đã bị khóa ở các chế độ khác)
            bool isFilled = chkFill.Enabled && chkFill.Checked;

            currentItem = new DrawItem(GetSelectedMode(), currentColor, (int)nudWidth.Value, isFilled, e.Location);
            canvas.Invalidate();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Hiển thị tọa độ chuột (yêu cầu 9)
            lblStatus.Text = $"Tọa độ: X = {e.X}, Y = {e.Y}";

            if (currentItem == null)
            {
                return; // không đang kéo chuột để vẽ
            }

            if (currentItem.Mode == PaintMode.Pen)
            {
                currentItem.AddPoint(e.Location);
            }
            else
            {
                currentItem.End = e.Location;
            }

            // Chỉ cập nhật dữ liệu rồi yêu cầu vẽ lại - KHÔNG vẽ trực tiếp ở đây
            canvas.Invalidate();
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentItem == null || e.Button != MouseButtons.Left)
            {
                return;
            }

            if (currentItem.Mode != PaintMode.Pen)
            {
                currentItem.End = e.Location;
            }

            // Chỉ click mà không kéo (hình rỗng) thì bỏ, không lưu
            if (!currentItem.IsEmptyShape())
            {
                drawItems.Add(currentItem);
            }

            currentItem = null;
            UpdateButtons();
            canvas.Invalidate();
        }

        private void canvas_MouseLeave(object sender, EventArgs e)
        {
            lblStatus.Text = "Tọa độ: -";
        }

        // ================= CÁC CONTROL ĐIỀU KHIỂN =================

        // Tô màu chỉ áp dụng cho hình khép kín: Rectangle và Ellipse
        private void cboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaintMode mode = GetSelectedMode();
            chkFill.Enabled = (mode == PaintMode.Rectangle || mode == PaintMode.Ellipse);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.Color = currentColor;
                dlg.FullOpen = true;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    currentColor = dlg.Color;
                    pnlCurrentColor.BackColor = currentColor;
                }
            }
        }

        // Nâng cao: đổi màu nền canvas
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.Color = canvas.BackColor;
                dlg.FullOpen = true;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    canvas.BackColor = dlg.Color;
                    canvas.Invalidate();
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (drawItems.Count == 0)
            {
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa toàn bộ nét vẽ?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            drawItems.Clear();
            currentItem = null;
            UpdateButtons();
            canvas.Invalidate();
        }

        // Nâng cao: phím tắt Ctrl+Z (Form có KeyPreview = true nên nhận phím
        // trước cả khi control con như NumericUpDown xử lý)
        private void FrmPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // ================= NÂNG CAO: ẢNH NỀN & LƯU PNG =================

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Chọn ảnh nền";
                dlg.Filter = "Tệp hình ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (dlg.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    // Đọc file rồi COPY sang một Bitmap độc lập: vừa không khóa
                    // file gốc, vừa không phụ thuộc vào luồng đọc file đã đóng.
                    Image anhMoi;
                    using (FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
                    using (Image anhTam = Image.FromStream(fs))
                    {
                        anhMoi = new Bitmap(anhTam);
                    }

                    if (backgroundImage != null)
                    {
                        backgroundImage.Dispose();
                    }
                    backgroundImage = anhMoi;
                    canvas.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không mở được ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int width = canvas.ClientSize.Width;
            int height = canvas.ClientSize.Height;

            if (width <= 0 || height <= 0)
            {
                MessageBox.Show("Vùng vẽ có kích thước 0, không thể lưu.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Lưu hình vẽ";
                dlg.Filter = "Ảnh PNG (*.png)|*.png";
                dlg.FileName = "painting.png";

                if (dlg.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (Bitmap bmp = new Bitmap(width, height))
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(canvas.BackColor);
                        DrawAll(g, new Rectangle(0, 0, width, height));
                        bmp.Save(dlg.FileName, ImageFormat.Png);
                    }

                    MessageBox.Show("Đã lưu ảnh thành công.", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không lưu được ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Giải phóng ảnh nền khi đóng Form
        private void FrmPaint_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (backgroundImage != null)
            {
                backgroundImage.Dispose();
                backgroundImage = null;
            }
        }
    }
}
