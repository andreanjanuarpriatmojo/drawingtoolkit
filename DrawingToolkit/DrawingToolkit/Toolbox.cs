using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public delegate void ToolSelectedEventHandler(Tool tool);

    public interface Toolbox
    {
        event ToolSelectedEventHandler ToolSelected;
        void AddTool(Tool tool);
        void RemoveTool(Tool tool);
        Tool ActiveTool { get; }
    }
}
