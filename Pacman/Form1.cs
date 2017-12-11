using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Pacman.GameController;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman
{

    public partial class Form1 : Form
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
                    _gameController.MovePacmanUp(MovePacman, ShowScore);
                    break;
                case Keys.D:
                    _gameController.MovePacmanRight(MovePacman, ShowScore);
                    break;
                case Keys.A:
                    _gameController.MovePacmanLeft(MovePacman, ShowScore);
                    break;
                case Keys.S:
                    _gameController.MovePacmanDown(MovePacman, ShowScore);
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
            }
        }
        
        private void MovePacman(int row, int column)
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

        private void ShowScore(int score)
        {
            this.Text = $"PACMAN - SCORE: {score}";
        }
    }
}