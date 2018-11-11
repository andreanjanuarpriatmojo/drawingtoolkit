using System;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public interface Tool
    {
        String Name { get; set; }
        Cursor Cursor { get; }
        DrawingCanvas TargetCanvas { get; set; }

        void ToolMouseDown(object sender, MouseEventArgs e);
        void ToolMouseUp(object sender, MouseEventArgs e);
        void ToolMouseMove(object sender, MouseEventArgs e);

        void ToolKeyDown(object sender, KeyEventArgs e);
        void ToolKeyUp(object sender, KeyEventArgs e);
    }
}
