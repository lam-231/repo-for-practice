using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGraph
{
    public abstract class GraphElement
    { 
        public bool IsSelected { get; set; }

        public abstract void Draw();
    }
}
