using System.Drawing;
using System.Windows.Forms;

namespace Pacman.Panels
{
    public abstract class BasePanel : Panel
    {
        private const int PanelWidth = 30;
        private const int PanelHeigth = 30;

        protected BasePanel()
        {
            Size = new Size(PanelWidth, PanelHeigth);
            BorderStyle = BorderStyle.FixedSingle;
        }

        public void Draw(Point location)
        {
            Location = location;
            if (Form.ActiveForm != null)
            {
                Form.ActiveForm.Controls.Add(this);
            }
        }

        public abstract BasePanel Clone();
    }
}