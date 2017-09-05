using System;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private readonly Pacman _pacmanFigure = new Pacman();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _pacmanFigure.Movement(this);
            _pacmanFigure.Detection(this);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            _pacmanFigure.KeyDown(e);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            _pacmanFigure.KeyUp(e);
        }
    }
}
