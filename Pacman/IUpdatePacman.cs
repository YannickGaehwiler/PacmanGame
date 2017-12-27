using System;
using Pacman.Pacman;

namespace Pacman
{
    public interface IUpdatePacman
    {
        void MovePacmanPanel(int row, int column);
        void MovePacman(Direction direction);
    }
}