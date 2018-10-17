using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace DrawingToolkit
{
    public class Canvas : Control, DrawingCanvas
    {
        private Tool activeTool;
        private List<DrawingObject> drawingObjects;

        public Canvas()
        {
            this.drawingObjects = new List<DrawingObject>();
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            this.Paint += Canvas_Paint;
            this.MouseDown += Canvas_MouseDown;
            this.MouseMove += Canvas_MouseMove;
            this.MouseUp += Canvas_MouseUp;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDown(sender, e);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseMove(sender, e);
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseUp(sender, e);
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (DrawingObject dobject in drawingObjects)
            {
                dobject.graphics = e.Graphics;
                dobject.Draw();
            }
        }

        public void Repaint()
        {
            this.Invalidate();
            this.Update();
        }

        public void SetActiveTool(Tool tool)
        {
            this.activeTool = tool;
        }

        public void SetBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        public void AddDrawingObject(DrawingObject drawingObject)
        {
            this.drawingObjects.Add(drawingObject);
            this.Repaint();
        }

        public void SelectObject(object sender, MouseEventArgs e)
        {
            int i = 0;
            foreach (DrawingObject dobject in drawingObjects)
            {
                if (dobject.Selected(e.Location))
                {
                    this.Refresh();
                }
                else
                {
                    dobject.Idle();
                    this.Refresh();
                }
                i++;
            }
        }

        public List<DrawingObject> GetObject()
        {
            return drawingObjects;
        }
    }
}