using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DrawingToolkit.Shape
{
    public class Line : DrawingObject
    {
        private const double EPSILON = 3.0;
        public Point startPoint { get; set; }
        public Point finishPoint { get; set; }
        private Pen pen;

        public Line()
        {
            this.pen = new Pen(Color.Black);
        }

        public Line(Point initX) : this()
        {
            this.startPoint = initX;
        }

        public Line(Point initX, Point initY) : this(initX)
        {
            this.finishPoint = initY;
        }

        public override void DrawEdit()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.Solid;
            this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
        }

        public override void DrawIdle()
        {
            pen.Color = Color.Black;
            pen.DashStyle = DashStyle.Solid;
            this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
        }

        public override void DrawPreview()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.DashDotDot;
            this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
        }

        public override bool HitArea(int x, int y)
        {
            double a = (double)(finishPoint.Y - startPoint.Y) / (double)(finishPoint.X - startPoint.X);
            double b = finishPoint.Y - a * finishPoint.X;
            double c = a * x + b;

            if (Math.Abs(y - c) < EPSILON)
            {
                return true;
            }
            return false;
        }

        public override void Move(MouseEventArgs e, int x, int y)
        {
            Point point = e.Location;
            this.startPoint = new Point(this.startPoint.X + x, this.startPoint.Y + y);
            this.finishPoint = new Point(this.finishPoint.X + x, this.finishPoint.Y + y);
        }
    }
}