using System;
using System.Drawing;
using System.Windows.Forms;
using Pacman.GameController;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman
{
    public interface Ix
    {
        void SetMazeTileAtPosition(MazeTile mazeTile, int row, int column);
        void SetPacman(int row, int column);
        void SetMaze(ILogicalMaze logicalMaze);
    }

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
                    _gameController.MovePacmanUp(UpdateMaze);
                    break;
                case Keys.D:
                    _gameController.MovePacmanRight(UpdateMaze);
                    break;
                case Keys.A:
                    _gameController.MovePacmanLeft(UpdateMaze);
                    break;
                case Keys.S:
                    _gameController.MovePacmanDown(UpdateMaze);
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (this._gameController == null)
            {
                this._pacman = this._pacmanFactory();
                this._gameController = this._gameControllerFactory();
                _visualMaze = new VisualMaze(_gameController.LogicalMaze);
            }
        }

        private void UpdateMaze(int column, int row)
        {
            _pacman.Location = new Point(row * 30, column * 30);
        }
    }
}