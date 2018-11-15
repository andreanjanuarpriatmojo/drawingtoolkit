using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    class DrawingGroup : DrawingObject
    {
        private List<DrawingObject> drawingGroups = new List<DrawingObject>();

        public void AddComposite(DrawingObject drawingObject)
        {
            this.drawingGroups.Add(drawingObject);
        }

        public void RemoveComposite(DrawingObject drawingObject)
        {
            this.drawingGroups.Remove(drawingObject);
        }

        public override void ChangeState(DrawingState state)
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.ChangeState(state);
            }
            this.state = state;
        }

        public override void DrawEdit()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.DrawEdit();
            }
        }

        public override void DrawIdle()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.DrawIdle();
            }
        }

        public override void DrawPreview()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.DrawPreview();
            }
        }

        public override bool HitArea(int x, int y)
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                if (drawingObject.HitArea(x, y))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Move(MouseEventArgs e, int x, int y)
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.Move(e, x, y);
            }
        }

        public override void Selected()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.Selected();
            }
        }

        public override void Deselected()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.Deselected();
            }
        }

        public override void Draw()
        {
            
        }

        public override Point GetCenterPoint()
        {
            throw new NotImplementedException();
        }
    }
}
