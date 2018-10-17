using System;
using System.Drawing;
using DrawingToolkit.Status;

namespace DrawingToolkit
{
    public abstract class DrawingObject
    {
        public Guid guid { get; set; }
        public Graphics graphics { get; set; }

        public ObjectStatus objectStatus
        {
            get
            {
                return this.status;
            }
        }

        private ObjectStatus status;

        public DrawingObject()
        {
            guid = Guid.NewGuid();
            this.ChangeStatus(Idle.GetStatus());
        }

        public abstract bool HitArea(int areaX, int areaY);

        public abstract void RenderIdle();
        public abstract void RenderSelected();

        public void ChangeStatus(ObjectStatus status)
        {
            this.status = status;
        }

        public virtual void Draw()
        {
            this.status.Draw(this);
        }

        public void Select()
        {
            this.status.Select(this);
        }

        public void Deselect()
        {
            this.status.Deselect(this);
        }
    }
}
