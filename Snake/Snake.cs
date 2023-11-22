using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms; // Dodato za Windows.Forms.Timer

namespace Snake
{
    /* Komande na strelicama*/
    public enum Direction
    {
        Down,
        Up,
        Right,
        Left
    }

    public class Snake
    {
        public int HeadX => m_Pieces.Last().X;
        public int HeadY => m_Pieces.Last().Y;
        public int ScoreLength => m_Pieces.Count - 2;
        public Direction Direction { get; set; }

        private readonly Queue<Piece> m_Pieces;
        private readonly Image m_Texture;
        private readonly Timer m_Timer; // Promenjeno u System.Windows.Forms.Timer
        private readonly int m_Speed = 50;

        public Snake(Image texture)
        {
            m_Texture = texture;
            m_Pieces = new Queue<Piece>();
            m_Timer = new Timer(); // Promenjeno u System.Windows.Forms.Timer
            m_Timer.Interval = m_Speed;
            m_Timer.Tick += Move;
        }

        public void Start()
        {
            Clear();
            m_Timer.Start();
        }

        public void Stop()
        {
            m_Timer.Stop();
        }

        public void Draw(Graphics g)
        {
            foreach (var piece in m_Pieces)
            {
                g.DrawImage(m_Texture, new Rectangle(piece.X * Piece.SIDE, piece.Y * Piece.SIDE, Piece.SIDE, Piece.SIDE));
            }
        }

        public bool CanEat(int a, int b, Piece food)
        {
            return food.X == HeadX + a && food.Y == HeadY + b;
        }

        public bool EatsItself()
        {
            var i = 0;
            return m_Pieces.Any(piece => i++ != m_Pieces.Count - 1 && HeadY == piece.Y && HeadX == piece.X);
        }

        public bool Contains(int a, int b)
        {
            return m_Pieces.Any(piece => piece.X == a && piece.Y == b);
        }

        public void Eat(Piece food)
        {
            m_Pieces.Enqueue(new Piece(food.X, food.Y, m_Texture));
        }

        public void Clear()
        {
            m_Pieces.Clear();
            m_Pieces.Enqueue(new Piece(0, 0, m_Texture));
            m_Pieces.Enqueue(new Piece(0, 1, m_Texture));
            Direction = Direction.Down;
        }

        private void Move(object sender, EventArgs e)
        {
            MoveTo(Direction == Direction.Left ? -1 : Direction == Direction.Right ? 1 : 0,
                   Direction == Direction.Up ? -1 : Direction == Direction.Down ? 1 : 0);
        }

        public void MoveTo(int a, int b)
        {
            m_Pieces.Enqueue(new Piece(HeadX + a, HeadY + b, m_Texture));
            m_Pieces.Dequeue();
        }
    }
}
