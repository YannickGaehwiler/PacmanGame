using System;
using System.Drawing;
using System.Windows.Forms;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private readonly Pacman _pacmanFigure;
        private readonly FileReader.FileReader _fileReader;
        private readonly VisualMaze _visualMaze;
        private readonly MazeGenerator _mazeGenerator;
        private readonly GameController.GameController _gameController;

        readonly ILogicalMaze _logicalMaze = new LogicalMaze
        {
            Field = new[,]
            {
                {MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall},
                {MazeTile.Wall, MazeTile.Empty, MazeTile.Empty, MazeTile.Empty, MazeTile.Wall},
                {MazeTile.Wall, MazeTile.Empty, MazeTile.Empty, MazeTile.Empty, MazeTile.Wall},
                {MazeTile.Wall, MazeTile.Empty, MazeTile.Empty, MazeTile.Empty, MazeTile.Wall},
                {MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall}
            }
        };

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            this._pacmanFigure = new Pacman();
            this._fileReader = new FileReader.FileReader();
            this._visualMaze = new VisualMaze();
            this._mazeGenerator = new MazeGenerator();
            pacman.Location = new Point(50, 50);
            _pacmanFigure.SetLocation(1, 1);
            _gameController = new GameController.GameController(_logicalMaze, _pacmanFigure, pacman);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _visualMaze.GenerateDynamicMaze(_logicalMaze);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                _gameController.MovePacmanUp();
            }
            else if (e.KeyCode == Keys.D)
            {
                _gameController.MovePacmanRight();
            }
            else if (e.KeyCode == Keys.A)
            {
                _gameController.MovePacmanLeft();
            }
            else if (e.KeyCode == Keys.S)
            {
                _gameController.MovePacmanDown();
            }
        }
    }
}