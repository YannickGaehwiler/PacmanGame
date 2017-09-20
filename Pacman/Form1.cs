using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private readonly VisualMaze _visualMaze;
        private readonly GameController.GameController _gameController;
        private readonly LogicalMaze _logicalMaze;

        private const string MazeFilePath = @"C:\Users\tkg7y.TKCDEV\Desktop\maze.txt";

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;

            var logicalPacman = new Pacman();
            var mazeGenerator = new MazeGenerator();
            var fileReader = new FileReader.FileReader();

            this._visualMaze = new VisualMaze();
            this._logicalMaze = new LogicalMaze();
            _logicalMaze = (LogicalMaze) mazeGenerator.Generate(fileReader.ReadFile(MazeFilePath))
                .GetMaze();

            pacmanPanel.Location = new Point(30, 30);
            logicalPacman.SetLocation(1, 1);

            _gameController = new GameController.GameController(_logicalMaze, logicalPacman, pacmanPanel);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _visualMaze.GenerateDynamicMaze(_logicalMaze); 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _gameController.MovePacmanUp();
                    break;
                case Keys.D:
                    _gameController.MovePacmanRight();
                    break;
                case Keys.A:
                    _gameController.MovePacmanLeft();
                    break;
                case Keys.S:
                    _gameController.MovePacmanDown();
                    break;
            }
        }
    }
}