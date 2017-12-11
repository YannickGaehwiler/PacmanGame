using System;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman.GameController
{
    public interface IGameController
    {
        void MovePacmanUp(Action<int, int> callbackFunc, Action<int> updateScoreFunc);
        void MovePacmanDown(Action<int, int> callbackFunc, Action<int> updateScoreFunc);
        void MovePacmanRight(Action<int, int> callbackFunc, Action<int> updateScoreFunc);
        void MovePacmanLeft(Action<int, int> callbackFunc, Action<int> updateScoreFunc);
        ILogicalMaze LogicalMaze { get; }
    }
}