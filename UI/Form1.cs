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
        private Graphics graphics;
        public Field()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
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
            var vertex = new Vertex(point.X, point.Y, vertices.Count + 1, graphics);

            foreach (var vert in vertices)
            {
                if (!vert.isOverlapingWithVertexinPoint(point.X, point.Y)) return;
            }

            vertex.draw();

            vertices.Add(vertex);
        }

    }
}
