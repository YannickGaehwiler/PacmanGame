using System;
using System.Collections.Generic;
using Pacman.Maze;

namespace Pacman
{
    public class LogicalPiece
    {
        private readonly ILogicalMaze _logicalMaze;

        protected readonly Dictionary<Direction, Tuple<int, int>> MovementDeltaMapping;
        private readonly Dictionary<Direction, Action> _movement;

        public int Column { get; set; }
        public int Row { get; set; }

        private Direction _currentDirection;
        private Direction _requestedDirecetion;

        public LogicalPiece(int col, int row, ILogicalMaze logicalMaze)
        {
            _logicalMaze = logicalMaze;
            this.Column = col;
            this.Row = row;

            MovementDeltaMapping = new Dictionary<Direction, Tuple<int, int>>
            {
                {Direction.Up, new Tuple<int, int>(-1, 0) },
                {Direction.Right, new Tuple<int, int>(0, 1)},
                {Direction.Left, new Tuple<int, int>(0, -1)},
                {Direction.Down, new Tuple<int, int>(1, 0)}
            };

            _movement = new Dictionary<Direction, Action>
            {
                {Direction.Up, () => { Move(Direction.Up); }},
                {Direction.Right, () => { Move(Direction.Right); }},
                {Direction.Left, () => { Move(Direction.Left); }},
                {Direction.Down, () => { Move(Direction.Down); }}
            };
        }

        public virtual void Move(Direction direction)
        {
            var movementDelta = MovementDeltaMapping[direction];

            Move(movementDelta.Item1, movementDelta.Item2);
        }

        public void ChangeDirection(Direction direction)
        {
            if (direction == _currentDirection)
            {
                return;
            }

            _requestedDirecetion = direction;
        }

        protected void Move(int rowDelta, int columnDelta)
        {
            if (!CanMove(rowDelta, columnDelta))
            {
                return;
            }

            this.Row += rowDelta;
            this.Column += columnDelta;
        }

        private bool CanMove(int rowDelta, int columnDelta)
        {
            if (this._logicalMaze.Field[this.Row + rowDelta, this.Column + columnDelta] == MazeTile.Wall)
            {
                return false;
            }
            return true;
        }

        public void NextStep()
        {
            var movementDelta = MovementDeltaMapping[_requestedDirecetion];

            if (CanMove(movementDelta.Item1, movementDelta.Item2))
            {
                _currentDirection = _requestedDirecetion;
            }

            this._movement[this._currentDirection].Invoke();
        }
    }
}
