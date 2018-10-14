using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingToolkit.Shape;

namespace DrawingToolkit.Tools
{
    public class LineTool : ToolStripButton, Tool
    {
        private DrawingCanvas canvas;
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
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }

        }

        public LineTool()
        {
            this.Name = "Line Tool";
            this.ToolTipText = "Line Tool";
            Debug.WriteLine(this.Name + "is initialized.");
            Init();
        }

        public void Init()
        {
            this.Image = IconSet.line;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            line = new Line(new System.Drawing.Point(e.X, e.Y));
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            line.finishPoint = new System.Drawing.Point(e.X, e.Y);
            canvas.AddDrawingObject(line);
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
