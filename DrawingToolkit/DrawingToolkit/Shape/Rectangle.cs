﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

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

        public override void DrawEdit()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.Solid;
            this.graphics.DrawRectangle(this.pen, rectX, rectY, rectWidth, rectHeight);
        }

        public override void DrawIdle()
        {
            pen.Color = Color.Black;
            pen.DashStyle = DashStyle.Solid;
            this.graphics.DrawRectangle(this.pen, rectX, rectY, rectWidth, rectHeight);
        }

        public override void DrawPreview()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.DashDotDot;
            this.graphics.DrawRectangle(this.pen, rectX, rectY, rectWidth, rectHeight);
        }

        public override bool HitArea(int x, int y)
        {
            if ((x >= rectX && x <= rectX + rectWidth) && (y >=  rectY && y <= rectY + rectHeight))
            {
                return true;
            }
            return false;
        }

        public override void Move(MouseEventArgs e, int x, int y)
        {
            Point point = e.Location;
            this.rectX += x;
            this.rectY += y;
        }

        public override Point GetCenterPoint()
        {
            Point point = new Point();
            point.X = rectX + (rectWidth / 2);
            point.Y = rectY + (rectHeight / 2);
            return point;
        }
    }
}