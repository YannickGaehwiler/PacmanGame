using System;
using Pacman.Maze;
using Pacman.Pacman;
using Pacman.Panels;

namespace Pacman.GameController
{
    public interface IGameController
    {
        void MovePacman(PacmanDirection pacmanDirection);
        void RegisterScoreUpdater(IUpdateScore scoreUpdateHandler);
        void RegisterPacmanLocationChange(IUpdatePacman pacmanUpdateHandler);
        ILogicalMaze LogicalMaze { get; }
    }
}