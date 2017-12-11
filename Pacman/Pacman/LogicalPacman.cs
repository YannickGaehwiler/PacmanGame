namespace Pacman.Pacman
{
    public class LogicalPacman : ILogicalPacman
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public LogicalPacman(int col, int row)
        {
            this.Column = col;
            this.Row = row;
        }
    }
}