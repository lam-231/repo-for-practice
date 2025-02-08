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
        public int CalculateWeight()
        {
            return (int)Math.Sqrt(Math.Pow(FirstVertex.X - SecondVertex.X, 2) + Math.Pow(FirstVertex.Y - SecondVertex.Y, 2));
        }
        public override void Draw()
        {
            const int PenWidth = 5;
            const int EmSize = 7;

            var penColor = IsSelected ? Color.Orange : Color.LightGray;
            using (var pen = new Pen(penColor, PenWidth))
            {
                GraphicsProp.DrawLine(pen, FirstVertex.X, FirstVertex.Y, SecondVertex.X, SecondVertex.Y);
            }

            var text = Weight.ToString();
            var font = new Font("Arial", EmSize);
            var textSize = GraphicsProp.MeasureString(text, font);
            var x = (FirstVertex.X + SecondVertex.X) / 2 + 1 - textSize.Width / 2;
            var y = (FirstVertex.Y + SecondVertex.Y) / 2 + 1 - textSize.Height / 2;

            GraphicsProp.DrawString(text, font, Brushes.Black, x, y);
        }
        public bool IsPointOnEdge(int x, int y)
        {
            const int EdgeThreshold = 7;
            const int EdgeWidth = 5;
            const double SlopeThreshold = 0.15d;

            var minX = Math.Min(FirstVertex.X, SecondVertex.X);
            var maxX = Math.Max(FirstVertex.X, SecondVertex.X);
            var minY = Math.Min(FirstVertex.Y, SecondVertex.Y);
            var maxY = Math.Max(FirstVertex.Y, SecondVertex.Y);

            if (Math.Abs(FirstVertex.Y - SecondVertex.Y) < EdgeThreshold)
            {
                return x > minX && x < maxX && y > FirstVertex.Y - EdgeWidth && y < FirstVertex.Y + EdgeWidth;
            }

            return x >= minX && x <= maxX &&
                   y >= minY && y <= maxY &&
                   Math.Abs((double)(y - FirstVertex.Y) / (SecondVertex.Y - FirstVertex.Y) - (double)(x - FirstVertex.X) / (SecondVertex.X - FirstVertex.X)) < SlopeThreshold;
        }
        public bool ContainsVertex(Vertex vertex)
        {
            return vertex == FirstVertex || vertex == SecondVertex;

        }
    }
}