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
            { Empty, MazeTile.Empty },
            { Wall, MazeTile.Wall },
            { Coin, MazeTile.Coin },
            { Superpill, MazeTile.Superpill }
        };

        private ILogicalMaze _logicalMaze;
        private int _rowLenght;
        private int _rowCount;
        private string[] _lines;

        public IMazeGenerator Generate(string stringMaze)
        {
           this._lines = stringMaze.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
           this._rowLenght = _lines[0].Length;
           this._rowCount = _lines.Length;

            FillMaze();
            return this;
        }

        public ILogicalMaze GetMaze()
        {
            return this._logicalMaze;
        }

        private void FillMaze()
        {
            this._logicalMaze = new LogicalMaze
            {
                Field = new MazeTile[this._rowCount, this._rowLenght]
            };

            for (var row = 0; row < this._rowCount; row++)
            {
                FillRow(this._lines[row], row);
            }
        }

        private void FillRow(string row, int rowNumber)
        {
            for (var column = 0; column < this._rowLenght; column++)
            {
                var c = row[column];
                SetField(c, rowNumber, column);
            }
        }

        private void SetField(char tileCharacter, int row, int column)
        {
            this._logicalMaze.Field[row, column] = this._mazeTileMapping[tileCharacter];
        }
    }
}