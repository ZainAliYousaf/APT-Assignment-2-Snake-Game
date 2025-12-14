using System.Collections.Generic;

namespace WinFormsApp1
{
    public class GameEngine
    {
        public int GridWidth { get; }
        public int GridHeight { get; }
        public int Score { get; private set; }
        public int HighScore { get; private set; }
        public GameState State { get; private set; } = GameState.Start;

        public Snake? Snake { get; private set; } // ✅ Nullable to fix CS8618
        public Food Food { get; } = new();

        public int TickIntervalMs { get; private set; } = 120;

        public GameEngine(int gridWidth = 20, int gridHeight = 20)
        {
            GridWidth = gridWidth;
            GridHeight = gridHeight;
            Initialize();
        }

        public void Initialize()
        {
            Score = 0;
            var start = new PointGrid(GridWidth / 2, GridHeight / 2);
            Snake = new Snake(start, initialLength: 3);
            var occupied = new HashSet<PointGrid>(Snake!.Segments); // ✅ Use ! to suppress CS8602
            Food.Spawn(occupied, GridWidth, GridHeight);
            State = GameState.Start;
        }

        public void Start() => State = GameState.Active;

        public void Pause()
        {
            if (State == GameState.Active) State = GameState.Paused;
        }

        public void Resume()
        {
            if (State == GameState.Paused) State = GameState.Active;
        }

        public void Restart()
        {
            if (Score > HighScore) HighScore = Score;
            Initialize();
            Start();
        }

        public void SetDirection(Direction dir) => Snake!.SetDirection(dir); // ✅ Use ! here too

        public void Update()
        {
            if (State != GameState.Active) return;

            var nextHead = Snake!.NextHead(); // ✅ Use ! here too

            if (nextHead.X < 0 || nextHead.Y < 0 ||
                nextHead.X >= GridWidth || nextHead.Y >= GridHeight ||
                Snake!.Contains(nextHead)) // ✅ Use ! here too
            {
                EndGame();
                return;
            }

            bool ateFood = nextHead == Food.Position;
            Snake!.Move(grow: ateFood); // ✅ Use ! here too

            if (ateFood)
            {
                Score += 10;
                var occupied = new HashSet<PointGrid>(Snake!.Segments); // ✅ Use ! here too
                Food.Spawn(occupied, GridWidth, GridHeight);
            }
        }

        private void EndGame()
        {
            if (Score > HighScore) HighScore = Score;
            State = GameState.GameOver;
        }
    }
}
