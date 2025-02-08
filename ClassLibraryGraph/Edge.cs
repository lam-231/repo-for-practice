using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClassLibraryGraph
{
    public class Edge : GraphElement
    {
        public Vertex FirstVertex { get; set; }
        public Vertex SecondVertex { get; set; }
        public int Weight { get; private set; }
        [JsonIgnore]
        public Graphics GraphicsProp { get; set; }
        public Edge() { }
        public Edge(Vertex firstVertex, Vertex secondVertex, Graphics Graphics)
        {
            FirstVertex = firstVertex;
            SecondVertex = secondVertex;
            GraphicsProp = Graphics;
            Weight = CalculateWeight();
            IsSelected = false;
        }
        public void SetGraphics(Graphics graphics)
        {
            GraphicsProp = graphics;
        }
        private int CalculateWeight()
        {
            return (int)Math.Sqrt(Math.Pow(FirstVertex.X - SecondVertex.X, 2) + Math.Pow(FirstVertex.Y - SecondVertex.Y, 2));
        }
        public override void Draw()
        {
            Color color = IsSelected ? Color.Orange : Color.LightGray;
            Pen pen = new Pen(color, 5);
            GraphicsProp.DrawLine(pen, FirstVertex.X, FirstVertex.Y, SecondVertex.X, SecondVertex.Y);

            string text = CalculateWeight().ToString();

            Font font = new Font("Arial", 7);
            SizeF textSize = GraphicsProp.MeasureString(text, font);
            float x = (FirstVertex.X + SecondVertex.X) / 2 + 1 - textSize.Width / 2;
            float y = (FirstVertex.Y + SecondVertex.Y) / 2 + 1 - textSize.Height / 2;

            GraphicsProp.DrawString(text, font, Brushes.Black, x, y);
        }
        public bool IsPointOnEdge(int tryX, int tryY)
        {
            const int EdgeThreshold = 7;
            const int EdgeWidth = 5;
            const double SlopeThreshold = 0.15;

            int minX = Math.Min(FirstVertex.X, SecondVertex.X);
            int maxX = Math.Max(FirstVertex.X, SecondVertex.X);
            int minY = Math.Min(FirstVertex.Y, SecondVertex.Y);
            int maxY = Math.Max(FirstVertex.Y, SecondVertex.Y);

            if (Math.Abs(FirstVertex.Y - SecondVertex.Y) < EdgeThreshold) return tryX > minX && tryX < maxX && tryY > FirstVertex.Y - EdgeWidth && tryY < FirstVertex.Y + EdgeWidth;

            return tryX >= minX && tryX <= maxX &&
                   tryY >= minY && tryY <= maxY &&
                   Math.Abs((double)(tryY - FirstVertex.Y) / (SecondVertex.Y - FirstVertex.Y) - (double)(tryX - FirstVertex.X) / (SecondVertex.X - FirstVertex.X)) < SlopeThreshold;
        }
        public bool ContainsVertex(Vertex vertex)
        {
            return vertex == FirstVertex || vertex == SecondVertex;

        }
    }
}
