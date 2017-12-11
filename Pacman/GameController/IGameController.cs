using System;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman.GameController
{
    public interface IGameController
    {
        void MovePacmanUp(Action<int, int> callbackFunc);
        void MovePacmanDown(Action<int, int> callbackFunc);
        void MovePacmanRight(Action<int, int> callbackFunc);
        void MovePacmanLeft(Action<int, int> callbackFunc);
        ILogicalMaze LogicalMaze { get; }
    }
}