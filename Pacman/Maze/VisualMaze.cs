using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Pacman.Panels;

namespace Pacman.Maze
{
    public class VisualMaze
    {
        private const int XPosition = 50;
        private const int YPosition = 50;

        private readonly Dictionary<MazeTile, BasePanel> _panelMapping = new Dictionary<MazeTile, BasePanel>
        {
            {MazeTile.Empty, null},
            {MazeTile.Coin, new CoinPanel()},
            {MazeTile.Wall, new WallPanel()},
            {MazeTile.Superpill, new SuperPillPanel()}
        };

        private int _numberOfColumns;

        public void GenerateDynamicMaze(ILogicalMaze logicalMaze)
        {
            var numberOfRows = logicalMaze.Field.GetLength(0);
            _numberOfColumns = logicalMaze.Field.Length / numberOfRows;

            for (var rowNumber = 0; rowNumber < numberOfRows; rowNumber++)
                DrawRow(rowNumber, logicalMaze);
        }

        public void DrawRow(int rowNumber, ILogicalMaze logicalMaze)
        {
            for (var columnNumber = 0; columnNumber < _numberOfColumns; columnNumber++)
            {
                var panel = _panelMapping[logicalMaze.Field[rowNumber, columnNumber]];
                panel?.Clone().Draw(new Point(XPosition * columnNumber, YPosition * rowNumber), Form.ActiveForm);
            }
        }
    }
}