using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman.GameController
{
    public class GameController : IGameController
    {
        private readonly ILogicalMaze _logicalMaze;
        private readonly PacmanPanel _pacman;
        private readonly IVisualMaze _visualMaze;

        private const int Step = 30;

        public int Score { get; private set; }

        public GameController(ILogicalMaze logicalMaze, PacmanPanel pacman)
        {
            this._logicalMaze = logicalMaze;
            this._visualMaze = new VisualMaze(logicalMaze);
            _pacman = pacman;
            _pacman.SetLogicalLocation(1, 1);
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
            Console.WriteLine("Score: " + Score);

            this._logicalMaze.Field[this._pacman.Row, this._pacman.Column] = MazeTile.Empty;

            var coinpanel = _visualMaze.GetPanel(this._pacman.Row, this._pacman.Column);

            Form.ActiveForm.Controls.Remove(coinpanel);

            _visualMaze.SetPanel(MazeTile.Empty, this._pacman.Row, this._pacman.Column);

            var newPanel = _visualMaze.GetPanel(this._pacman.Row, this._pacman.Column);

            newPanel.Location = new Point(this._pacman.Column * Step, this._pacman.Row * Step);

            Form.ActiveForm.Controls.Add(newPanel);
        }

        private void UpdatePacmanPanelLocation()
        {
            this._pacman.Location = new Point(this._pacman.Column * Step, this._pacman.Row * Step);
        }

        public void MovePacmanUp()
        {
            if (this._logicalMaze.Field[this._pacman.Row - 1, this._pacman.Column] == MazeTile.Wall)
            {
                return;
            }

            this._pacman.Row--;
            this.UpdatePacmanPanelLocation();
            this.UpdateScore();
        }

        public void MovePacmanDown()
        {
            if (this._logicalMaze.Field[this._pacman.Row + 1, this._pacman.Column] == MazeTile.Wall)
            {
                return;
            }

            this._pacman.Row++;
            this.UpdatePacmanPanelLocation();
            this.UpdateScore();
        }

        public void MovePacmanRight()
        {
            if (this._logicalMaze.Field[this._pacman.Row, this._pacman.Column + 1] == MazeTile.Wall)
            {
                return;
            }

            this._pacman.Column++;
            this.UpdatePacmanPanelLocation();
            this.UpdateScore();
        }

        public void MovePacmanLeft()
        {
            if (this._logicalMaze.Field[this._pacman.Row, this._pacman.Column - 1] == MazeTile.Wall)
            {
                return;
            }

            this._pacman.Column--;
            this.UpdatePacmanPanelLocation();
            this.UpdateScore();
        }
    }
}