using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ClassLibraryGraph
{
    public class GraphStorage
    {
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public GraphStorage()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }
    }
}
