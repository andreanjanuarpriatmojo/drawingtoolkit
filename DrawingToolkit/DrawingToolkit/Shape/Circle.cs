using System.Drawing;
using System.Drawing.Drawing2D;
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

        public override void DrawEdit()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.Solid;
            this.graphics.DrawEllipse(this.pen, cirX, cirY, cirWidth, cirHeight);
        }

        public override void DrawIdle()
        {
            pen.Color = Color.Black;
            pen.DashStyle = DashStyle.Solid;
            this.graphics.DrawEllipse(this.pen, cirX, cirY, cirWidth, cirHeight);
        }

        public override void DrawPreview()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.DashDotDot;
            this.graphics.DrawEllipse(this.pen, cirX, cirY, cirWidth, cirHeight);
        }

        public override bool HitArea(int x, int y)
        {
            if ((x >= cirX && x <= cirX + cirWidth) && (y >= cirY && y <= cirY + cirHeight))
            {
                return true;
            }
            return false;
        }

        public override void Move(int x, int y, int xMove, int yMove)
        {
            cirX += xMove;
            cirY += yMove;
        }
    }
}