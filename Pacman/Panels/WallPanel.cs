using System.Drawing;

namespace Pacman.Panels
{
    public sealed class WallPanel : BasePanel
    {
        public WallPanel()
        {
            BackColor = Color.Gray;
        }

        public override BasePanel Clone()
        {
            return new WallPanel();
        }
    }
}