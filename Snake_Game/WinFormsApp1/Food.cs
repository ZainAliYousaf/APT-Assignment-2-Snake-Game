using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public class Food
    {
        private readonly Random _rng = new();
        public PointGrid Position { get; private set; }

        public void Spawn(HashSet<PointGrid> occupied, int width, int height)
        {
            while (true)
            {
                var p = new PointGrid(_rng.Next(0, width), _rng.Next(0, height));
                if (!occupied.Contains(p))
                {
                    Position = p;
                    return;
                }
            }
        }
    }
}

