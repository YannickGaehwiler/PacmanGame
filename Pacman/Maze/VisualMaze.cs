using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Pacman.Panels;

namespace Pacman.Maze
{
    public class VisualMaze : IVisualMaze
    {
        public PacmanPanel Pacman;

        public VisualMaze(ILogicalMaze logicalMaze)
        {
            GenerateDynamicMaze(logicalMaze);
        }

        private int _currentRow;
        private int _currentColumn;

        public BasePanel[,] Panels;

        private readonly Dictionary<MazeTile, BasePanel> _panelMapping = new Dictionary<MazeTile, BasePanel>
        {
            {MazeTile.Empty, new EmptyPanel()},
            {MazeTile.Coin, new CoinPanel()},
            {MazeTile.Wall, new WallPanel()},
            {MazeTile.Superpill, new SuperPillPanel()},
        };

        private static int _numberOfColumns;
        private static int _numberOfRows;

        private void GenerateDynamicMaze(ILogicalMaze logicalMaze)
        {
            _currentRow = 0;

            _numberOfRows = logicalMaze.Field.GetLength(0);
            _numberOfColumns = logicalMaze.Field.Length / _numberOfRows;

            Panels = new BasePanel[_numberOfRows, _numberOfColumns];

            for (var rowNumber = 0; rowNumber < _numberOfRows; rowNumber++)
            {
                DrawRow(rowNumber, logicalMaze);
            }
        }

        private void DrawRow(int rowNumber, ILogicalMaze logicalMaze)
        {
            _currentColumn = 0;

            for (var columnNumber = 0; columnNumber < _numberOfColumns; columnNumber++)
            {
                var template = _panelMapping[logicalMaze.Field[rowNumber, columnNumber]];
                var panel = template?.Clone();
                panel.Draw(columnNumber, rowNumber);
                Panels[_currentRow, _currentColumn] = panel; 
                _currentColumn++;
            }
            _currentRow++;
        }

        public Panel GetPanel(int row, int column)
        {
            return Panels[row, column];
        }

        public void SetPanel(MazeTile panelType, int row, int column)
        {
            Panels[row, column] = this._panelMapping[panelType].Clone();
            Panels[row, column].Draw(column, row);
        }
    }
}