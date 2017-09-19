using System.Drawing;
using System.Windows.Forms;
using Pacman.Maze;

namespace Pacman.GameController
{
    public interface IGameController
    {
        void MovePacmanUp();
        void MovePacmanDown();
        void MovePacmanRight();
        void MovePacmanLeft();
    }

    public class GameController : IGameController
    {
        private readonly ILogicalMaze _logicalMaze;
        private readonly Pacman _pacman;
        private readonly Panel _pacmanFigure;

        public GameController(ILogicalMaze logicalMaze, Pacman pacman, Panel pacmanFigure)
        {
            _logicalMaze = logicalMaze;
            _pacman = pacman;
            this._pacmanFigure = pacmanFigure;
        }

        public void MovePacmanUp()
        {
            if (_logicalMaze.Field[_pacman.Row - 1, _pacman.Column] == MazeTile.Empty)
            {
                _pacman.Row--;
                _pacmanFigure.Location = new Point(_pacmanFigure.Location.X, _pacmanFigure.Location.Y - 50);
            }
        }

        public void MovePacmanDown()
        {
            if (_logicalMaze.Field[_pacman.Row + 1, _pacman.Column] == MazeTile.Empty)
            {
                _pacman.Row++;
                _pacmanFigure.Location = new Point(_pacmanFigure.Location.X, _pacmanFigure.Location.Y + 50);
            }
            
        }

        public void MovePacmanRight()
        {
            if (_logicalMaze.Field[_pacman.Row, _pacman.Column + 1] == MazeTile.Empty)
            {
                _pacman.Column++;
                _pacmanFigure.Location = new Point(_pacmanFigure.Location.X + 50, _pacmanFigure.Location.Y);
            }
        }

        public void MovePacmanLeft()
        {
            if (_logicalMaze.Field[_pacman.Row, _pacman.Column - 1] == MazeTile.Empty)
            {
                _pacman.Column--;
                _pacmanFigure.Location = new Point(_pacmanFigure.Location.X - 50, _pacmanFigure.Location.Y);
            }
        }
    }
}