using System.Drawing;
using System.Windows.Forms;

namespace Pacman.Panels
{
    public abstract class BasePanel : Panel
    {
        private const int PanelWidth = 50;
        private const int PanelHeigth = 50;

        protected BasePanel()
        {
            Size = new Size(PanelWidth, PanelHeigth);
            BorderStyle = BorderStyle.FixedSingle;
        }

        public void Draw(Point location, Form activeForm)
        {
            Location = location;
            if (Form.ActiveForm != null) Form.ActiveForm.Controls.Add(this);
        }

        public abstract BasePanel Clone();
    }
}