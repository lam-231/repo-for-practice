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
        const int Radius = 15; 
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsSelected {  get; set; }
        public int Number {  get;}
        protected Graphics G { get; set; }
        public Vertex(int x, int y, int number, Graphics g) 
        {
            X = x;
            Y = y;
            Number = number;
            G = g;
            IsSelected = false;
        }
        public Vertex() { }
        public bool isPointOnVertex(int tryX, int tryY) 
        {
            return Math.Pow(X - tryX, 2) + Math.Pow(Y - tryY, 2) <= Math.Pow(Radius, 2);
        }

        public bool isOverlapingWithVertexInPoint(int tryX, int tryY) 
        {
            return Math.Sqrt(Math.Pow(X - tryX, 2) + Math.Pow(Y - tryY, 2)) <= 2 * Radius + 1;
        } 
        
        public void draw()
        {
            G.FillEllipse(Brushes.DimGray, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            Color color = IsSelected ? Color.Orange: Color.DarkGray;
            Pen pen = new Pen(color, 3);

            G.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            string text = Number.ToString();

            Font font = new Font("Arial", 12);
            SizeF textSize = G.MeasureString(text, font);
            float x = X + 1 - textSize.Width / 2;
            float y = Y + 1 - textSize.Height / 2;

            G.DrawString(text, font, Brushes.White, x, y);
        }



    }
}
