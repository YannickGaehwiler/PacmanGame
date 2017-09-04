using Pacman;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    class Pacman
    {
        public void Up(Form1 form)
        {
            form.pacman.Location = new Point(form.pacman.Location.X, form.pacman.Location.Y - 5);
            System.Threading.Thread.Sleep(100);
        }

        public void Down(Form1 form)
        {
            form.pacman.Location = new Point(form.pacman.Location.X, form.pacman.Location.Y + 5);
            System.Threading.Thread.Sleep(100);
        }

        public void Left(Form1 form)
        {
            form.pacman.Location = new Point(form.pacman.Location.X - 5, form.pacman.Location.Y);
            System.Threading.Thread.Sleep(100);
        }

        public void Right(Form1 form)
        {
            form.pacman.Location = new Point(form.pacman.Location.X + 5, form.pacman.Location.Y);
            System.Threading.Thread.Sleep(100);
        }

    }
}
