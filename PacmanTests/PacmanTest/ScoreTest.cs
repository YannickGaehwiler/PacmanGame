using System.Windows.Forms;
using FluentAssertions;
using Pacman.GameController;
using Pacman.Maze;
using Pacman.Panels;
using Xunit;

namespace PacmanTests.PacmanTest
{
    public class ScoreTest
    {
        private readonly GameController _gameController;
        private readonly PacmanPanel _pacmanPanel;

        public ScoreTest()
        {
            ILogicalMaze logicalMaze = new LogicalMaze
            {
                Field = new[,]
                {
                    {MazeTile.Coin, MazeTile.Coin, MazeTile.Coin},
                    {MazeTile.Coin, MazeTile.Empty, MazeTile.Coin},
                    {MazeTile.Coin, MazeTile.Coin, MazeTile.Coin},
                }
            };

            this._pacmanPanel = new PacmanPanel();
            this._gameController = new GameController(logicalMaze, _pacmanPanel, new Panel());
        }

        [Fact]
        public void IncreaseScoreByOne_WhenPacmanOnCoin_Up()
        {
            const int columnLocation = 1;
            const int rowLocation = 1;
            this._pacmanPanel.SetLogicalLocation(columnLocation, rowLocation);

            _gameController.MovePacmanUp();

            this._gameController.Score.Should().Be(1);
        }

        [Fact]
        public void IncreaseScoreByOne_WhenPacmanOnCoin_Down()
        {
            const int columnLocation = 1;
            const int rowLocation = 1;
            this._pacmanPanel.SetLogicalLocation(columnLocation, rowLocation);

            _gameController.MovePacmanDown();

            this._gameController.Score.Should().Be(1);
        }

        [Fact]
        public void IncreaseScoreByOne_WhenPacmanOnCoin_Left()
        {
            const int columnLocation = 1;
            const int rowLocation = 1;
            this._pacmanPanel.SetLogicalLocation(columnLocation, rowLocation);

            _gameController.MovePacmanLeft();

            this._gameController.Score.Should().Be(1);
        }

        [Fact]
        public void IncreaseScoreByOne_WhenPacmanOnCoin_Right()
        {
            const int columnLocation = 1;
            const int rowLocation = 1;
            this._pacmanPanel.SetLogicalLocation(columnLocation, rowLocation);

            _gameController.MovePacmanRight();

            this._gameController.Score.Should().Be(1);
        }
    }
}
