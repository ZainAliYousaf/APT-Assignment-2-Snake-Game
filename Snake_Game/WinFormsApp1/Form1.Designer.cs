namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelGame = new Panel();
            lblScore = new Label();
            btnStartRestart = new Button();
            btnPauseResume = new Button();
            label2 = new Label();
            lblHighScore = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // panelGame
            // 
            panelGame.Location = new Point(235, 37);
            panelGame.Name = "panelGame";
            panelGame.Size = new Size(400, 400);
            panelGame.TabIndex = 0;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(401, 478);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(65, 20);
            lblScore.TabIndex = 1;
            lblScore.Text = "Score : 0";
            // 
            // btnStartRestart
            // 
            btnStartRestart.Location = new Point(90, 474);
            btnStartRestart.Name = "btnStartRestart";
            btnStartRestart.Size = new Size(94, 29);
            btnStartRestart.TabIndex = 2;
            btnStartRestart.Text = "Start";
            btnStartRestart.UseVisualStyleBackColor = true;
            // 
            // btnPauseResume
            // 
            btnPauseResume.Location = new Point(214, 474);
            btnPauseResume.Name = "btnPauseResume";
            btnPauseResume.Size = new Size(94, 29);
            btnPauseResume.TabIndex = 3;
            btnPauseResume.Text = "Pause";
            btnPauseResume.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(532, 474);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 4;
            label2.Text = "label2";
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.Location = new Point(501, 478);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(97, 20);
            lblHighScore.TabIndex = 4;
            lblHighScore.Text = "High Score: 0";
            // 
            // gameTimer
            // 
            gameTimer.Interval = 120;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 577);
            Controls.Add(lblHighScore);
            Controls.Add(label2);
            Controls.Add(btnPauseResume);
            Controls.Add(btnStartRestart);
            Controls.Add(lblScore);
            Controls.Add(panelGame);
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelGame;
        private Label lblScore;
        private Button btnStartRestart;
        private Button btnPauseResume;
        private Label label2;
        private Label lblHighScore;
        private System.Windows.Forms.Timer gameTimer;
    }
}
