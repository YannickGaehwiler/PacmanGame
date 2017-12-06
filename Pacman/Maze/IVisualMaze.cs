using System.Windows.Forms;

namespace Pacman.Maze
{
    public interface IVisualMaze
    {
        Panel GetPanel(int row, int column);
        void SetPanel(MazeTile panelType, int row, int column);
    }
}