using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public interface DrawingCanvas
    {
        void SetActiveTool(Tool tool);
        void Repaint();
        void SetBackgroundColor(Color color);
    }
}
