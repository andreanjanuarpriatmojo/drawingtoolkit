using System.Collections.Generic;
using System.Drawing;

namespace DrawingToolkit
{
    public interface DrawingCanvas
    {
        void SetActiveTool(Tool tool);
        void Repaint();
        void SetBackgroundColor(Color color);
        void AddDrawingObject(DrawingObject drawingObject);
        void AddDrawingObjectToFront(DrawingObject drawingObject);

        DrawingObject GetObject(int x, int y);
        DrawingObject SelectObject(int x, int y);
        void DeselectAll();
    }
}