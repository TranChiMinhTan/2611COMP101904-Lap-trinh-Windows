using System.Windows.Forms;

namespace COMP1019_Lab08_SimplePaint
{
    // Panel thường hay bị nhấp nháy (flicker) khi vẽ lại liên tục lúc kéo
    // chuột. Lớp này kế thừa Panel và bật DoubleBuffered để vẽ ra bộ nhớ đệm
    // trước rồi mới đưa lên màn hình một lần => hình mượt, không nháy.
    // ResizeRedraw = true: tự vẽ lại toàn bộ khi canvas bị thay đổi kích thước.
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
}
