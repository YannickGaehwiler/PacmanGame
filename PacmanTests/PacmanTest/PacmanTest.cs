using FluentAssertions;
using Pacman.GameController;
using Pacman.Maze;
using Xunit;


namespace PacmanTests.PacmanTest
{
    public class PacmanTest
    {
        private readonly GameController _gameController;
        private readonly Pacman.Pacman _pacman;

        public PacmanTest()
        {
            ILogicalMaze logicalMaze = new LogicalMaze();
            _pacman = new Pacman.Pacman();
            this._gameController = new GameController(logicalMaze, _pacman);

            logicalMaze.Field = new[,]
            {
                { MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall},
                { MazeTile.Wall, MazeTile.Empty, MazeTile.Empty, MazeTile.Empty, MazeTile.Wall},
                { MazeTile.Wall, MazeTile.Empty, MazeTile.Empty, MazeTile.Empty, MazeTile.Wall},
                { MazeTile.Wall, MazeTile.Empty, MazeTile.Empty, MazeTile.Empty, MazeTile.Wall},
                { MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall}
            };
        }


        [Fact]
        public void MovingPacmanUp_WhenUpKeyIsPressed()
        {
            const int columnLocation = 2;
            const int rowLocation = 2;

            this._pacman.SetLocation(columnLocation, rowLocation);

            _gameController.MovePacmanUp();

            this._pacman.Column.Should().Be(2);
            this._pacman.Row.Should().Be(1);
        }

        [Fact]
        public void MovingPacmanDown_WhenDownKeyIsPressed()
        {
            const int columnLocation = 2;
            const int rowLocation = 2;

            this._pacman.SetLocation(columnLocation, rowLocation);

            _gameController.MovePacmanDown();

            this._pacman.Column.Should().Be(2);
            this._pacman.Row.Should().Be(3);
        }

        [Fact]
        public void MovingPacmanRight_WhenRightKeyIsPressed()
        {
            const int columnLocation = 2;
            const int rowLocation = 2;

            this._pacman.SetLocation(columnLocation, rowLocation);

            _gameController.MovePacmanRight();
            
            this._pacman.Column.Should().Be(3);
            this._pacman.Row.Should().Be(2);
        }

        [Fact]
        public void MovingPacmanLeft_WhenLeftKeyIsPressed()
        {
            const int columnLocation = 2;
            const int rowLocation = 2;

            this._pacman.SetLocation(columnLocation, rowLocation);

            _gameController.MovePacmanLeft();
            
            this._pacman.Column.Should().Be(1);
            this._pacman.Row.Should().Be(2);
        }


        [Fact]
        public void MovingPacmanUp_WhenUpkeyIsPressed_WithWallAbove()
        {
            const int columnLocation = 2;
            const int rowLocation = 1;

            this._pacman.SetLocation(columnLocation, rowLocation);

            _gameController.MovePacmanUp();

            this._pacman.Column.Should().Be(2);
            this._pacman.Row.Should().Be(1);
        }

        [Fact]
        public void MovingPacmanDown_WhenDownkeyIsPressed_WithWallUnder()
        {
            const int columnLocation = 2;
            const int rowLocation = 3;
            
            this._pacman.SetLocation(columnLocation, rowLocation);

            _gameController.MovePacmanDown();

            this._pacman.Column.Should().Be(2);
            this._pacman.Row.Should().Be(3);
        }

        [Fact]
        public void MovingPacmanRight_WhenRightkeyIsPressed_WithWallRight()
        {
            const int columnLocation = 3;
            const int rowLocation = 2;
            
            this._pacman.SetLocation(columnLocation, rowLocation);

            _gameController.MovePacmanRight();

            this._pacman.Column.Should().Be(3);
            this._pacman.Row.Should().Be(2);
        }

        [Fact]
        public void MovingPacmanLeft_WhenLeftkeyIsPressed_WithWallLeft()
        {
            const int columnLocation = 1;
            const int rowLocation = 2;
            
            this._pacman.SetLocation(columnLocation, rowLocation);

            _gameController.MovePacmanLeft();

            this._pacman.Column.Should().Be(1);
            this._pacman.Row.Should().Be(2);
        }
    }
}