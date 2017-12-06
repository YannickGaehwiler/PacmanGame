using System.Collections.Generic;
using System.Windows.Forms;
using FluentAssertions;
using Pacman.GameController;
using Pacman.Maze;
using Pacman.Panels;
using Xunit;


namespace PacmanTests.PacmanTest
{
    public class PacmanTest
    {
        private readonly GameController _gameController;
        private readonly PacmanPanel _pacmanPanel;
        private readonly ILogicalMaze _logicalMaze;

        public PacmanTest()
        {
            this._logicalMaze = new LogicalMaze();
            this._pacmanPanel = new PacmanPanel();
            this._gameController = new GameController(_logicalMaze, _pacmanPanel, new Panel());
        }


        [Theory]
        [MemberData(nameof(GetDataUpKey))]
        public void MovingPacmanUp_WhenUpKeyIsPressed(MazeTile[,] mazeTile, int expectedColumn, int expectedRow)
        {
            const int columnLocation = 1;
            const int rowLocation = 1;
            this._pacmanPanel.SetLogicalLocation(columnLocation, rowLocation);
            _logicalMaze.Field = mazeTile;

            _gameController.MovePacmanUp();

            this._pacmanPanel.Column.Should().Be(expectedColumn);
            this._pacmanPanel.Row.Should().Be(expectedRow);
        }

        [Theory]
        [MemberData(nameof(GetDataDownKey))]
        public void MovingPacmanDown_WhenDownKeyIsPressed(MazeTile[,] mazeTile, int expectedColumn, int expectedRow)
        {
            const int columnLocation = 1;
            const int rowLocation = 1;
            this._pacmanPanel.SetLogicalLocation(columnLocation, rowLocation);
            _logicalMaze.Field = mazeTile;

            _gameController.MovePacmanDown();

            this._pacmanPanel.Column.Should().Be(expectedColumn);
            this._pacmanPanel.Row.Should().Be(expectedRow);
        }

        [Theory]
        [MemberData(nameof(GetDataRightKey))]
        public void MovingPacmanRight_WhenRightKeyIsPressed(MazeTile[,] mazeTile, int expectedColumn, int expectedRow)
        {
            const int columnLocation = 1;
            const int rowLocation = 1;
            this._pacmanPanel.SetLogicalLocation(columnLocation, rowLocation);
            _logicalMaze.Field = mazeTile;

            _gameController.MovePacmanRight();

            this._pacmanPanel.Column.Should().Be(expectedColumn);
            this._pacmanPanel.Row.Should().Be(expectedRow);
        }

        [Theory]
        [MemberData(nameof(GetDataLeftKey))]
        public void MovingPacmanLeft_WhenLeftKeyIsPressed(MazeTile[,] mazeTile, int expectedColumn, int expectedRow)
        {
            const int columnLocation = 1;
            const int rowLocation = 1;
            this._pacmanPanel.SetLogicalLocation(columnLocation, rowLocation);
            _logicalMaze.Field = mazeTile;

            _gameController.MovePacmanLeft();

            this._pacmanPanel.Column.Should().Be(expectedColumn);
            this._pacmanPanel.Row.Should().Be(expectedRow);
        }

        private static MazeTile[,] GetEmptyMaze()
        {
            return new[,]
            {
                {MazeTile.Empty, MazeTile.Empty, MazeTile.Empty},
                {MazeTile.Empty, MazeTile.Empty, MazeTile.Empty},
                {MazeTile.Empty, MazeTile.Empty, MazeTile.Empty}
            };
        }

        private static MazeTile[,] GetWallMaze()
        {
            return new[,]
            {
                {MazeTile.Wall, MazeTile.Wall, MazeTile.Wall},
                {MazeTile.Wall, MazeTile.Empty, MazeTile.Wall},
                {MazeTile.Wall, MazeTile.Wall, MazeTile.Wall},
            };
        }

        private static MazeTile[,] GetCoinMaze()
        {
            return new[,]
            {
                {MazeTile.Coin, MazeTile.Coin, MazeTile.Coin},
                {MazeTile.Coin, MazeTile.Empty, MazeTile.Coin},
                {MazeTile.Coin, MazeTile.Coin, MazeTile.Coin},
            };
        }

        private static MazeTile[,] GetSuperpillMaze()
        {
            return new[,]
            {
                {MazeTile.Superpill, MazeTile.Superpill, MazeTile.Superpill},
                {MazeTile.Superpill, MazeTile.Empty, MazeTile.Superpill},
                {MazeTile.Superpill, MazeTile.Superpill, MazeTile.Superpill},
            };
        }

        public static IEnumerable<object[]> GetDataUpKey
        {
            get
            {
                yield return new object[] { GetEmptyMaze(), 1, 0 };
                yield return new object[] { GetWallMaze(), 1, 1 };
                yield return new object[] { GetCoinMaze(), 1, 0 };
                yield return new object[] { GetSuperpillMaze(), 1, 0 };
            }
        }

        public static IEnumerable<object[]> GetDataDownKey
        {
            get
            {
                yield return new object[] { GetEmptyMaze(), 1, 2 };
                yield return new object[] { GetWallMaze(), 1, 1 };
                yield return new object[] { GetCoinMaze(), 1, 2 };
                yield return new object[] { GetSuperpillMaze(), 1, 2 };
            }
        }

        public static IEnumerable<object[]> GetDataRightKey
        {
            get
            {
                yield return new object[] { GetEmptyMaze(), 2, 1 };
                yield return new object[] { GetWallMaze(), 1, 1 };
                yield return new object[] { GetCoinMaze(), 2, 1 };
                yield return new object[] { GetSuperpillMaze(), 2, 1 };
            }
        }

        public static IEnumerable<object[]> GetDataLeftKey
        {
            get
            {
                yield return new object[] { GetEmptyMaze(), 0, 1 };
                yield return new object[] { GetWallMaze(), 1, 1 };
                yield return new object[] { GetCoinMaze(), 0, 1 };
                yield return new object[] { GetSuperpillMaze(), 0, 1 };
            }
        }
    }
}