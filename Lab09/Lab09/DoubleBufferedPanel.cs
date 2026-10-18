using System.Windows.Forms;

namespace COMP1019_Lab09_StudentCard
{
    // Panel thường hay bị nhấp nháy khi vẽ lại. Lớp này bật DoubleBuffered
    // (vẽ ra bộ nhớ đệm rồi đưa lên màn hình một lần) và ResizeRedraw
    // (tự vẽ lại khi Panel đổi kích thước, để thẻ luôn nằm giữa Panel).
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
}
