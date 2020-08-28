using System.Windows.Forms;

namespace BallonTipApp
{
    internal class BalloonTip
    {
        public void Show(string title, string text, Control control, ToolTipIcon icon, double timeOut)
        {
            var hint = new ToolTip();
            hint.IsBalloon = true;
            hint.ToolTipTitle = title;
            hint.ToolTipIcon = icon;

            hint.Show(string.Empty, control, 0);
            hint.Show(text, control, (int) timeOut);
        }
    }
}