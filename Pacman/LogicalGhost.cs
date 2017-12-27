using System;
using System.Collections.Generic;
using Pacman.Maze;

namespace Pacman
{
    public class LogicalGhost : LogicalPiece
    {

        private readonly Dictionary<int, Direction> _movementMapping;
        private readonly Random _random = new Random();

        public LogicalGhost(int row, int col, ILogicalMaze logicalMaze) : base(col, row, logicalMaze)
        {
            _movementMapping = new Dictionary<int, Direction>
            {
                {0, Direction.Up },
                {1, Direction.Right},
                {2, Direction.Down},
                {3, Direction.Left}
            };
        }

        public Direction RandomDirection()
        {
            return _movementMapping[_random.Next(4)];
        }

        public override void Move(Direction direction)
        {
            var movementDelta = MovementDeltaMapping[direction];

            Move(movementDelta.Item1, movementDelta.Item2);
            ChangeDirection(this.RandomDirection());
        }
    }
}