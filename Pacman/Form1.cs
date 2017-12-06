using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Pacman.GameController;
using Pacman.Maze;
using Pacman.Panels;

namespace Pacman
{
    public interface IRedraw
    {
        void RedrawMaze(IVisualMaze visualMaze);
    }

    public partial class Form1 : Form, IRedraw
    {
        private IGameController _gameController = null;
        private readonly Func<IGameController> _gameControllerFactory;

        public Form1(Func<IGameController> gameControllerFactory)
        {
            InitializeComponent();
            KeyPreview = true;
            this._gameControllerFactory = gameControllerFactory;
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

        public void RedrawMaze(IVisualMaze visualMaze)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (this._gameController == null)
            {
                this._gameController = this._gameControllerFactory();
            }
        }
    }
}