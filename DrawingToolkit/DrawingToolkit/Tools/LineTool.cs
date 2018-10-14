using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class LineTool : ToolStripButton, Tool
    {
        private DrawingCanvas canvas;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Cross;
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
            MessageBox.Show("Tool Line clicked", "Tool Line");
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
