using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Status
{
    public class Selected : ObjectStatus
    {
        private static ObjectStatus status;

        public static ObjectStatus GetStatus()
        {
            if (status == null)
            {
                status = new Idle();
            }
            return status;
        }

        public override void Draw(DrawingObject drawingObject)
        {
            drawingObject.RenderSelected();
        }

        public override void Select(DrawingObject drawingObject)
        {
            drawingObject.ChangeStatus(Idle.GetStatus());
        }
    }
}
