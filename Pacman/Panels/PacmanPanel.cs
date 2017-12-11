using System.Drawing;

namespace Pacman.Panels
{
    public sealed class PacmanPanel : BasePanel
    {
        public PacmanPanel()
        {
            BackColor = Color.Yellow;
        }

        public override BasePanel Clone()
        {
            return new PacmanPanel();
        }
    }
}