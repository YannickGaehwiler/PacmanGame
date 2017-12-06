using System.Drawing;
using System.Windows.Forms;

namespace Pacman.Panels
{
    public sealed class EmptyPanel : BasePanel
    {
        public EmptyPanel()
        {
            BackColor = Color.LightBlue;
            BorderStyle = BorderStyle.None;
        }

        public override BasePanel Clone()
        {
            return new EmptyPanel();
        }
    }
}