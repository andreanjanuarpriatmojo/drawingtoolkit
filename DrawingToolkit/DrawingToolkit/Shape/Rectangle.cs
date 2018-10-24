using System.Drawing;
using System.Windows.Forms;

namespace DrawingToolkit.Shape
{
    public class Rectangle : DrawingObject
    {
        public int rectX { get; set; }
        public int rectY { get; set; }
        public int rectWidth { get; set; }
        public int rectHeight { get; set; }

        private Pen pen;
        private Point startPoint { get; set; }
        private Point finishPoint { get; set; }

        public Rectangle()
        {
            this.pen = new Pen(Color.Black);
        }

        public Rectangle(int initX, int initY) : this()
        {
            this.rectX = initX;
            this.rectY = initY;
        }

        public Rectangle(int initX, int initY, int initWidth, int initHeight) : this(initX, initY)
        {
            this.rectHeight = initHeight;
            this.rectWidth = initWidth;
        }

        public override void Draw()
        {
            this.graphics.DrawRectangle(pen, rectX, rectY, rectWidth, rectHeight);
        }

        public override bool Selected(Point point)
        {
            if ((point.X >= rectX && point.X <= rectX + rectWidth) && (point.Y >= rectY && point.Y <= rectY + rectHeight))
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
            rectX += x;
            rectY += y;
        }
    }
}