namespace Pacman.Maze
{
    public interface IMazeGenerator
    {
        IMazeGenerator Generate(string stringMaze);
        ILogicalMaze GetMaze();
    }
}