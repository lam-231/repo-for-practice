using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibraryGraph
{

    public class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsActiveted {  get; set; }
        public int Number {  get;}
        private Graphics G { get; set; }
        public Vertex(int x, int y, int number, Graphics g) 
        {
            X = x;
            Y = y;
            Number = number;
            G = g;
            IsActiveted = false;
        }
        public void isVertexActivate(int tryX, int tryY) 
        {
            if (Math.Pow(X - tryX, 2) + Math.Pow(Y - tryY, 2) <= 900) IsActiveted = true;
            else IsActiveted = false;
        }

        public bool isOverlapingWithVertexinPoint(int tryX, int tryY) 
        {
            if(Math.Sqrt(Math.Pow(X - tryX, 2) + Math.Pow(Y - tryY, 2)) >= 31) return true;
            else return false;
        }
        public void draw()
        {
            G.FillEllipse(Brushes.DimGray, X - 15, Y - 15, 30, 30);
            Pen pen = new Pen(Color.DarkGray, 3);
            G.DrawEllipse(pen, X - 15, Y - 15, 30, 30);

            string text = Number.ToString();

            Font font = new Font("Arial", 12);
            SizeF textSize = G.MeasureString(text, font);
            float x = X + 1 - textSize.Width / 2;
            float y = Y + 1 - textSize.Height / 2;

            G.DrawString(text, font, Brushes.White, x, y);
        }

    }
}
