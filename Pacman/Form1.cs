using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                _pacmanFigure.Up(this);

            }
            else if (e.KeyCode == Keys.S)
            {
                _pacmanFigure.Down(this);

            }
            else if(e.KeyCode == Keys.A)
            {
                _pacmanFigure.Left(this);

            }
            else if(e.KeyCode == Keys.D)
            {
                _pacmanFigure.Right(this);
            }
        }
    }
}
