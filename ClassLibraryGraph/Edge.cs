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
    public class Edge
    {
        private Vertex firstVertex { get; set; }
        private Vertex secondVertex { get; set; }
        private Graphics G { get; set; }
        public bool IsSelected { get; set; }
        public Edge() { }
        public Edge(Vertex firstVertex, Vertex secondVertex, Graphics G)
        {
            this.firstVertex = firstVertex;
            this.secondVertex = secondVertex;
            this.G = G;
            IsSelected = false;
        }
        public float getEdgeSize()
        {
            return (float)Math.Sqrt(Math.Pow(firstVertex.X - secondVertex.X, 2) + Math.Pow(firstVertex.Y - secondVertex.Y, 2));
        }
        public void draw()
        {
            Color color = IsSelected ? Color.Orange : Color.LightGray;
            Pen pen = new Pen(color, 5);
            G.DrawLine(pen, firstVertex.X, firstVertex.Y, secondVertex.X, secondVertex.Y);

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
