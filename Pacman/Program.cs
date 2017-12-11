using System;
using System.Drawing;
using System.Windows.Forms;
using Pacman.GameController;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman
{
    internal static class Program
    {
        public static readonly string MazeFilePath = @"C:\Users\tkg7y.TKCDEV\Desktop\maze.txt";

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var myForm = new Form1(CreateGameController, CreatePacman);
            Application.Run(myForm);
        }

        private static IGameController CreateGameController()
        {
            var mazeGenerator = new MazeGenerator();
            var fileReader = new FileReader.FileReader();
            var logicalMaze = (LogicalMaze) mazeGenerator.Generate(fileReader.ReadFile(MazeFilePath)).GetMaze();
            
            return new GameController.GameController(logicalMaze);
        }

        private static PacmanPanel CreatePacman()
        {
            var pacman = new PacmanPanel();
            pacman.Draw(new Point(30 * 1, 30 * 1));

            return pacman;
        }
    }
}