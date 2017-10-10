using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Pacman.Maze;

namespace Pacman.GameController
{
    public class GameController : IGameController
    {
        private readonly ILogicalMaze _logicalMaze;
        private readonly Pacman _logicalPacman;
        private readonly Panel _pacmanPanel;

        private const int Step = 30;

        public int Score;

        public GameController(ILogicalMaze logicalMaze, Pacman logicalPacman, Panel pacmanPanel)
        {
            this._logicalMaze = logicalMaze;
            this._logicalPacman = logicalPacman;
            this._pacmanPanel = pacmanPanel;
        }

        private readonly Dictionary<MazeTile, int> _scoreDelta = new Dictionary<MazeTile, int>
        {
            {MazeTile.Coin, 1},
            {MazeTile.Empty, 0},
            {MazeTile.Superpill, 0}
        };

        private void UpdateScore()
        {
            this.Score += this._scoreDelta[_logicalMaze.Field[this._logicalPacman.Row, this._logicalPacman.Column]];
        }

        private void UpdatePacmanPanelLocation()
        {
            _pacmanPanel.Location = new Point(_logicalPacman.Column * Step, _logicalPacman.Row * 30);
        }

        public void MovePacmanUp()
        {
            if (_logicalMaze.Field[_logicalPacman.Row - 1, _logicalPacman.Column] == MazeTile.Wall)
            {
                return;
            }

            this._logicalPacman.Row--;
            this.UpdatePacmanPanelLocation();
            this.UpdateScore();
        }

        public void MovePacmanDown()
        {
            if (_logicalMaze.Field[_logicalPacman.Row + 1, _logicalPacman.Column] == MazeTile.Wall)
            {
                return;
            }

            this._logicalPacman.Row++;
            this.UpdatePacmanPanelLocation();
            this.UpdateScore();
        }

        public void MovePacmanRight()
        {
            if (_logicalMaze.Field[_logicalPacman.Row, _logicalPacman.Column + 1] == MazeTile.Wall)
            {
                return;
            }

            this._logicalPacman.Column++;
            this.UpdatePacmanPanelLocation();
            this.UpdateScore();
        }

        public void MovePacmanLeft()
        {
            if (_logicalMaze.Field[_logicalPacman.Row, _logicalPacman.Column - 1] == MazeTile.Wall)
            {
                return;
            }

            this._logicalPacman.Column--;
            this.UpdatePacmanPanelLocation();
            this.UpdateScore();
        }
    }
}