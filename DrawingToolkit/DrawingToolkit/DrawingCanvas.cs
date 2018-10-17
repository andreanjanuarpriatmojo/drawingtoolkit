using System.Drawing;

namespace DrawingToolkit
{
    public interface DrawingCanvas
    {
        void SetActiveTool(Tool tool);
        void Repaint();
        void SetBackgroundColor(Color color);
        void AddDrawingObject(DrawingObject drawingObject);
    }
}