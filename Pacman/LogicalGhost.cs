using System;
using System.Collections.Generic;
using Pacman.Maze;
using Pacman.Pacman;

namespace Pacman
{
    public class LogicalGhost : LogicalPiece
    {

        private readonly Dictionary<int, Direction> _movementMapping;

        private readonly Random _random = new Random();

        private readonly LogicalPacman _logicalPacman;

        

        private double _distanceToPacman;
        

        public LogicalGhost(int row, int col, ILogicalMaze logicalMaze, LogicalPacman logicalPacman) : base(col, row, logicalMaze)
        {
            this._logicalPacman = logicalPacman;
            _distanceToPacman = GetDistanceToPacman();

            _movementMapping = new Dictionary<int, Direction>
            {
                {0, Direction.Up },
                {1, Direction.Right},
                {2, Direction.Down},
                {3, Direction.Left}
            };
        }

        public override void Move(Direction direction)
        {
            var movementDelta = MovementDeltaMapping[direction];

            Move(movementDelta.Item1, movementDelta.Item2);

            ChangeDirection(GetDirection());
        }

        private Direction GetDirection()
        {
            var newDirection = Direction.Up;
            var distanceRight = GetDistanceToPacman(rowDelta: 0, columnDelta: 1);
            var distanceLeft = GetDistanceToPacman(rowDelta: 0, columnDelta: -1);
            var distanceDown = GetDistanceToPacman(rowDelta: +1, columnDelta: 0);
            var distanceUp = GetDistanceToPacman(rowDelta: -1, columnDelta: 0);

            if (distanceRight <= _distanceToPacman && this._logicalMaze.Field[this.Row, this.Column + 1] != MazeTile.Wall)
            {
                _distanceToPacman = distanceRight;
                newDirection = Direction.Right;
            }
            if (distanceLeft <= _distanceToPacman && this._logicalMaze.Field[this.Row, this.Column - 1] != MazeTile.Wall)
            {
                _distanceToPacman = distanceLeft;
                newDirection = Direction.Left;
            }
            if(distanceDown <= _distanceToPacman && this._logicalMaze.Field[this.Row + 1, this.Column] != MazeTile.Wall)
            {
                _distanceToPacman = distanceDown;
                newDirection = Direction.Down;
            }
            if(distanceUp <= _distanceToPacman && this._logicalMaze.Field[this.Row - 1, this.Column] != MazeTile.Wall)
            {
                _distanceToPacman = distanceUp;
                newDirection = Direction.Up;
            }

            _distanceToPacman = GetDistanceToPacman();
            return newDirection;
        }

        private double GetDistanceToPacman(int rowDelta = 0, int columnDelta = 0)
        {
            var p1 = Math.Pow(this.Row + rowDelta - _logicalPacman.Row, 2);
            var p2 = Math.Pow(this.Column + columnDelta - _logicalPacman.Column, 2);
            
            return Math.Sqrt(p1 + p2);
        }
    }
}