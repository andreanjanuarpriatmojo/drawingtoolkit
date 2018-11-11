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

            this.KeyDown += Canvas_KeyDown;
            this.KeyUp += Canvas_KeyUp;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDown(sender, e);
                this.Repaint();
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseMove(sender, e);
                this.Repaint();
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseUp(sender, e);
                this.Repaint();
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

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolKeyDown(sender, e);
            }
        }

        private void Canvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolKeyUp(sender, e);
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
        }

        public DrawingObject GetObject(int x, int y)
        {
            foreach (DrawingObject dobject in drawingObjects)
            {
                if (dobject.HitArea(x,y))
                {
                    return dobject;
                }
            }
            return null;
        }

        public DrawingObject SelectObject(int x, int y)
        {
            DrawingObject dobject = GetObject(x, y);
            if (dobject != null)
            {
                dobject.Selected();
            }
            return dobject;
        }

        public void DeselectAll()
        {
            foreach (DrawingObject dobject in drawingObjects)
            {
                dobject.Deselected();
            }
        }
    }
}