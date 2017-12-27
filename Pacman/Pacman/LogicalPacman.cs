using Pacman.Maze;

namespace Pacman.Pacman
{
    public class LogicalPacman : Movement, ILogicalPacman
    {
        public LogicalPacman(int row, int col, ILogicalMaze logicalMaze) : base(logicalMaze)
        {
            this.Column = col;
            this.Row = row;
        }
    }
}