namespace WinFormsApp1
{
    /// <summary>
    /// Represents the possible states of the Snake game.
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// The game has not started yet. Instructions or start screen is shown.
        /// </summary>
        Start,

        /// <summary>
        /// The game is currently running and the snake is moving.
        /// </summary>
        Active,

        /// <summary>
        /// The game is paused. Snake movement is stopped until resumed.
        /// </summary>
        Paused,

        /// <summary>
        /// The game has ended due to collision. Final score is shown.
        /// </summary>
        GameOver
    }
}
