using System.Windows.Forms;
using DrawingToolkit.Shape;
using System.Diagnostics;

namespace DrawingToolkit.Tools
{
    public class RectangleTool : ToolStripButton, Tool
    {
        private DrawingCanvas drawingCanvas;
        private Rectangle rectangle;

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

        public RectangleTool()
        {
            this.Name = "Rectangle Tool";
            this.ToolTipText = "Rectangle Tool";
            Debug.WriteLine(this.Name + "is initialized.");
            this.Image = IconSet.rect;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.rectangle = new Rectangle(e.X, e.Y);
                this.drawingCanvas.AddDrawingObject(this.rectangle);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = e.X - this.rectangle.rectX;
                int height = e.Y - this.rectangle.rectY;

                if (width > 0 && height > 0)
                {
                    this.rectangle.rectWidth = width;
                    this.rectangle.rectHeight = height;
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.rectangle.Selected();
            }
        }
    }
}