using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGraph
{
    public class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsActiveted {  get; set; }
        public Vertex(int x, int y, bool isIt) 
        {
            X = x;
            Y = y;
            IsActiveted = isIt;
        }
        public Vertex(int x, int y) 
        {
            X = x;
            Y = y;
            IsActiveted = false;
        }
        public void isVertexActivate(int tryX, int tryY) 
        {
            if (Math.Pow(X - tryX, 2) + Math.Pow(Y - tryY, 2) <= 900) IsActiveted = true;
            else IsActiveted = false;
        }

        public bool isOverlapingWithVertexinPoint(int tryX, int tryY) 
        {
            if(Math.Sqrt(Math.Pow(X - tryX, 2) + Math.Pow(Y - tryY, 2)) >= 31) return true;
            else return false;
        }
        public void draw()
        {

        }

    }
}
