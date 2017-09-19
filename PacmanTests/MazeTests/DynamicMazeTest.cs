using Xunit;
using FluentAssertions;
using Pacman.FileReader;
using Pacman.Maze;

namespace PacmanTests.MazeTests
{
    class DynamicMazeTest
    {
        private readonly VisualMaze _testee;
        public DynamicMazeTest()
        {
            _testee = new VisualMaze();
        }

        [Fact]
        private void DynamicMazeTest_GenerateMaze()
        {
            
        }
    }
}
