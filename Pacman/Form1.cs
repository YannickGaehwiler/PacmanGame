using System;
using System.Drawing;
using System.Windows.Forms;
using Pacman.GameController;
using Pacman.Maze;
using Pacman.Pacman;
using Pacman.Panels;

namespace Pacman
{
    public partial class Form1 : Form, IUpdateScore, IUpdatePacman, IUpdateGhost
    {
        private IGameController _gameController;
        private readonly Func<IGameController> _gameControllerFactory;

        private PacmanPanel _pacman;
        private readonly Func<PacmanPanel> _pacmanFactory;

        private GhostPanel _ghost;
        private readonly Func<GhostPanel> _ghostFactory;

        private IVisualMaze _visualMaze;

        public Form1(Func<IGameController> gameControllerFactory, Func<PacmanPanel> pacmanFactory, Func<GhostPanel> ghostFactory)
        {
            InitializeComponent();
            KeyPreview = true;
            this._gameControllerFactory = gameControllerFactory;
            this._pacmanFactory = pacmanFactory;
            this._ghostFactory = ghostFactory;
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    MovePacman(Direction.Up);
                    break;
                case Keys.D:
                    MovePacman(Direction.Right);
                    break;
                case Keys.A:
                    MovePacman(Direction.Left);
                    break;
                case Keys.S:
                    MovePacman(Direction.Down);
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (this._gameController == null)
            {
                this._pacman = this._pacmanFactory();
                this._ghost = this._ghostFactory();
                this._gameController = this._gameControllerFactory();
                this._visualMaze = new VisualMaze(_gameController.LogicalMaze);
                this.ClientSize = new Size(_gameController.LogicalMaze.Field.Length / _gameController.LogicalMaze.Field.GetLength(0) * 50, _gameController.LogicalMaze.Field.GetLength(0) * 50);
                this._gameController.RegisterScoreUpdater(this);
                this._gameController.RegisterPacmanLocationChange(this);
                this._gameController.RegisterGhostLocationChange(this);
            }
        }

        public void MovePacman(Direction direction)
        {
            _gameController.ChangeDirection(direction);
        }
        

        public void MovePacmanPanel(int row, int column)
        {
            InvokeUi(() =>
            {
                _pacman.MoveTo(row, column);
                UpdateMaze(row, column);
            });
        }

        public void MoveGhostPanel(int row, int column)
        {
            InvokeUi(() =>
            {
                _ghost.MoveTo(row, column);
            });
        }

        private void UpdateMaze(int row, int column)
        {
            InvokeUi(() =>
            {
                var currentPanel = _visualMaze.GetPanel(row, column);

                if (!(currentPanel is CoinPanel))
                {
                    return;
                }
                this.Controls.Remove(currentPanel);
                _visualMaze.SetPanel(MazeTile.Empty, row, column);
            });
        }

        public void ShowScore(int score)
        {
            InvokeUi(() =>
            {
                this.Text = $"PACMAN - SCORE: {score}";
            });
        }

        private void InvokeUi(Action a)
        {
            this.BeginInvoke(new MethodInvoker(a));
        }
    }
}