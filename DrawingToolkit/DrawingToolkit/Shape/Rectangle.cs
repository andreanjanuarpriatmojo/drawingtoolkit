using System.Drawing;

namespace DrawingToolkit.Shape
{
    public class Rectangle : DrawingObject
    {
        public int rectX { get; set; }
        public int rectY { get; set; }
        public int rectWidth { get; set; }
        public int rectHeight { get; set; }

        private Pen pen;

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

        public override void RenderIdle()
        {
            pen.Color = Color.Black;

            if (this.graphics != null)
            {
                this.graphics.DrawRectangle(pen, rectX, rectY, rectWidth, rectHeight);
            }
        }

        public override void RenderSelected()
        {
            pen.Color = Color.Blue;

            if (this.graphics != null)
            {
                this.graphics.DrawRectangle(pen, rectX, rectY, rectWidth, rectHeight);
            }
        }

        public override bool HitArea(int areaX, int areaY)
        {
            throw new System.NotImplementedException();
        }

    }
}
