using System.Collections.Generic;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class SelectTool : ToolStripButton, Tool
    {
        private DrawingCanvas drawingCanvas;

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

        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}