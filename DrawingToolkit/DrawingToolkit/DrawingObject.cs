using System;
using System.Drawing;
using System.Windows.Forms;
using DrawingToolkit.State;

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