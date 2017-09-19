using System.Drawing;

namespace Pacman.Panels
{
    public sealed class CoinPanel : BasePanel
    {
        public CoinPanel()
        {
            BackColor = Color.Yellow;
        }

        public override BasePanel Clone()
        {
            return new CoinPanel();
        }
    }
}