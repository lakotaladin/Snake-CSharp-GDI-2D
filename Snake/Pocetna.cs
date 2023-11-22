using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Pocetna : Form
    {
        public Pocetna()
        {
            InitializeComponent();
        }

        private void Pocetna_Load(object sender, EventArgs e)
        {

        }

        private void Pocetna_Paint(object sender, PaintEventArgs e)
        {


            Graphics g = e.Graphics;
            Font fnt = new Font("Times New Roman", 12);

            GraphicsPath path = new GraphicsPath();
            Pen penJoin = new Pen(Color.Black, 2);
            
            path.StartFigure();
            path.AddLine(new Point(10, 10), new Point(130, 10));
            path.AddLine(new Point(10, 10), new Point(10, 160));
            path.AddLine(new Point(10, 160), new Point(130, 160));
            path.AddLine(new Point(130, 10), new Point(130, 160));
            
            penJoin.LineJoin = LineJoin.Bevel;

            /* Dodavanje slike */
            Bitmap bmp = new Bitmap(Properties.Resources.slika);

            /* Prva vrsta slika */

            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);

            /* Translacija za drugi red, -720 sam stavio da bi cela druga vrsta bila ispod prve vrste */
            g.TranslateTransform(-720, 150);
            g.DrawPath(penJoin, path);
            
            /* Druga vrsta slika */


            /* Slika 1 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            /* Slika 2 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            /* Slika 3 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            /* Slika 4 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            /* Slika 5 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            /* Slika 6 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);


            /* Treca vrsta slika */
            g.TranslateTransform(-720, 150);
            g.DrawPath(penJoin, path);


            /* Slika 1 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            /* Slika 2 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            /* Slika 3 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            /* Slika 4 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            /* Slika 5 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);
            /* Slika 6 */
            g.DrawImage(bmp, 10, 10, 120, 150);
            g.DrawPath(penJoin, path);
            g.TranslateTransform(120, 0);

        }

        private void Pocetna_Click(object sender, EventArgs e)
        {

        }

        private void Po(object sender, EventArgs e)
        {
            // Prikazuje drugi prozor
            Window window = new Window();
            window.Show();

            // Sakriva trenutni prozor
            this.Hide();
        }



    }
}
