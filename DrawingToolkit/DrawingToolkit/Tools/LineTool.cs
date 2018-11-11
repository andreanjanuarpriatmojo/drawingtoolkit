using System.Windows.Forms;
using System.Drawing;
using DrawingToolkit.Shape;

namespace DrawingToolkit.Tools
{
    public class LineTool : ToolStripButton, Tool
    {
        private DrawingCanvas drawingCanvas;
        private Line line;

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

        public LineTool()
        {
            this.Name = "Line Tool";
            this.ToolTipText = "Line Tool";
            this.Image = IconSet.line;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                line = new Line(new Point(e.X, e.Y));
                line.finishPoint = new Point(e.X, e.Y);
                drawingCanvas.AddDrawingObject(line);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                line.finishPoint = new Point(e.X, e.Y);
            }

        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                line.finishPoint = new Point(e.X, e.Y);
                line.Selected();
            }
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}