using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ClassLibraryGraph;
using Newtonsoft.Json;
using static System.Windows.Forms.LinkLabel;

namespace UI
{
    enum Mode
    {
        AddVertex,
        MoveVertex,
        AddEdge,
        ShortestWay,
        Select
    }
    public partial class Field : System.Windows.Forms.Form
    {
        private Mode mode = Mode.Select;
        private List<Vertex> vertices = new List<Vertex>();
        private List<Edge> edges = new List<Edge>();
        private Graphics graphics;
        private bool isCtrlPressed = false;
        private int lastAddedVertNumber = 0;
        private Vertex movingVertex = null;
        private Vertex selectedStartVertex = null;
        private Vertex selectedEndVertex = null;
        private GraphStorage graphStorage;
        public Field()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Field_KeyDown);
            this.KeyUp += new KeyEventHandler(Field_KeyUp);
            graphStorage = new GraphStorage();
        }
      
        private void render()
        {
            graphics.Clear(pictureBox1.BackColor);
            foreach (Edge e in edges) e.draw();
            foreach (Vertex v in vertices) v.draw();

            labelEdgeCount.Text = edges.Count.ToString();
        }
        private void isSelectedToFalse()
        {
            foreach (var edge in edges) edge.IsSelected = false;
            foreach (var vert  in vertices) vert.IsSelected = false;
        }
        private Vertex getVertexByPoint(Point point)
        {
            if(vertices == null) return null;

            foreach (Vertex v in vertices)
            {
                if (v.isPointOnVertex(point.X, point.Y)) return v;
            }
            return null;
        }
        private Edge getEdgeByPoint(Point point)
        {
            foreach (Edge e in edges)
            {
                if (e.isPointOnEdge(point.X, point.Y)) return e;
            }
            return null;
        }
        private void addVertex(Point point)
        {
            var vertex = new Vertex(point.X, point.Y, lastAddedVertNumber + 1, graphics);

            foreach (var vert in vertices)
            {
                if (vert.isOverlapingWithVertexInPoint(point.X, point.Y)) return;
            }

            lastAddedVertNumber++;
            vertices.Add(vertex);
        }
        private void addEdge(Point point)
        {
            Vertex firstVertex = null;

            foreach (var v in vertices)
                if (v.IsSelected)
                {
                    firstVertex = v;
                    break;
                }

            if (firstVertex == null)
            {
                firstVertex = getVertexByPoint(point);
                if (firstVertex != null) firstVertex.IsSelected = true;
                return;
            }
            
            Vertex secondVertex = getVertexByPoint(point);

            foreach (var e in edges) if (e.doesContainVertex(firstVertex) && e.doesContainVertex(secondVertex)) return;

            if (secondVertex == null || firstVertex == secondVertex) return;

            Edge edge = new Edge(firstVertex, secondVertex, graphics);
            edges.Add(edge);

            firstVertex.IsSelected = false;
            render();
        }
        private void selectElement(Point point, bool isSelectMultiple)
        {
            Edge exitingEdge = new Edge();

            var exitingVertex = getVertexByPoint(point);
            if (exitingVertex == null) exitingEdge = getEdgeByPoint(point);

            if (exitingVertex == null && exitingEdge == null)
            {
                foreach (var vert in vertices) vert.IsSelected = false;
                foreach (var edg in edges) edg.IsSelected = false;
                return;
            }

            if(!isSelectMultiple)
            {
                foreach (var vert in vertices) vert.IsSelected = false;
                foreach (var edg in edges) edg.IsSelected = false;
            }

            if (exitingVertex != null)
            {
                if (!exitingVertex.IsSelected) exitingVertex.IsSelected = true;
                else exitingVertex.IsSelected = false;
            }

            if (exitingEdge != null)
            { 
                if (!exitingEdge.IsSelected) exitingEdge.IsSelected = true;
                else exitingEdge.IsSelected = true;
            }
        }
        private void shortestWay(Point point)
        {
            var exitingVertex = getVertexByPoint(point);

            if (exitingVertex == null) return;

            if (selectedStartVertex == null)
            {
                selectedStartVertex = exitingVertex;
                selectedStartVertex.IsSelected = true;
            }
            else if (selectedEndVertex == null)
            {
                selectedEndVertex = exitingVertex;
                selectedEndVertex.IsSelected = true;
                var path = Graph.Dijkstra(selectedStartVertex, selectedEndVertex, vertices, edges);
                foreach (var edge in path) 
                {
                    edge.IsSelected = true;
                    edge.firstVertex.IsSelected = true;
                    edge.secondVertex.IsSelected = true;
                }
                render();
            }
            else
            {
                isSelectedToFalse();
                selectedStartVertex = exitingVertex;
                selectedStartVertex.IsSelected = true;
                selectedEndVertex = null;
            }
        }
        private void Field_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !isCtrlPressed) isCtrlPressed = true;
        }
        private void Field_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control && isCtrlPressed) isCtrlPressed = false;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = e.Location;

            if (mode == Mode.Select) selectElement(point, isCtrlPressed);

            if (mode == Mode.AddVertex) addVertex(point);
            
            if (mode == Mode.AddEdge) addEdge(point);

            if (mode == Mode.MoveVertex)
            {
                if(movingVertex != null) movingVertex = null;
                else movingVertex = getVertexByPoint(point);
            }

            if (mode == Mode.ShortestWay) shortestWay(point);

            render();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (mode == Mode.ShortestWay) return;
            
            List<Vertex> verticesToRemove = new List<Vertex>();
            List<Edge> edgesToRemove = new List<Edge>();

            foreach(var edg in edges)
            {
                if(!edg.IsSelected) continue;
                edgesToRemove.Add(edg);
            }

            foreach(var vert in vertices)
            {
                if (!vert.IsSelected) continue;
                verticesToRemove.Add(vert);
                foreach (var edge in edges)
                { 
                    if(edge.doesContainVertex(vert)) edgesToRemove.Add(edge);
                }
            }

            foreach (var vrt in verticesToRemove)  vertices.Remove(vrt);
            foreach (var edg in edgesToRemove) edges.Remove(edg);

            isSelectedToFalse();

            render();
        }
        private void buttonAddVertex_Click(object sender, EventArgs e)
        {
            mode = Mode.AddVertex;
            isSelectedToFalse();
            render();
        }
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            mode = Mode.Select;
            isSelectedToFalse();
            render();
        }
        private void buttonAddEdge_Click(object sender, EventArgs e)
        {
            mode = Mode.AddEdge;
            isSelectedToFalse();
            render();
        }
        private void buttonMoveVertex_Click(object sender, EventArgs e)
        {
            mode= Mode.MoveVertex;
            isSelectedToFalse();
            render();
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mode != Mode.MoveVertex || movingVertex == null) return;
            Point movePoint = e.Location;

            movingVertex.X = movePoint.X;
            movingVertex.Y = movePoint.Y;

            render();
        }
        private void buttonShortestWay_Click(object sender, EventArgs e)
        {
            mode = Mode.ShortestWay;
            selectedStartVertex = null;
            selectedEndVertex = null;

            isSelectedToFalse();
            render();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter file = File.CreateText(saveFileDialog.FileName))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(file, new { vertices, edges });
                }
            }
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader file = File.OpenText(openFileDialog.FileName))
                {
                    var serializer = new JsonSerializer();
                    var data = (GraphStorage)serializer.Deserialize(file, typeof(GraphStorage));
                    vertices = data.Vertices;
                    edges = data.Edges;

                    
                    foreach (var vertex in vertices)
                    {
                        vertex.G = graphics;
                    }

                    foreach (var edge in edges)
                    {
                        edge.G = graphics; 
                        edge.firstVertex = vertices.FirstOrDefault(v => v.Number == edge.firstVertex.Number); 
                        edge.secondVertex = vertices.FirstOrDefault(v => v.Number == edge.secondVertex.Number); 
                    }

                    if (vertices.Count > 0)
                    {
                        lastAddedVertNumber = vertices.Max(v => v.Number);
                    }
                    else
                    {
                        lastAddedVertNumber = 0;
                    }

                    isSelectedToFalse();
                    render(); 
                }
            }
        }
        private void Field_Load(object sender, EventArgs e)
        {
            labelEdge.Visible = false;
            labelEdgeCount.Visible = false;
        }
        private void Field_DoubleClick(object sender, EventArgs e)
        {
            labelEdge.Visible = labelEdge.Visible ? false : true;
            labelEdgeCount.Visible = labelEdgeCount.Visible ? false : true;
        }
    }
}
