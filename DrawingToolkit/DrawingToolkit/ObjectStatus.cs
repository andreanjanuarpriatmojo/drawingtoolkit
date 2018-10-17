using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public abstract class ObjectStatus
    {
        public ObjectStatus objectStatus
        {
            get
            {
                return this.status;
            }
        }

        private ObjectStatus status;

        public abstract void Draw(DrawingObject drawingObject);

        public virtual void Select(DrawingObject drawingObject)
        {

        }

        public virtual void Deselect(DrawingObject drawingObject)
        {

        }
    }
}
