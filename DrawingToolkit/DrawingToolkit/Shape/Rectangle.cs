using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit.Shape
{
    public class Rectangle : DrawingObject
    {
        public int posX { get; set; }
        public int posY { get; set; }
        public int rectWidth { get; set; }
        public int rectHeight { get; set; }

        private Pen pen;

        public Rectangle()
        {
            this.pen = new Pen(Color.Black);
        }

        public Rectangle(int initX, int initY) : this()
        {
            this.posX = initX;
            this.posY = initY;
        }

        public Rectangle(int initX, int initY, int initWidth, int initHeight) : this(initX, initY)
        {
            this.rectHeight = initHeight;
            this.rectWidth = initWidth;
        }

        public override void Draw()
        {
            this.graphics.DrawRectangle(pen, posX, posY, rectWidth, rectHeight);
        }
    }
}
