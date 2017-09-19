using System;
using Xunit;
using FluentAssertions;
using Pacman.FileReader;
using Pacman.Maze;

namespace PacmanTests.FileReaderTest
{
    public class FileReaderTest
    {
        private readonly IFileReader _testee;
        private const string Path = @"FileReaderTest/TestFiles/maze.txt";

        public FileReaderTest()
        {
            _testee = new FileReader();
        }

        [Fact]
        private void FileReader_CanReadMazeFromFile()
        {
            var mazeString = _testee.ReadFile(Path);

            mazeString.Should().Be(
                "xxxxxxxxxx" + Environment.NewLine +
                "x...  ...x" + Environment.NewLine +
                "x.!.xx.!.x" + Environment.NewLine +
                "x...  ...x" + Environment.NewLine +
                "xxxxxxxxxx");
        }
    }
}
