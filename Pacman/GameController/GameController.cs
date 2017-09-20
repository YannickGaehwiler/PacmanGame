using System.Drawing;
using System.Windows.Forms;
using Pacman.Maze;

namespace Pacman.GameController
{
    public class GameController : IGameController
    {
        private readonly ILogicalMaze _logicalMaze;
        private readonly Pacman _logicalPacman;
        private readonly Panel _pacmanPanel;

        private const int Step = 30;

        public int Score;

        public GameController(ILogicalMaze logicalMaze, Pacman logicalPacman, Panel pacmanPanel)
        {
            this._logicalMaze = logicalMaze;
            this._logicalPacman = logicalPacman;
            this._pacmanPanel = pacmanPanel;
        }

        public void MovePacmanUp()
        {
            switch (_logicalMaze.Field[_logicalPacman.Row - 1, _logicalPacman.Column])
            {
                case MazeTile.Empty:
                    _logicalPacman.Row--;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X, _pacmanPanel.Location.Y - Step);
                    break;
                case MazeTile.Coin:
                    _logicalPacman.Row--;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X, _pacmanPanel.Location.Y - Step);
                    break;
                case MazeTile.Superpill:
                    _logicalPacman.Row--;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X, _pacmanPanel.Location.Y - Step);
                    break;
            }
        }

        public void MovePacmanDown()
        {
            switch (_logicalMaze.Field[_logicalPacman.Row + 1, _logicalPacman.Column])
            {
                case MazeTile.Empty:
                    _logicalPacman.Row++;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X, _pacmanPanel.Location.Y + Step);
                    break;
                case MazeTile.Coin:
                    _logicalPacman.Row++;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X, _pacmanPanel.Location.Y + Step);
                    break;
                case MazeTile.Superpill:
                    _logicalPacman.Row++;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X, _pacmanPanel.Location.Y + Step);
                    break;
            }
        }

        public void MovePacmanRight()
        {
            switch (_logicalMaze.Field[_logicalPacman.Row, _logicalPacman.Column + 1])
            {
                case MazeTile.Empty:
                    _logicalPacman.Column++;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X + Step, _pacmanPanel.Location.Y);
                    break;
                case MazeTile.Coin:
                    _logicalPacman.Column++;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X + Step, _pacmanPanel.Location.Y);
                    break;
                case MazeTile.Superpill:
                    _logicalPacman.Column++;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X + Step, _pacmanPanel.Location.Y);
                    break;
            }
        }

        public void MovePacmanLeft()
        {
            switch (_logicalMaze.Field[_logicalPacman.Row, _logicalPacman.Column - 1])
            {
                case MazeTile.Empty:
                    _logicalPacman.Column--;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X - Step, _pacmanPanel.Location.Y);
                    break;
                case MazeTile.Coin:
                    _logicalPacman.Column--;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X - Step, _pacmanPanel.Location.Y);
                    Score++;
                    break;
                case MazeTile.Superpill:
                    _logicalPacman.Column--;
                    _pacmanPanel.Location = new Point(_pacmanPanel.Location.X - Step, _pacmanPanel.Location.Y);
                    break;
            }
        }
    }
}