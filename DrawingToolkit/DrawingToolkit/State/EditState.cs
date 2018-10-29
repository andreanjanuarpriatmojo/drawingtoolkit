using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.State
{
    public class EditState : DrawingState
    {
        private static DrawingState instance;

        public static DrawingState GetInstance()
        {
            if (instance == null)
            {
                instance = new EditState();
            }
            return instance;
        }

        public override void Draw(DrawingObject drawingObject)
        {
            drawingObject.DrawEdit();
        }

        public override void Deselected(DrawingObject drawingObject)
        {
            drawingObject.ChangeState(IdleState.GetInstance());
        }
    }
}
