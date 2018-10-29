using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public abstract class DrawingState
    {
        public DrawingState drawingState
        {
            get
            {
                return this.state;
            }
        }

        private DrawingState state;

        public abstract void Draw (DrawingObject drawingObject);
        public virtual void Selected (DrawingObject drawingObject)
        {

        }
        public virtual void Deselected (DrawingObject drawingObject)
        {

        }
    }
}
