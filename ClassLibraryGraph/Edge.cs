using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGraph
{
    public class Edge : GraphElement
    {
        public Vertex firstVertex { get; set; }
        public Vertex secondVertex { get; set; }
        public int weigth { get; set; }
        private Graphics G { get; set; }
        public Edge() { }
        public Edge(Vertex firstVertex, Vertex secondVertex, Graphics G)
        {
            this.firstVertex = firstVertex;
            this.secondVertex = secondVertex;
            this.G = G;
            weigth = getEdgeSize();
            IsSelected = false;
        }
        public int getEdgeSize()
        {
            return (int)Math.Sqrt(Math.Pow(firstVertex.X - secondVertex.X, 2) + Math.Pow(firstVertex.Y - secondVertex.Y, 2));
        }
        public override void draw()
        {
            Color color = IsSelected ? Color.Orange : Color.LightGray;
            Pen pen = new Pen(color, 5);
            G.DrawLine(pen, firstVertex.X, firstVertex.Y, secondVertex.X, secondVertex.Y);

            string text = getEdgeSize().ToString();

            Font font = new Font("Arial", 7);
            SizeF textSize = G.MeasureString(text, font);
            float x = (firstVertex.X + secondVertex.X) / 2 + 1 - textSize.Width / 2;
            float y = (firstVertex.Y + secondVertex.Y) / 2 + 1 - textSize.Height / 2;

            G.DrawString(text, font, Brushes.Black, x, y);
        }

        public float getWeight()
        {
            return (float)Math.Sqrt(Math.Pow(secondVertex.X - firstVertex.X, 2) + Math.Pow(secondVertex.Y - firstVertex.Y, 2));
        }
        public bool isPointOnEdge(int tryX, int tryY)
        {
            int minX = Math.Min(firstVertex.X, secondVertex.X);
            int maxX = Math.Max(firstVertex.X, secondVertex.X);
            int minY = Math.Min(firstVertex.Y, secondVertex.Y);
            int maxY = Math.Max(firstVertex.Y, secondVertex.Y);

            if (Math.Abs(firstVertex.Y - secondVertex.Y) < 7) return tryX > minX && tryX < maxX && tryY > firstVertex.Y - 5 && tryY < firstVertex.Y + 5;

            return tryX >= minX && tryX <= maxX &&
                   tryY >= minY && tryY <= maxY &&
                   Math.Abs((double)(tryY - firstVertex.Y)/(secondVertex.Y - firstVertex.Y) - (double)(tryX - firstVertex.X) / (secondVertex.X - firstVertex.X)) < 0.15;
        }

        public bool doesContainVertex(Vertex tryVertex)
        {
            if (tryVertex == firstVertex || tryVertex == secondVertex) return true;
            return false;
        }

    }
}
