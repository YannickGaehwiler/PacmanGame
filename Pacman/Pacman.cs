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
        private bool _goUp;
        private bool _goDown;
        private bool _goLeft;
        private bool _goRight;

        private int _speed = 5;

        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _goUp = true;
                    break;
                case Keys.D:
                    _goRight = true;
                    break;
                case Keys.S:
                    _goDown = true;
                    break;
                case Keys.A:
                    _goLeft = true;
                    break;
            }
        }

        public void KeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _goUp = false;
                    break;
                case Keys.D:
                    _goRight = false;
                    break;
                case Keys.S:
                    _goDown = false;
                    break;
                case Keys.A:
                    _goLeft = false;
                    break;
            }
        }

        public void Movement(Form1 form)
        {
            if (_goUp)
            {
                form.pacman.Top -= _speed;
            }
            else if (_goRight)
            {
                form.pacman.Left += _speed;
            }
            else if (_goDown)
            {
                form.pacman.Top += _speed;
            }
            else if (_goLeft)
            {
                form.pacman.Left -= _speed;
            }
        }
    }
}
