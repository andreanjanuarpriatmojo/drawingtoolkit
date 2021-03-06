﻿using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Linq;
using DrawingToolkit.State;

namespace DrawingToolkit.Tools
{
    public class SelectTool : ToolStripButton, Tool
    {
        private DrawingCanvas drawingCanvas;
        private DrawingObject currentObject;
        Point point;
        private Boolean multiSelect = false;

        private List<DrawingObject> tempGroup = new List<DrawingObject>();

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public DrawingCanvas TargetCanvas
        {
            get
            {
                return this.drawingCanvas;
            }

            set
            {
                this.drawingCanvas = value;
            }

        }

        public SelectTool()
        {
            this.Name = "Select Tool";
            this.ToolTipText = "Select Tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;

            if (e.Button == MouseButtons.Left && drawingCanvas != null)
            {
                if (currentObject == null)
                {
                    drawingCanvas.DeselectAll();
                    tempGroup.Clear();
                }
                else if (!multiSelect)
                {
                    currentObject.ChangeState(IdleState.GetInstance());
                }
                currentObject = drawingCanvas.SelectObject(e.X, e.Y);
                if (currentObject != null)
                {
                    currentObject.ChangeState(EditState.GetInstance());
                    if (multiSelect)
                    {
                        tempGroup.Add(currentObject);
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && drawingCanvas != null)
            {
                if (currentObject != null)
                {
                    int xMove = e.X - point.X;
                    int yMove = e.Y - point.Y;
                    point = e.Location;
                    currentObject.Move(e, xMove, yMove);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                multiSelect = true;
            }
            else if(e.KeyCode == Keys.G)
            {
                if (tempGroup.Count() > 1)
                {
                    DrawingGroup drawingGroup = new DrawingGroup();
                    foreach (DrawingObject drawingObject in tempGroup)
                    {
                        drawingGroup.AddComposite(drawingObject);
                    }
                    drawingGroup.ChangeState(IdleState.GetInstance());
                    this.drawingCanvas.AddDrawingObject(drawingGroup);
                    tempGroup.Clear();
                }
            }
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                multiSelect = false;
            }
        }
    }
}