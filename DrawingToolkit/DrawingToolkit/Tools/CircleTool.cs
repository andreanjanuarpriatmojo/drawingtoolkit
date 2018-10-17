using System.Windows.Forms;
using DrawingToolkit.Shape;

namespace DrawingToolkit.Tools
{
    public class CircleTool : ToolStripButton, Tool
    {
        private DrawingCanvas drawingCanvas;
        private Circle circle;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public DrawingCanvas TargetCanvas
        {
            get
            {
                return this.drawingCanvas;
            }

            set
            {
                this.drawingCanvas = value;
            }

        }

        public CircleTool()
        {
            this.Name = "Circle Tool";
            this.ToolTipText = "Circle Tool";
            this.Image = IconSet.circle;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.circle = new Circle(e.X, e.Y);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = 0;
                int height = 0;

                if (e.X > this.circle.cirX)
                {
                    width = e.X - this.circle.cirX;
                    height = e.Y - this.circle.cirY;
                }
                else
                {
                    width = this.circle.cirX - e.X;
                    height = this.circle.cirY - e.Y;
                }

                if (width > 0 && height > 0)
                {
                    this.circle.cirWidth = width;
                    this.circle.cirHeight = height;
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X <= this.circle.cirX)
                {
                    this.circle.cirX = e.X;
                    this.circle.cirY = e.Y;
                }
                drawingCanvas.AddDrawingObject(this.circle);
            }
        }
    }
}