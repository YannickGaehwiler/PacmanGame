using System.Drawing;

namespace Pacman.Panels
{
    public sealed class GhostPanel : BasePanel
    {
        public GhostPanel()
        {
            BackColor = Color.Red;
        }

        public override BasePanel Clone()
        {
            return new GhostPanel();
        }

        public void MoveTo(int row, int column)
        {
            Draw(column, row, false);
        }
    }
}