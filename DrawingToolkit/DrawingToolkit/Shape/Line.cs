using System;
using System.Drawing;
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

        public override void Draw()
        {
            this.graphics.DrawLine(this.pen, startPoint, finishPoint);
        }

        public override bool Selected(Point point)
        {
            double a = (double)(finishPoint.Y - startPoint.Y) / (double)(finishPoint.X - startPoint.X);
            double b = finishPoint.Y - a * finishPoint.X;
            double c = a * point.X + b;

            if (Math.Abs(point.Y - c) < EPSILON)
            {
                pen.Color = Color.Blue;
                return true;
            }
            return false;
        }

        public override void Idle()
        {
            pen.Color = Color.Black;
        }

        public override void Move(MouseEventArgs e, int x, int y)
        {
            Point point = e.Location;
            startPoint = new Point((startPoint.X + x), (startPoint.Y + y));
            finishPoint = new Point((finishPoint.X + x), (finishPoint.Y + y));
        }
    }
}