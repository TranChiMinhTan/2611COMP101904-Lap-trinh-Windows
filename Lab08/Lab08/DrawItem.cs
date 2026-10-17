using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace COMP1019_Lab08_SimplePaint
{
    // ============================================================
    // DrawItem
    // Lưu DỮ LIỆU GỐC của 1 nét vẽ (loại hình, màu, độ dày, tọa độ).
    // Form giữ một List<DrawItem>; mỗi lần canvas cần vẽ lại (Paint),
    // ta duyệt danh sách này và gọi Draw() cho từng phần tử. Nhờ vậy nét
    // vẽ không bao giờ bị mất khi resize / bị che rồi hiện lại.
    // ============================================================
    public class DrawItem
    {
        public PaintMode Mode { get; private set; }
        public Color PenColor { get; private set; }
        public int PenWidth { get; private set; }
        public bool IsFilled { get; private set; }

        // Dùng cho chế độ Pen: toàn bộ các điểm chuột đi qua
        public List<Point> Points { get; private set; }

        // Dùng cho Line / Rectangle / Ellipse: điểm bấm chuột và điểm hiện tại/thả chuột
        public Point Start { get; private set; }
        public Point End { get; set; }

        public DrawItem(PaintMode mode, Color penColor, int penWidth, bool isFilled, Point start)
        {
            Mode = mode;
            PenColor = penColor;
            PenWidth = penWidth;
            IsFilled = isFilled;
            Start = start;
            End = start;
            Points = new List<Point> { start };
        }

        // Thêm 1 điểm mới vào nét vẽ tự do (Pen)
        public void AddPoint(Point point)
        {
            Points.Add(point);
            End = point;
        }

        // Hình (Line/Rectangle/Ellipse) mà điểm đầu trùng điểm cuối là
        // "hình rỗng" (chỉ click chứ không kéo) -> không đáng lưu lại.
        public bool IsEmptyShape()
        {
            return Mode != PaintMode.Pen && Start == End;
        }

        // Tạo hình chữ nhật chuẩn hóa từ Start và End. Dù người dùng kéo
        // chuột theo hướng nào (trái-trên, phải-dưới, ...) thì X, Y luôn là
        // góc TRÁI-TRÊN còn Width, Height luôn DƯƠNG. Đây là yêu cầu kỹ thuật
        // "xử lý kéo chuột theo mọi hướng" của đề bài.
        public Rectangle GetNormalizedRectangle()
        {
            int x = Math.Min(Start.X, End.X);
            int y = Math.Min(Start.Y, End.Y);
            int width = Math.Abs(End.X - Start.X);
            int height = Math.Abs(End.Y - Start.Y);
            return new Rectangle(x, y, width, height);
        }

        // Vẽ nét này lên Graphics được truyền vào (gọi từ sự kiện Paint).
        // Pen/Brush là đối tượng GDI+ nên phải giải phóng bằng using.
        public void Draw(Graphics g)
        {
            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;

                switch (Mode)
                {
                    case PaintMode.Pen:
                        DrawFreehand(g, pen);
                        break;

                    case PaintMode.Line:
                        g.DrawLine(pen, Start, End);
                        break;

                    case PaintMode.Rectangle:
                        Rectangle rect = GetNormalizedRectangle();
                        if (IsFilled)
                        {
                            using (SolidBrush brush = new SolidBrush(PenColor))
                            {
                                g.FillRectangle(brush, rect);
                            }
                        }
                        g.DrawRectangle(pen, rect);
                        break;

                    case PaintMode.Ellipse:
                        Rectangle bounds = GetNormalizedRectangle();
                        if (IsFilled)
                        {
                            using (SolidBrush brush = new SolidBrush(PenColor))
                            {
                                g.FillEllipse(brush, bounds);
                            }
                        }
                        g.DrawEllipse(pen, bounds);
                        break;
                }
            }
        }

        private void DrawFreehand(Graphics g, Pen pen)
        {
            if (Points.Count >= 2)
            {
                g.DrawLines(pen, Points.ToArray());
            }
            else
            {
                // Mới chỉ click 1 điểm (chưa kéo): vẽ 1 chấm tròn đường kính = độ dày nét
                using (SolidBrush brush = new SolidBrush(PenColor))
                {
                    float radius = PenWidth / 2f;
                    g.FillEllipse(brush, Points[0].X - radius, Points[0].Y - radius, PenWidth, PenWidth);
                }
            }
        }
    }
}
