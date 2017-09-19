using System.Drawing;

namespace Pacman.Panels
{
    public sealed class SuperPillPanel : BasePanel
    {
        public SuperPillPanel()
        {
            BackColor = Color.Red;
        }

        public override BasePanel Clone()
        {
            return new SuperPillPanel();
        }
    }
}