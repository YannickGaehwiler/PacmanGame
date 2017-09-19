using System.Drawing;

namespace Pacman.Panels
{
    public sealed class CoinPanel : BasePanel
    {
        public CoinPanel()
        {
            BackColor = Color.Orange;
        }

        public override BasePanel Clone()
        {
            return new CoinPanel();
        }
    }
}