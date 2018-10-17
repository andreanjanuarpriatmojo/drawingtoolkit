using System.Drawing;

namespace DrawingToolkit
{
    public interface DrawingCanvas
    {
        void SetActiveTool(Tool tool);
        Tool GetActiveTool();
        void Repaint();
        void SetBackgroundColor(Color color);
        void AddDrawingObject(DrawingObject drawingObject);

        DrawingObject GetObject(int areaX, int areaY);
        DrawingObject SelectObject(int areaX, int areaY);
    }
}
