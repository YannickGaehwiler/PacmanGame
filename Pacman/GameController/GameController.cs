using System;
using System.Collections.Generic;
using System.Timers;
using Pacman.Maze;
using Pacman.Pacman;

namespace Pacman.GameController
{
    public class GameController : IGameController
    {
        private readonly ILogicalMaze _logicalMaze;
        private readonly LogicalPacman _pacman;
        private readonly LogicalGhost _ghost;

        public int Score { get; private set; }

        private IUpdateScore _scoreUpdateHandler;
        private IUpdatePacman _pacmanUpdateHandler;
        private IUpdateGhost _ghostUpdateHandler;

        public ILogicalMaze LogicalMaze => this._logicalMaze;

        public GameController(ILogicalMaze logicalMaze)
        {
            this._logicalMaze = logicalMaze;
            this._pacman = new LogicalPacman(1, 1, logicalMaze);
            this._ghost = new LogicalGhost(4, 4, logicalMaze);

            var paceMaker = new Timer
            {
                Interval = 350,
                Enabled = true
            };
            
            paceMaker.Elapsed += NextStep;
        }

        private readonly Dictionary<MazeTile, int> _scoreDelta = new Dictionary<MazeTile, int>
        {
            {MazeTile.Coin, 1},
            {MazeTile.Empty, 0},
            {MazeTile.Superpill, 0}
        };
        
        private void UpdateScore()
        {
            if (this._logicalMaze.Field[this._pacman.Row, this._pacman.Column] != MazeTile.Coin)
            {
                return;
            }

            this.Score += this._scoreDelta[this._logicalMaze.Field[this._pacman.Row, this._pacman.Column]];
            this._logicalMaze.Field[this._pacman.Row, this._pacman.Column] = MazeTile.Empty;
        }

        private void UpdateAndMove()
        {
            this.UpdateScore();
            this._pacmanUpdateHandler?.MovePacmanPanel(this._pacman.Row, this._pacman.Column);
            this._ghostUpdateHandler?.MoveGhostPanel(this._ghost.Row, this._ghost.Column);
            this._scoreUpdateHandler?.ShowScore(Score);
        }

        public void ChangeDirection(Direction direction)
        {
            this._pacman.ChangeDirection(direction);
        }

        public void NextStep(object source, ElapsedEventArgs e)
        {
            this._pacman.NextStep();
            this._ghost.NextStep();
            this.UpdateAndMove();
        }

        public void RegisterScoreUpdater(IUpdateScore scoreUpdateHandler)
        {
            this._scoreUpdateHandler = scoreUpdateHandler;
        }

        public void RegisterPacmanLocationChange(IUpdatePacman pacmanUpdateHandler)
        {
            this._pacmanUpdateHandler = pacmanUpdateHandler;
        }

        public void RegisterGhostLocationChange(IUpdateGhost ghostUpdateHandler)
        {
            this._ghostUpdateHandler = ghostUpdateHandler;
        }
    }
}