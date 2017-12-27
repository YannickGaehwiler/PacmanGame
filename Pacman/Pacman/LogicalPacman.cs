using Pacman.Maze;

namespace Pacman.Pacman
{
    public class LogicalPacman : LogicalPiece, ILogicalPacman
    {
        public LogicalPacman(int row, int col, ILogicalMaze logicalMaze) : base(col, row, logicalMaze)
        {

        }
    }
}