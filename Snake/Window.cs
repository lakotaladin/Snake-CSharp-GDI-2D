using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class Window : Form
    {
        private const int WIDTH = 30;
        private const int HEIGHT = 30;
        private const string SCORE_STRING = "Skor: {0}";
        private readonly Color m_BackgroundColor = Color.Khaki;
        private readonly Game m_Game;
        private readonly Bitmap m_GameField;
        private readonly Graphics m_GameGraphics;
        private bool m_GameLost = false; // Prati stanje igre


        public Window()
        {
            InitializeComponent();
            m_GameField = new Bitmap(WIDTH * Piece.SIDE, HEIGHT * Piece.SIDE);
            m_GameGraphics = Graphics.FromImage(m_GameField);
            m_GameGraphics.PageUnit = GraphicsUnit.Pixel;
            ClientSize = new Size(m_GameField.Width, m_GameField.Height + m_RestartBtn.Height);
            m_Game = new Game(WIDTH, HEIGHT);
            m_Timer.Start();
        }

        private void UpdateScore()
        {
            scoreLbl.Text = string.Format(SCORE_STRING, m_Game.GetScore());
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (m_GameLost)
            {
                // Ako je igra izgubljena, ne radimo ništa
                return;
            }

            if (m_Game.SnakeHasGrown())
            {
                UpdateScore();
            }

            if (m_Game.Lost())
            {
                m_Timer.Stop();
                m_GameLost = true; // Postavljam da je igra izgubljena
                m_RestartBtn.Enabled = true;
            }

            Invalidate();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (m_GameLost)
            {
                // Ako je igra izgubljena, ne reagujemo na tastere
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Left:
                    m_Game.ChangeSnakeDIrection(Direction.Left);
                    break;
                case Keys.Right:
                    m_Game.ChangeSnakeDIrection(Direction.Right);
                    break;
                case Keys.Up:
                    m_Game.ChangeSnakeDIrection(Direction.Up);
                    break;
                case Keys.Down:
                    m_Game.ChangeSnakeDIrection(Direction.Down);
                    break;
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            m_GameGraphics.Clear(m_BackgroundColor);
            m_Game.Draw(m_GameGraphics);
            e.Graphics.DrawImage(m_GameField, 0, m_RestartBtn.Height);

        
            if (m_GameLost)
            {
                var gameOverFont = new Font("Arial", 36, FontStyle.Bold);
                var gameOverBrush = new SolidBrush(Color.Red);
                var gameOverText = "Izgubio/la si!";
                var gameOverSize = e.Graphics.MeasureString(gameOverText, gameOverFont);
                var x = (m_GameField.Width - gameOverSize.Width) / 2;
                var y = (m_GameField.Height - gameOverSize.Height) / 2;
                e.Graphics.DrawString(gameOverText, gameOverFont, gameOverBrush, x, y);
            }
        }

        private void OnRestartBtnClick(object sender, EventArgs e)
        {
            m_GameLost = false; // Resetujem igricu
            m_RestartBtn.Enabled = false;
            m_Game.Restart();
            UpdateScore();
            m_Timer.Start();
        }

        private void scoreLbl_Click(object sender, EventArgs e)
        {

        }

        private void Window_Load(object sender, EventArgs e)
        {

        }
    }
}
