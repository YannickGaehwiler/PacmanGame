using System;
using System.Collections.Generic;

namespace Pacman.Maze
{
    public class MazeGenerator : IMazeGenerator
    {
        private const char Empty = ' ';
        private const char Wall = 'x';
        private const char Coin = '.';
        private const char Superpill = '!';

        private readonly Dictionary<char, MazeTile> _mazeTileMapping = new Dictionary<char, MazeTile>
        {
            {Empty, MazeTile.Empty},
            {Wall, MazeTile.Wall},
            {Coin, MazeTile.Coin},
            {Superpill, MazeTile.Superpill}
        };

        private string[] _lines;

        private ILogicalMaze _logicalMaze;
        private int _rowCount;
        private int _rowLenght;

        public IMazeGenerator Generate(string stringMaze)
        {
            _lines = stringMaze.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            _rowLenght = _lines[0].Length;
            _rowCount = _lines.Length;

            FillMaze();
            return this;
        }

        public ILogicalMaze GetMaze()
        {
            return _logicalMaze;
        }

        private void FillMaze()
        {
            _logicalMaze = new LogicalMaze
            {
                Field = new MazeTile[_rowCount, _rowLenght]
            };

            for (var row = 0; row < _rowCount; row++)
                FillRow(_lines[row], row);
        }

        private void FillRow(string row, int rowNumber)
        {
            for (var column = 0; column < _rowLenght; column++)
            {
                var c = row[column];
                SetField(c, rowNumber, column);
            }
        }

        private void SetField(char tileCharacter, int row, int column)
        {
            _logicalMaze.Field[row, column] = _mazeTileMapping[tileCharacter];
        }
    }
}