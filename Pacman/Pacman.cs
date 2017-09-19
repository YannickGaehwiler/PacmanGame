using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman
{
    public sealed class Pacman : IPacman
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public void SetLocation(int column, int row)
        {
            this.Column = column;
            this.Row = row;
        }
    }
}