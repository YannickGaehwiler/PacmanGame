using System.Drawing;

namespace Pacman.Panels
{
    public sealed class WallPanel : BasePanel
    {
        public WallPanel()
        {
            BackColor = Color.Black;
        }

        public override BasePanel Clone()
        {
            return new WallPanel();
        }
    }
}