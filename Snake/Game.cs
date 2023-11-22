using System;
using System.Collections.Generic;
using System.Drawing;

namespace Snake
{
    public class Game
    {
        private readonly int m_Width;
        private readonly int m_Height;
        private readonly Snake m_Snake;
        private readonly List<Piece> m_Foods;
        private readonly Random m_Rnd;

        private int m_MaxFoods = 3; // Maksimalan broj hrane na ekranu

        public Game(int width, int height)
        {
            m_Width = width;
            m_Height = height;
            // Tekstura zmije
            m_Snake = new Snake(Properties.Resources.snake_texture);
            m_Rnd = new Random();
            // Inicijalizacija liste hrane
            m_Foods = new List<Piece>();
            // Dodavanje početnih komada hrane
            for (int i = 0; i < m_MaxFoods; i++)
            {
                GenerateFood();
            }
            Restart();
        }

        public void Restart()
        {
            m_Snake.Clear();
            m_Foods.Clear();
            // Dodavanje početnih komada hrane
            for (int i = 0; i < m_MaxFoods; i++)
            {
                GenerateFood();
            }
        }

        public void Draw(Graphics g)
        {
            m_Snake.Draw(g);
            foreach (var food in m_Foods)
            {
                food.Draw(g);
            }
        }

        public int GetScore()
        {
            return m_Snake.ScoreLength;
        }

        public bool SnakeHasGrown()
        {
            switch (m_Snake.Direction)
            {
                case Direction.Down:
                    return TryEat(0, 1);
                case Direction.Up:
                    return TryEat(0, -1);
                case Direction.Right:
                    return TryEat(1, 0);
                case Direction.Left:
                    return TryEat(-1, 0);
            }
            return false;
        }

        public bool Lost()
        {
            return m_Snake.HeadX > m_Width || m_Snake.HeadX < 0 || m_Snake.HeadY > m_Height || m_Snake.HeadY < 0 || m_Snake.EatsItself();
        }

        public void ChangeSnakeDIrection(Direction direction)
        {
            m_Snake.Direction = direction;
        }

        private bool TryEat(int a, int b)
        {
            bool hasEaten = false;
            foreach (var food in m_Foods.ToArray()) // Koristimo ToArray da bismo sprečili izuzetak prilikom brisanja iz liste
            {
                if (m_Snake.CanEat(a, b, food))
                {
                    m_Snake.Eat(food);
                    m_Foods.Remove(food);
                    GenerateFood();
                    hasEaten = true;
                    break;
                }
            }

            if (!hasEaten)
            {
                m_Snake.MoveTo(a, b);
            }

            return hasEaten;
        }

        private void GenerateFood()
        {
            if (m_Foods.Count < m_MaxFoods)
            {
                var a = m_Rnd.Next(0, m_Width);
                var b = m_Rnd.Next(0, m_Height);
                if (m_Snake.Contains(a, b))
                {
                    GenerateFood();
                }
                else
                {
                    // Dobijamo resurs za određenu sliku hrane
                    int randomTextureIndex = m_Rnd.Next(1, 3); // Slučajan broj između 1 i 2
                    string textureName = $"food_texture{randomTextureIndex}";
                    Bitmap foodTexture = (Bitmap)Properties.Resources.ResourceManager.GetObject(textureName);

                    // Dodajemo novi komad hrane u listu
                    m_Foods.Add(new Piece(a, b, foodTexture));
                }
            }
        }
    }
}
