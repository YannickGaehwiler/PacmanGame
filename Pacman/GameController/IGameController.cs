using System;
using Pacman.Maze;
using Pacman.Pacman;
using Pacman.Panels;

namespace Pacman.GameController
{
    public interface IGameController
    {
        void ChangeDirection(Direction direction);
        void RegisterScoreUpdater(IUpdateScore scoreUpdateHandler);
        void RegisterPacmanLocationChange(IUpdatePacman pacmanUpdateHandler);
        void RegisterGhostLocationChange(IUpdateGhost ghostUpdateHandler);
        ILogicalMaze LogicalMaze { get; }
    }
}