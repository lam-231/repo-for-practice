using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGraph
{
    public class Graph
    {
        public static List<Edge> Dijkstra(Vertex startVertex, Vertex endVertex, List<Vertex> vertices, List<Edge> edges)
        {
            var distances = new Dictionary<Vertex, int>();
            var previous = new Dictionary<Vertex, Vertex>();
            var unvisited = new List<Vertex>(vertices);

            foreach (var vertex in vertices)
            {
                distances[vertex] = int.MaxValue;
                previous[vertex] = null;
            }
            distances[startVertex] = 0;

            while (unvisited.Count != 0)
            {
                unvisited.Sort((v1, v2) => distances[v1].CompareTo(distances[v2]));
                var currentVertex = unvisited[0];
                unvisited.Remove(currentVertex);

                if (currentVertex == endVertex)
                {
                    var path = new List<Edge>();
                    while (previous[currentVertex] != null)
                    {
                        var prevVertex = previous[currentVertex];
                        Edge edge = null;

                        foreach (var e in edges)
                        {
                            if ((e.FirstVertex == currentVertex && e.SecondVertex == prevVertex) ||
                                (e.FirstVertex == prevVertex && e.SecondVertex == currentVertex))
                            {
                                edge = e;
                                break;
                            }
                        }

                        if (edge != null)
                        {
                            path.Insert(0, edge);
                        }
                        currentVertex = prevVertex;
                    }
                    return path;
                }

                foreach (var edge in edges)
                {
                    if (!edge.ContainsVertex(currentVertex)) continue;

                    var neighbor = (edge.FirstVertex == currentVertex) ? edge.SecondVertex : edge.FirstVertex;
                    var newDist = distances[currentVertex] + edge.CalculateWeight();
                    if (newDist < distances[neighbor])
                    {
                        distances[neighbor] = (int)newDist;
                        previous[neighbor] = currentVertex;
                    }

                }
            }

            return null;
        }
    }
}
