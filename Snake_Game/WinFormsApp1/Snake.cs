using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp1
{
    public class Snake
    {
        private readonly LinkedList<PointGrid> _segments = new();
        public Direction Direction { get; private set; } = Direction.Right;

        public IEnumerable<PointGrid> Segments => _segments;
        public PointGrid Head => _segments.First!.Value;

        public Snake(PointGrid start, int initialLength = 3)
        {
            // FIX: use AddLast so head stays at start
            for (int i = 0; i < initialLength; i++)
                _segments.AddLast(new PointGrid(start.X - i, start.Y));
        }

        public void SetDirection(Direction newDir)
        {
            bool isOpposite =
                (Direction == Direction.Up && newDir == Direction.Down) ||
                (Direction == Direction.Down && newDir == Direction.Up) ||
                (Direction == Direction.Left && newDir == Direction.Right) ||
                (Direction == Direction.Right && newDir == Direction.Left);

            if (!isOpposite) Direction = newDir;
        }

        public PointGrid NextHead() => Direction switch
        {
            Direction.Up => new PointGrid(Head.X, Head.Y - 1),
            Direction.Down => new PointGrid(Head.X, Head.Y + 1),
            Direction.Left => new PointGrid(Head.X - 1, Head.Y),
            Direction.Right => new PointGrid(Head.X + 1, Head.Y),
            _ => Head
        };

        public void Move(bool grow)
        {
            _segments.AddFirst(NextHead());
            if (!grow) _segments.RemoveLast();
        }

        public bool Contains(PointGrid p) => _segments.Contains(p);
    }
}
