using Pacman;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    class Pacman
    {
        private bool _up;
        private bool _down;
        private bool _left;
        private bool _right;

        private int _speed = 5;

        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _up = true;
                    break;
                case Keys.D:
                    _right = true;
                    break;
                case Keys.S:
                    _down = true;
                    break;
                case Keys.A:
                    _left = true;
                    break;
            }
        }

        public void KeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _up = false;
                    break;
                case Keys.D:
                    _right = false;
                    break;
                case Keys.S:
                    _down = false;
                    break;
                case Keys.A:
                    _left = false;
                    break;
            }
        }

        public void Movement(Form1 form)
        {
            if (_up)
            {
                form.pacman.Top -= _speed;
            }
            else if (_right)
            {
                form.pacman.Left += _speed;
            }
            else if (_down)
            {
                form.pacman.Top += _speed;
            }
            else if (_left)
            {
                form.pacman.Left -= _speed;
            }
        }

        public void Detection(Form1 form)
        {
            foreach (Control x in form.Controls)
            {
                if (!(x is Panel) || x.Tag != "wall") continue;
                if (!x.Bounds.IntersectsWith(form.pacman.Bounds)) continue;
                form.timer1.Stop();
            }
        }
    }
}
