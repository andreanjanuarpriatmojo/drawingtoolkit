using DrawingToolkit.Tools;
using System.Diagnostics;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public partial class DrawingForm : Form
    {
        private Toolbox toolbox;
        private DrawingCanvas canvas;

        public DrawingForm()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            Debug.WriteLine("Initializing UI Objects.");

            #region Canvas

            Debug.WriteLine("Loading canvas....");
            this.canvas = new Canvas();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.canvas);

            #endregion

            #region Toolbox

            Debug.WriteLine("Loading toolbox....");
            this.toolbox = new Toolboxes();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);

            #endregion

            #region Tools

            Debug.WriteLine("Loading tools....");
            this.toolbox.AddTool(new LineTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;

            #endregion
        }

        private void Toolbox_ToolSelected(Tool tool)
        {
            if (this.canvas != null)
            {
                this.canvas.SetActiveTool(tool);
                tool.TargetCanvas = this.canvas;
            }
        }
    }
}
