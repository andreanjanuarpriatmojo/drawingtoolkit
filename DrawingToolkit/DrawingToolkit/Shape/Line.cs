using System;
using System.Drawing;

namespace DrawingToolkit.Shape
{
    public class Line : DrawingObject
    {
        private const double EPSILON = 3.0;
        public Point startPoint { get; set; }
        public Point finishPoint { get; set; }
        public float lineWidth { get; set; }
        private Pen pen;
        
        public Line()
        {
            this.pen = new Pen(Color.Black, lineWidth);
        }

        public Line(Point initX) : this()
        {
            this.startPoint = initX;
        }

        public Line(Point initX, Point initY) : this(initX)
        {
            this.finishPoint = initY;
        }

        public override void RenderIdle()
        {
            pen.Color = Color.Black;
            
            if (this.graphics != null)
            {
                this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
            }
        }

        public override void RenderSelected()
        {
            pen.Color = Color.Blue;
            if (this.graphics != null)
            {
                this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
            }
        }

        public override bool HitArea(int areaX, int areaY)
        {
            double a = (double)(finishPoint.Y - startPoint.Y) / (double)(finishPoint.X - startPoint.X);
            double b = finishPoint.Y - a * finishPoint.X;
            double c = a * areaX + b;

            if (Math.Abs(areaY - c) < EPSILON)
            {
                return true;
            }
            return false;
        }
    }
}
