using System;
using System.Collections.Generic;
using Pacman.Maze;
using Pacman.Pacman;

namespace Pacman.GameController
{
    public class GameController : IGameController
    {
        private readonly ILogicalMaze _logicalMaze;
        private readonly LogicalPacman _pacman;

        public int Score { get; private set; }

        public GameController(ILogicalMaze logicalMaze)
        {
            this._logicalMaze = logicalMaze;
            this._pacman = new LogicalPacman(1, 1);
        }

        private readonly Dictionary<MazeTile, int> _scoreDelta = new Dictionary<MazeTile, int>
        {
            {MazeTile.Coin, 1},
            {MazeTile.Empty, 0},
            {MazeTile.Superpill, 0}
        };

        private IUpdateScore _scoreUpdateHandler;
        private IUpdatePacman _pacmanUpdateHandler;

        private void UpdateScore()
        {
            if (this._logicalMaze.Field[this._pacman.Row, this._pacman.Column] != MazeTile.Coin)
            {
                return;
            }

            this.Score += this._scoreDelta[this._logicalMaze.Field[this._pacman.Row, this._pacman.Column]];
            this._logicalMaze.Field[this._pacman.Row, this._pacman.Column] = MazeTile.Empty;
        }

        public void MovePacmanUp()
        {
            if (this._logicalMaze.Field[this._pacman.Row - 1, this._pacman.Column] == MazeTile.Wall)
            {
                return;
            }

            this._pacman.Row--;
            this.UpdateScore();
            this._pacmanUpdateHandler?.MovePacman(this._pacman.Row, this._pacman.Column);
            this._scoreUpdateHandler?.ShowScore(Score);
        }

        public void MovePacmanDown()
        {
            if (this._logicalMaze.Field[this._pacman.Row + 1, this._pacman.Column] == MazeTile.Wall)
            {
                return;
            }

            this._pacman.Row++;
            this.UpdateScore();
            this._pacmanUpdateHandler?.MovePacman(this._pacman.Row, this._pacman.Column);
            this._scoreUpdateHandler?.ShowScore(Score);
        }

        public void MovePacmanRight()
        {
            if (this._logicalMaze.Field[this._pacman.Row, this._pacman.Column + 1] == MazeTile.Wall)
            {
                return;
            }

            this._pacman.Column++;
            this.UpdateScore();
            this._pacmanUpdateHandler?.MovePacman(this._pacman.Row, this._pacman.Column);
            this._scoreUpdateHandler?.ShowScore(Score);
        }

        public void MovePacmanLeft()
        {
            if (this._logicalMaze.Field[this._pacman.Row, this._pacman.Column - 1] == MazeTile.Wall)
            {
                return;
            }

            this._pacman.Column--;
            this.UpdateScore();
            this._pacmanUpdateHandler?.MovePacman(this._pacman.Row, this._pacman.Column);
            this._scoreUpdateHandler?.ShowScore(Score);
        }

        public void RegisterScoreUpdater(IUpdateScore scoreUpdateHandler)
        {
            this._scoreUpdateHandler = scoreUpdateHandler;
        }

        public void RegisterPacmanLocationChange(IUpdatePacman pacmanUpdateHandler)
        {
            this._pacmanUpdateHandler = pacmanUpdateHandler;
        }

        public ILogicalMaze LogicalMaze => this._logicalMaze;
    }
}