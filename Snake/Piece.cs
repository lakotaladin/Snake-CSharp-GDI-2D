using System.Drawing;

namespace Snake
{
    public class Piece
    {
        public static int SIDE = 25;
        public static int Size { get; } = 20;
        private readonly Image m_Texture; 

        public int X { get; set; }
        public int Y { get; set; }

        public Piece(int a, int b, Image texture) 
        {
            X = a;
            Y = b;
            m_Texture = texture; // tekstura za harnu
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(m_Texture, new Rectangle(X * SIDE, Y * SIDE, SIDE, SIDE)); // Koristim sliku kao teksturu za crtanje
        }
    }
}
