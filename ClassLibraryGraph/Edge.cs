﻿using System;
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
        public Vertex firstVertex { get; set; }
        public Vertex secondVertex { get; set; }

        public int weigth { get; set; }
        [JsonIgnore]
        public Graphics G { get; set; }
        public Edge() { }
        public void SetGraphics(Graphics graphics)
        {
            G = graphics;
        }
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
        public bool isPointOnEdge(int tryX, int tryY)
        {
            const int EdgeThreshold = 7;
            const int EdgeWidth = 5;
            const double SlopeThreshold = 0.15;

            int minX = Math.Min(firstVertex.X, secondVertex.X);
            int maxX = Math.Max(firstVertex.X, secondVertex.X);
            int minY = Math.Min(firstVertex.Y, secondVertex.Y);
            int maxY = Math.Max(firstVertex.Y, secondVertex.Y);

            if (Math.Abs(firstVertex.Y - secondVertex.Y) < EdgeThreshold) return tryX > minX && tryX < maxX && tryY > firstVertex.Y - EdgeWidth && tryY < firstVertex.Y + EdgeWidth;

            return tryX >= minX && tryX <= maxX &&
                   tryY >= minY && tryY <= maxY &&
                   Math.Abs((double)(tryY - firstVertex.Y)/(secondVertex.Y - firstVertex.Y) - (double)(tryX - firstVertex.X) / (secondVertex.X - firstVertex.X)) < SlopeThreshold;
        }

        public bool doesContainVertex(Vertex tryVertex)
        {
            if (tryVertex == firstVertex || tryVertex == secondVertex) return true;
            return false;
        }
    }
}
