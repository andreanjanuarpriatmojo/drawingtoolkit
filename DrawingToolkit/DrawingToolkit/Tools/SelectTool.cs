using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace DrawingToolkit.Tools
{
    public class SelectTool : ToolStripButton, Tool
    {
        private DrawingCanvas drawingCanvas;
        private DrawingObject currentObject;

        private int x;
        private int y;

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

        public SelectTool()
        {
            this.Name = "Select Tool";
            this.ToolTipText = "Select Tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.x = e.X;
            this.y = e.Y;

            if (e.Button == MouseButtons.Left)
            {
                drawingCanvas.DeselectAll();
                currentObject = drawingCanvas.SelectObject(e.X, e.Y);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int xMove = e.X - x;
                int yMove = e.Y - y;
                x = e.X;
                y = e.Y;
                currentObject.Move(e.X, e.Y, xMove, yMove);
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}