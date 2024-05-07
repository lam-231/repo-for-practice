using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGraph
{
    public class Edge 
    {
        private Vertex firstVertex { get; set; }
        private Vertex secondVertex { get; set; }
        private Graphics G {  get; set; }
        public bool isSelected {  get; set; }
        public Edge(Vertex firstVertex, Vertex secondVertex, Graphics G)
        {
            this.firstVertex = firstVertex;
            this.secondVertex = secondVertex;
            this.G = G;
            isSelected = false;
        }
        public float getEdgeSize()
        {
            return (float)Math.Sqrt(Math.Pow(firstVertex.X - secondVertex.X, 2) + Math.Pow(firstVertex.Y - secondVertex.Y, 2));
        }
        public void draw()
        {
            Color color = isSelected ? Color.Orange : Color.LightGray;
            Pen pen = new Pen(color, 5);
            G.DrawLine(pen, firstVertex.X, firstVertex.Y, secondVertex.X, secondVertex.Y);

        }
    }
}
