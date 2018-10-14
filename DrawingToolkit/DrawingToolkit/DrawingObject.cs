using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public abstract class DrawingObject
    {
        public Guid guid { get; set; }
        public Graphics graphics { get; set; }

        public DrawingObject()
        {
            guid = Guid.NewGuid();
        }

        public abstract void Draw();
    }
}
