using System;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman.GameController
{
    public interface IGameController
    {
        void MovePacmanUp(Action<int, int, MazeTile> callbackFunc);
        void MovePacmanDown(Action<int, int, MazeTile> callbackFunc);
        void MovePacmanRight(Action<int, int, MazeTile> callbackFunc);
        void MovePacmanLeft(Action<int, int, MazeTile> callbackFunc);
        ILogicalMaze LogicalMaze { get; }
    }
}