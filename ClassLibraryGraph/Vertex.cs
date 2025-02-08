using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace ClassLibraryGraph 
{

    public class Vertex : GraphElement
    {
        private const int Radius = 15;

        public int X { get; set; }
        public int Y { get; set; }
        public int Number { get; set; }

        [JsonIgnore]
        public Graphics GraphicsProp { get; private set; }

        public Vertex(int x, int y, int number, Graphics graphics)
        {
            X = x;
            Y = y;
            Number = number;
            GraphicsProp = graphics;
            IsSelected = false;
        }
        public Vertex() { }
        public void SetGraphics(Graphics graphics) 
        {
            GraphicsProp = graphics;
        }
        public bool IsPointOnVertex(int x, int y)
        {
            return Math.Pow(X - x, 2) + Math.Pow(Y - y, 2) <= Math.Pow(Radius, 2);
        }

        public bool isOverlapingWithVertexInPoint(int tryX, int tryY) 
        {
            return Math.Sqrt(Math.Pow(X - tryX, 2) + Math.Pow(Y - tryY, 2)) <= 2 * Radius + 1;
        } 
        
        public override void Draw()
        {
            GraphicsProp.FillEllipse(Brushes.DimGray, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            Color color = IsSelected ? Color.Orange: Color.DarkGray;
            Pen pen = new Pen(color, 3);

            GraphicsProp.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            string text = Number.ToString();

            Font font = new Font("Arial", 12);
            SizeF textSize = GraphicsProp.MeasureString(text, font);
            float x = X + 1 - textSize.Width / 2;
            float y = Y + 1 - textSize.Height / 2;

            GraphicsProp.DrawString(text, font, Brushes.White, x, y);
        }
    }
}
