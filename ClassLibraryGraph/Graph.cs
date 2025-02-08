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
            var distances = InitializeDistances(vertices, startVertex);
            var previous = InitializePrevious(vertices);
            var unvisited = new HashSet<Vertex>(vertices);

            while (unvisited.Count != 0)
            {
                var currentVertex = GetVertexWithSmallestDistance(unvisited, distances);
                unvisited.Remove(currentVertex);

                if (currentVertex == endVertex)
                {
                    return BuildPath(previous, currentVertex, edges);
                }

                UpdateDistancesAndPrevious(currentVertex, edges, distances, previous, unvisited);
            }

            return null;
        }

        private static Dictionary<Vertex, int> InitializeDistances(List<Vertex> vertices, Vertex startVertex)
        {
            var distances = new Dictionary<Vertex, int>();
            foreach (var vertex in vertices)
            {
                distances[vertex] = int.MaxValue;
            }
            distances[startVertex] = 0;
            return distances;
        }

        private static Dictionary<Vertex, Vertex> InitializePrevious(List<Vertex> vertices)
        {
            var previous = new Dictionary<Vertex, Vertex>();
            foreach (var vertex in vertices)
            {
                previous[vertex] = null;
            }
            return previous;
        }

        private static Vertex GetVertexWithSmallestDistance(HashSet<Vertex> unvisited, Dictionary<Vertex, int> distances)
        {
            Vertex smallestDistanceVertex = null;
            int smallestDistance = int.MaxValue;

            foreach (var vertex in unvisited)
            {
                if (distances[vertex] < smallestDistance)
                {
                    smallestDistance = distances[vertex];
                    smallestDistanceVertex = vertex;
                }
            }

            return smallestDistanceVertex;
        }

        private static void UpdateDistancesAndPrevious(Vertex currentVertex, List<Edge> edges, Dictionary<Vertex, int> distances, Dictionary<Vertex, Vertex> previous, HashSet<Vertex> unvisited)
        {
            foreach (var edge in edges)
            {
                if (!edge.ContainsVertex(currentVertex)) continue;

                var neighbor = edge.GetNeighbor(currentVertex);
                var newDist = distances[currentVertex] + edge.Weight;

                if (newDist < distances[neighbor])
                {
                    distances[neighbor] = newDist;
                    previous[neighbor] = currentVertex;
                }
            }
        }

        private static List<Edge> BuildPath(Dictionary<Vertex, Vertex> previous, Vertex currentVertex, List<Edge> edges)
        {
            var path = new List<Edge>();

            while (previous[currentVertex] != null)
            {
                var prevVertex = previous[currentVertex];
                var edge = edges.Find(e => (e.FirstVertex == currentVertex && e.SecondVertex == prevVertex) || (e.FirstVertex == prevVertex && e.SecondVertex == currentVertex));

                if (edge != null)
                {
                    path.Insert(0, edge);
                }

                currentVertex = prevVertex;
            }

            return path;
        }
    }
}
