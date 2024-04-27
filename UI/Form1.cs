using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryGraph;
using static System.Windows.Forms.LinkLabel;

namespace UI
{
    public partial class Field : System.Windows.Forms.Form
    {
        private bool isVertexDrawingEnabled = false;
        private List<Vertex> vertices = new List<Vertex>();
        private int vertexCount = 0;

        public Field()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point click = e.Location;

            if (isVertexDrawingEnabled) drawVertex(click);

        }
        private void buttonDrawCheck_Click(object sender, EventArgs e)
        {
            isVertexDrawingEnabled = !isVertexDrawingEnabled;
            if (isVertexDrawingEnabled) buttonDrawCheck.Text = "Drawing Enabled";
            else buttonDrawCheck.Text = "Drawing Disabled";
        }
        private void drawVertex(Point point)
        {
            var vertex = new Vertex(point.X, point.Y);

            foreach (var vert in vertices)
            {
                if (!vert.isOverlapingWithVertexinPoint(point.X, point.Y)) return;
            }

            vertex.draw();

            Graphics g = pictureBox1.CreateGraphics();
            g.FillEllipse(Brushes.DimGray, point.X - 15, point.Y - 15, 30, 30);
            Pen pen = new Pen(Color.DarkGray, 3);
            g.DrawEllipse(pen, point.X - 15, point.Y - 15, 30, 30);

            vertices.Add(vertex);

            vertexCount++;
            string text = vertexCount.ToString();

            // Розташування тексту порядкового номера
            Font font = new Font("Arial", 12);
            SizeF textSize = g.MeasureString(text, font);
            float x = point.X + 1 - textSize.Width / 2;
            float y = point.Y + 1 - textSize.Height / 2;

            // Малювання порядкового номера біля вершини
            g.DrawString(text, font, Brushes.White, x, y);
        }

    }
}
