using System.Drawing;
using System.Windows.Forms;

namespace DrawingToolkit.Shape
{
    public class Circle : DrawingObject
    {
        public int cirX { get; set; }
        public int cirY { get; set; }
        public int cirWidth { get; set; }
        public int cirHeight { get; set; }

        private Pen pen;
        private Point startPoint { get; set; }
        private Point finishPoint { get; set; }

        public Circle()
        {
            this.pen = new Pen(Color.Black);
        }

        public Circle(int initX, int initY) : this()
        {
            this.cirX = initX;
            this.cirY = initY;
        }

        public Circle(int initX, int initY, int initWidth, int initHeight) : this(initX, initY)
        {
            this.cirWidth = initWidth;
            this.cirHeight = initHeight;
        }

        public override void Draw()
        {
            this.graphics.DrawEllipse(pen, cirX, cirY, cirWidth, cirHeight);
        }

        public override bool Selected(Point point)
        {
            if ((point.X >= cirX && point.X <= cirX + cirWidth) && (point.Y >= cirY && point.Y <= cirY + cirHeight))
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