using System;
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

        public void MoveTo(int row, int column)
        {
            Draw(row, column, false);
        }
    }
}