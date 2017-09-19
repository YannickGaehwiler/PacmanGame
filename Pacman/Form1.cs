using System;
using System.Windows.Forms;
using Pacman.Maze;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private readonly Pacman _pacmanFigure = new Pacman();

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
        }
    }
}