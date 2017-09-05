using System;
using FluentAssertions;
using Pacman.Maze;
using Xunit;

namespace PacmanTests.MazeTests
{
    public class MazeGeneratorTest
    {
        private IMazeGenerator _testee;

        public MazeGeneratorTest()
        {
            _testee = new MazeGenerator();
        }

        [Fact]
        void MazeGenerator_CanReadTextMaze()
        {
            // Arrange
            const string stringMaze = "xxxxxx";

            // Act
            var maze = _testee.Generate(stringMaze).GetMaze();

            // Assert
            for (int column = 0; column < stringMaze.Length; column++)
            {
                maze.Field[0, column].Should().Be(MazeTile.Wall);
            }
        }

        [Fact]
        void MazeGenerator_CanReadTextMaze_2D()
        {
            // Arrange
            string stringMaze = 
                "xxxx" + Environment.NewLine +
                "xxxx";


            // Act
            var maze = _testee.Generate(stringMaze).GetMaze();
            var lines = stringMaze.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            // Assert
            for (int row = 0; row < lines.Length; row++)
            {
                for (int column = 0; column < lines[0].Length; column++)
                {
                    maze.Field[row, column].Should().Be(MazeTile.Wall);
                }
                
            }
        }

        [Fact]
        void MazeGenerator_CanReadTextMaze_EmptyFields()
        {
            // Arrange
            var stringMaze = 
                "xxxx" + Environment.NewLine +
                "x  x" + Environment.NewLine +
                "xxxx";


            // Act
            var maze = _testee.Generate(stringMaze).GetMaze();

            // Assert
            maze.Field.ShouldBeEquivalentTo(new MazeTile[3, 4]
            {
                { MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall},
                { MazeTile.Wall, MazeTile.Empty, MazeTile.Empty, MazeTile.Wall},
                { MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall}
            });
        }

        [Fact]
        void MazeGenerator_CanReadTextMaze_Coins()
        {
            // Arrange
            var stringMaze = 
                "xxxx" + Environment.NewLine +
                "x..x" + Environment.NewLine +
                "xxxx";


            // Act
            var maze = _testee.Generate(stringMaze).GetMaze();

            // Assert
            maze.Field.ShouldBeEquivalentTo(new MazeTile[3, 4]
            {
                { MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall},
                { MazeTile.Wall, MazeTile.Coin, MazeTile.Coin, MazeTile.Wall},
                { MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall}
            });
        }

        [Fact]
        void MazeGenerator_CanReadTextMaze_Superpils()
        {
            // Arrange
            var stringMaze = 
                "xxxx" + Environment.NewLine +
                "x!!x" + Environment.NewLine +
                "xxxx";


            // Act
            var maze = _testee.Generate(stringMaze).GetMaze();

            // Assert
            maze.Field.ShouldBeEquivalentTo(new MazeTile[3, 4]
            {
                { MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall},
                { MazeTile.Wall, MazeTile.Superpill, MazeTile.Superpill, MazeTile.Wall},
                { MazeTile.Wall, MazeTile.Wall, MazeTile.Wall, MazeTile.Wall}
            });
        }
    }
}