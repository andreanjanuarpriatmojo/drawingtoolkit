using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.State
{
    public class IdleState : DrawingState
    {
        private static DrawingState instance;

        public static DrawingState GetInstance()
        {
            if (instance == null)
            {
                instance = new IdleState();
            }
            return instance;
        }

        public override void Draw(DrawingObject drawingObject)
        {
            drawingObject.DrawIdle();
        }

        public override void Selected(DrawingObject drawingObject)
        {
            drawingObject.ChangeState(EditState.GetInstance());
        }
    }
}
