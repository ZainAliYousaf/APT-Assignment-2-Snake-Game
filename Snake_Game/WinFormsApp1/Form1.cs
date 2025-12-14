using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly GameEngine _engine;
        private readonly int _cellSize = 20;

        public Form1()
        {
            InitializeComponent();

            // Enable double buffering to reduce blinking
            panelGame.DoubleBuffered(true);

            // Ensure arrow keys are captured by the form
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            // Set grid to 30x30
            _engine = new GameEngine(gridWidth: 30, gridHeight: 30);

            // Size panel to match grid
            panelGame.Width = _engine.GridWidth * _cellSize;
            panelGame.Height = _engine.GridHeight * _cellSize;

            // Hook events
            panelGame.Paint += PanelGame_Paint;

            // Slightly slower timer for smoother visuals
            gameTimer.Interval = 150;
            gameTimer.Tick += GameTimer_Tick;

            btnStartRestart.Click += BtnStartRestart_Click;
            btnPauseResume.Click += BtnPauseResume_Click;

            UpdateUI();
        }

        private void GameTimer_Tick(object? sender, EventArgs e)
        {
            _engine.Update();
            UpdateUI();
            panelGame.Invalidate(); // repaint panel
        }

        private void PanelGame_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.Black);

            // Optional grid lines
            using var gridPen = new Pen(Color.DimGray);
            for (int x = 0; x <= _engine.GridWidth; x++)
                g.DrawLine(gridPen, x * _cellSize, 0, x * _cellSize, panelGame.Height);
            for (int y = 0; y <= _engine.GridHeight; y++)
                g.DrawLine(gridPen, 0, y * _cellSize, panelGame.Width, y * _cellSize);

            // Snake body
            foreach (var seg in _engine.Snake.Segments)
            {
                var rect = new Rectangle(seg.X * _cellSize, seg.Y * _cellSize, _cellSize, _cellSize);
                g.FillRectangle(Brushes.LimeGreen, rect);
                g.DrawRectangle(Pens.ForestGreen, rect);
            }

            // Snake head
            var head = _engine.Snake.Head;
            var headRect = new Rectangle(head.X * _cellSize, head.Y * _cellSize, _cellSize, _cellSize);
            g.FillRectangle(Brushes.GreenYellow, headRect);
            g.DrawRectangle(Pens.Goldenrod, headRect);

            // Food
            var foodRect = new Rectangle(_engine.Food.Position.X * _cellSize, _engine.Food.Position.Y * _cellSize, _cellSize, _cellSize);
            g.FillEllipse(Brushes.Red, foodRect);
            g.DrawEllipse(Pens.DarkRed, foodRect);
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (_engine.State != GameState.Active) return;

            if (e.KeyCode == Keys.Up) _engine.SetDirection(Direction.Up);
            else if (e.KeyCode == Keys.Down) _engine.SetDirection(Direction.Down);
            else if (e.KeyCode == Keys.Left) _engine.SetDirection(Direction.Left);
            else if (e.KeyCode == Keys.Right) _engine.SetDirection(Direction.Right);
            else if (e.KeyCode == Keys.Space) TogglePauseResume();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_engine.State == GameState.Active)
            {
                if (keyData == Keys.Up) _engine.SetDirection(Direction.Up);
                else if (keyData == Keys.Down) _engine.SetDirection(Direction.Down);
                else if (keyData == Keys.Left) _engine.SetDirection(Direction.Left);
                else if (keyData == Keys.Right) _engine.SetDirection(Direction.Right);
                else if (keyData == Keys.Space) TogglePauseResume();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnStartRestart_Click(object? sender, EventArgs e)
        {
            if (_engine.State == GameState.Start)
            {
                _engine.Start();
                gameTimer.Start();
            }
            else if (_engine.State == GameState.GameOver)
            {
                _engine.Restart();
                gameTimer.Start();
            }
            UpdateUI();
        }

        private void BtnPauseResume_Click(object? sender, EventArgs e) => TogglePauseResume();

        private void TogglePauseResume()
        {
            if (_engine.State == GameState.Active)
            {
                _engine.Pause();
                gameTimer.Stop();
            }
            else if (_engine.State == GameState.Paused)
            {
                _engine.Resume();
                gameTimer.Start();
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            lblScore.Text = $"Score: {_engine.Score}";
            lblHighScore.Text = $"High Score: {_engine.HighScore}";

            switch (_engine.State)
            {
                case GameState.Start:
                    btnStartRestart.Text = "Start";
                    btnPauseResume.Enabled = false;
                    break;

                case GameState.Active:
                    btnStartRestart.Text = "Restart";
                    btnPauseResume.Enabled = true;
                    break;

                case GameState.Paused:
                    btnStartRestart.Text = "Restart";
                    btnPauseResume.Enabled = true;
                    break;

                case GameState.GameOver:
                    btnStartRestart.Text = "Restart";
                    btnPauseResume.Enabled = false;
                    gameTimer.Stop();
                    MessageBox.Show($"Game Over!\nFinal Score: {_engine.Score}", "Snake");
                    break;
            }
        }
    }

    // Extension method for double buffering
    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            var doubleBufferPropertyInfo = control.GetType().GetProperty(
                "DoubleBuffered",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }
    }
}
