using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace DrawingToolkit.Tools
{
    public class SelectTool : ToolStripButton, Tool
    {
        private DrawingCanvas drawingCanvas;
        private Point point;
        private DrawingObject currentObject;

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
            List<DrawingObject> temp = this.drawingCanvas.GetObject();
            foreach (DrawingObject dobject in temp)
            {
               
                    if (dobject.Selected(e.Location))
                    {
                        point = e.Location;
                        currentObject = dobject;
                        this.drawingCanvas.Repaint();
                    }
                    else
                    {
                        dobject.Idle();
                        this.drawingCanvas.Repaint();
                    }
                
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int xMove = e.X - point.X;
                int yMove = e.Y - point.Y;
                point = e.Location;
                currentObject.Move(e, xMove, yMove);
                this.drawingCanvas.Repaint();
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}