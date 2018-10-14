using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingToolkit.Shape;
using System.Diagnostics;

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
            Debug.WriteLine(this.Name + "is initialized.");
            Init();
        }

        public void Init()
        {
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

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawingCanvas.AddDrawingObject(this.circle);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = e.X - this.circle.cirX;
                int height = e.Y - this.circle.cirY;

                if (width > 0 && height > 0)
                {
                    this.circle.cirWidth = width;
                    this.circle.cirHeight = height;
                }
            }
        }
    }
}
