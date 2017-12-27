using System;
using System.Collections.Generic;
using System.Threading;
using Pacman.Maze;
using Pacman.Pacman;

namespace Pacman
{
    public class LogicalGhost : LogicalPiece
    {

        private readonly Dictionary<int, Direction> _movementMapping;

        private readonly Random _random = new Random();

        private readonly LogicalPacman _logicalPacman;

        private Direction _dir;

        private double _distance;
        private double _d1;
        private double _d2;
        private double _d3;
        private double _d4;

        public LogicalGhost(int row, int col, ILogicalMaze logicalMaze, LogicalPacman logicalPacman) : base(col, row, logicalMaze)
        {
            this._logicalPacman = logicalPacman;
            GetDistanceOnce();

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

            Distance();
            ChangeDirection(_dir);

            
        }

        public void Distance()
        {
            Console.WriteLine("-----------");
            this.Column++;
            _d1 = GetDistance();
            Console.WriteLine(_d1);
            this.Column--;

            this.Column--;
            _d2 = GetDistance();
            Console.WriteLine(_d2);
            this.Column++;

            this.Row++;
            _d3 = GetDistance();
            Console.WriteLine(_d3);
            this.Row--;

            this.Row--;
            _d4 = GetDistance();
            Console.WriteLine(_d4);
            this.Row++;

            if (_d1 <= _distance && this._logicalMaze.Field[this.Row, this.Column + 1] != MazeTile.Wall)
            {
                _distance = _d1;
                _dir = Direction.Right;
                
            }
            if (_d2 <= _distance && this._logicalMaze.Field[this.Row, this.Column - 1] != MazeTile.Wall)
            {
                _distance = _d2;
                _dir = Direction.Left;
            }
            if(_d3 <= _distance && this._logicalMaze.Field[this.Row + 1, this.Column] != MazeTile.Wall)
            {
                _distance = _d3;
                _dir = Direction.Down;
            }
            if(_d4 <= _distance && this._logicalMaze.Field[this.Row - 1, this.Column] != MazeTile.Wall)
            {
                _distance = _d4;
                _dir = Direction.Up;
            }
            GetDistanceOnce();
            Console.WriteLine("DISTANCE: " + _distance);
            Console.WriteLine(_dir);
        }

        public void GetDistanceOnce()
        {
            var p1 = Math.Pow(this.Row - _logicalPacman.Row, 2);
            var p2 = Math.Pow(this.Column - _logicalPacman.Column, 2);

            _distance = Math.Sqrt(p1 + p2);
        }

        public double GetDistance()
        {
            var p1 = Math.Pow(this.Row - _logicalPacman.Row, 2);
            var p2 = Math.Pow(this.Column - _logicalPacman.Column, 2);

            return Math.Sqrt(p1 + p2);
        }
    }
}