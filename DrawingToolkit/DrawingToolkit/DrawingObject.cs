using System;
using System.Drawing;
using System.Windows.Forms;
using DrawingToolkit.State;
using DrawingToolkit.Shape;
using System.Linq;
using System.Collections.Generic;

namespace DrawingToolkit
{
    public abstract class DrawingObject : IObservable
    {
        public Guid guid { get; set; }
        public Graphics graphics { get; set; }

        List<IObserver> observers = new List<IObserver>();

        public DrawingState drawingState
        {
            get
            {
                return this.state;
            }
        }

        protected DrawingState state;

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

        public virtual void ChangeState (DrawingState state)
        {
            this.state = state;
        }

        public virtual void Draw()
        {
            this.state.Draw(this);
            Notify();
        }

        public virtual void Selected()
        {
            this.state.Selected(this);
        }

        public virtual void Deselected()
        {
            this.state.Deselected(this);
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update();     
            }
        }

        public abstract Point GetCenterPoint();
    }
}