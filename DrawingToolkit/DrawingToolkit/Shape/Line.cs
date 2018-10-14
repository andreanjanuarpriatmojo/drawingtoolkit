using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingToolkit.Shape
{
    public class Line : DrawingObject
    {
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
    }
}
