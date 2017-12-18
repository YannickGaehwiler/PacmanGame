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

            _pacmanMovement = new Dictionary<PacmanDirection, Action>
            {
                {PacmanDirection.Up, () => { MovePacman(-1, 0); }},
                {PacmanDirection.Right, () => { MovePacman(0, 1); }},
                {PacmanDirection.Left, () => { MovePacman(0, -1); }},
                {PacmanDirection.Down, () => { MovePacman(1, 0); }}
            };
        }

        private readonly Dictionary<MazeTile, int> _scoreDelta = new Dictionary<MazeTile, int>
        {
            {MazeTile.Coin, 1},
            {MazeTile.Empty, 0},
            {MazeTile.Superpill, 0}
        };

        private readonly Dictionary<PacmanDirection, Action> _pacmanMovement;

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

        private void MovePacman(int rowDelta, int columnDelta)
        {
            if (this._logicalMaze.Field[this._pacman.Row + rowDelta, this._pacman.Column + columnDelta] == MazeTile.Wall)
            {
                return;
            }

            this._pacman.Row += rowDelta;
            this._pacman.Column += columnDelta;

            UpdateAndMove();
        }

        private void UpdateAndMove()
        {
            this.UpdateScore();
            this._pacmanUpdateHandler?.MovePacmanPanel(this._pacman.Row, this._pacman.Column);
            this._scoreUpdateHandler?.ShowScore(Score);
        }

        public void MovePacman(PacmanDirection pacmanDirection)
        {
            this._pacmanMovement[pacmanDirection].Invoke();
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