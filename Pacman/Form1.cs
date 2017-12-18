using System;
using System.Drawing;
using System.Windows.Forms;
using Pacman.GameController;
using Pacman.Maze;
using Pacman.Pacman;
using Pacman.Panels;

namespace Pacman
{
    public partial class Form1 : Form, IUpdateScore, IUpdatePacman
    {
        private IGameController _gameController;
        private readonly Func<IGameController> _gameControllerFactory;

        private PacmanPanel _pacman;
        private readonly Func<PacmanPanel> _pacmanFactory;

        private IVisualMaze _visualMaze;

        public Form1(Func<IGameController> gameControllerFactory, Func<PacmanPanel> pacmanFactory)
        {
            InitializeComponent();
            KeyPreview = true;
            this._gameControllerFactory = gameControllerFactory;
            this._pacmanFactory = pacmanFactory;
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    MovePacman(PacmanDirection.Up);
                    break;
                case Keys.D:
                    MovePacman(PacmanDirection.Right);
                    break;
                case Keys.A:
                    MovePacman(PacmanDirection.Left);
                    break;
                case Keys.S:
                    MovePacman(PacmanDirection.Down);
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (this._gameController == null)
            {
                this._pacman = this._pacmanFactory();
                this._gameController = this._gameControllerFactory();
                this._visualMaze = new VisualMaze(_gameController.LogicalMaze);
                this.ClientSize = new Size(_gameController.LogicalMaze.Field.Length / _gameController.LogicalMaze.Field.GetLength(0) * 50, _gameController.LogicalMaze.Field.GetLength(0) * 50);
                this._gameController.RegisterScoreUpdater(this);
                this._gameController.RegisterPacmanLocationChange(this);
            }
        }

        public void MovePacman(PacmanDirection pacmanDirection)
        {
            _gameController.MovePacman(pacmanDirection);
        }
        
        public void MovePacmanPanel(int row, int column)
        {
            _pacman.MoveTo(row, column);
            UpdateMaze(row, column);
        }

        private void UpdateMaze(int row, int column)
        {
            var currentPanel = _visualMaze.GetPanel(row, column);

            if (currentPanel is CoinPanel)
            {
                this.Controls.Remove(currentPanel);
                _visualMaze.SetPanel(MazeTile.Empty, row, column);
            }
        }

        public void ShowScore(int score)
        {
            this.Text = $"PACMAN - SCORE: {score}";
        }
    }
}