using System.Drawing;

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

        public override void RenderIdle()
        {
            pen.Color = Color.Black;

            if (this.graphics != null)
            {
                this.graphics.DrawEllipse(pen, cirX, cirY, cirWidth, cirHeight);
            }
        }

        public override void RenderSelected()
        {
            pen.Color = Color.Blue;

            if (this.graphics != null)
            {
                this.graphics.DrawEllipse(pen, cirX, cirY, cirWidth, cirHeight);
            }
        }

        public override bool HitArea(int areaX, int areaY)
        {
            throw new System.NotImplementedException();
        }
    }
}
