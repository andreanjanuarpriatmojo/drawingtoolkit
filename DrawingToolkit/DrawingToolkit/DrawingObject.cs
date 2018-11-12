using System;
using System.Drawing;
using System.Windows.Forms;
using DrawingToolkit.State;
using System.Linq;
using System.Collections.Generic;

namespace DrawingToolkit
{
    public abstract class DrawingObject
    {
        public Guid guid { get; set; }
        public Graphics graphics { get; set; }

        public DrawingState drawingState
        {
            get
            {
                return this.state;
            }
        }

        private DrawingState state;

        public DrawingObject()
        {
            guid = Guid.NewGuid();
            this.ChangeState(PreviewState.GetInstance());
        }

        public abstract bool HitArea(int x, int y);
        public abstract void Move(MouseEventArgs e, int x, int y);

        public abstract void DrawPreview();
        public abstract void DrawEdit();
        public abstract void DrawIdle();

        //public void Add(DrawingObject drawingObject)
        //{
        //    this.drawingGroup.Add(drawingObject);
        //}
        //public void Remove(DrawingObject drawingObject)
        //{
        //    this.drawingGroup.Remove(drawingObject);
        //}

        public void ChangeState (DrawingState state)
        {
            this.state = state;
        }

        public virtual void Draw()
        {
            this.state.Draw(this);
        }

        public void Selected()
        {
            this.state.Selected(this);
        }

        public void Deselected()
        {
            this.state.Deselected(this);
        }

    }
}