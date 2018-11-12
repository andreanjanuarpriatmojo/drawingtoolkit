using System.Windows.Forms;
using System.Drawing;
using DrawingToolkit.Shape;
using DrawingToolkit.State;

namespace DrawingToolkit.Tools
{
    class ConnectorTool : ToolStripButton, Tool
    {
        private DrawingCanvas drawingCanvas;
        private Circle circle;

        Point point;

        Circle circleSource;
        Circle circleDestination;

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

        public ConnectorTool()
        {
            this.Name = "Connector Tool";
            this.ToolTipText = "Connector Tool";
            this.Image = IconSet.connector;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;

            if (e.Button == MouseButtons.Left && drawingCanvas != null)
            {
                drawingCanvas.DeselectAll();
               
                if(drawingCanvas.SelectObject(e.X, e.Y).GetType() == typeof(Circle))
                {
                    circleSource = (Circle)drawingCanvas.SelectObject(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && drawingCanvas != null)
            {
                if (circleSource != null)
                {
                    drawingCanvas.DeselectAll();

                    if (drawingCanvas.SelectObject(e.X, e.Y).GetType() == typeof(Circle))
                    {
                        circleDestination = (Circle)drawingCanvas.SelectObject(e.X, e.Y);

                        Connector connector = new Connector(circleSource, circleDestination);
                        circleSource.Attach(connector);
                        circleDestination.Attach(connector);

                        drawingCanvas.AddDrawingObject(connector);
                        connector.ChangeState(IdleState.GetInstance());
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
