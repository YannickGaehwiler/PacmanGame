using System;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman.GameController
{
    public interface IGameController
    {
        void MovePacmanUp();
        void MovePacmanDown();
        void MovePacmanRight();
        void MovePacmanLeft();

        void RegisterScoreUpdater(IUpdateScore scoreUpdateHandler);
        void RegisterPacmanLocationChange(IUpdatePacman pacmanUpdateHandler);
        ILogicalMaze LogicalMaze { get; }
    }
}