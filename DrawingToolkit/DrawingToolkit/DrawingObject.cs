using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public abstract class DrawingObject
    {
        public Guid guid { get; set; }
        public Graphics graphics { get; set; }

        public DrawingObject()
        {
            guid = Guid.NewGuid();
        }

        public abstract void Draw();

        public abstract Boolean Selected(Point point);
        public abstract void Idle();
        public abstract void Move(MouseEventArgs e, int x, int y);

    }
}