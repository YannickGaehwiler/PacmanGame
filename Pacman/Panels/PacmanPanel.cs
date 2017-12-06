using System.Drawing;

namespace Pacman.Panels
{
    public sealed class PacmanPanel : BasePanel, IPacman
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public void SetLogicalLocation(int column, int row)
        {
            this.Column = column;
            this.Row = row;
        }

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