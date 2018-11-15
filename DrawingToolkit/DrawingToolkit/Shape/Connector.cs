using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DrawingToolkit.Shape;

namespace DrawingToolkit.Shape
{
    class Connector : DrawingObject, IObserver
    {
        private const double EPSILON = 3.0;
        public Point startPoint;
        public Point finishPoint;
        private Pen pen;

        public DrawingObject objectSource;
        public DrawingObject objectDestination;

        public Connector(DrawingObject objectSource, DrawingObject objectDestination)
        {
            this.pen = new Pen(Color.Black);
            this.objectSource = objectSource;
            this.objectDestination = objectDestination;
            Update();
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

        public override Point GetCenterPoint()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            this.startPoint = objectSource.GetCenterPoint();
            this.finishPoint = objectDestination.GetCenterPoint();
        }
    }
}
