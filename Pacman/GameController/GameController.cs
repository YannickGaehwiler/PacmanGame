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

        public GameController(ILogicalMaze logicalMaze, Pacman pacman)
        {
            _logicalMaze = logicalMaze;
            _pacman = pacman;
        }

        public void MovePacmanUp()
        {
            if (_logicalMaze.Field[_pacman.Row - 1, _pacman.Column] == MazeTile.Empty)
            {
                _pacman.Row--;
            }
        }

        public void MovePacmanDown()
        {
            if (_logicalMaze.Field[_pacman.Row + 1, _pacman.Column] == MazeTile.Empty)
            {
                _pacman.Row++;
            }
            
        }

        public void MovePacmanRight()
        {
            if (_logicalMaze.Field[_pacman.Row, _pacman.Column + 1] == MazeTile.Empty)
            {
                _pacman.Column++;
            }
        }

        public void MovePacmanLeft()
        {
            if (_logicalMaze.Field[_pacman.Row, _pacman.Column - 1] == MazeTile.Empty)
            {
                _pacman.Column--;
            }
        }
    }
}