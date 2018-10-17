namespace DrawingToolkit
{
    public delegate void ToolSelectedEventHandler(Tool tool);

    public interface Toolbox
    {
        event ToolSelectedEventHandler ToolSelected;
        void AddTool(Tool tool);
        void RemoveTool(Tool tool);
        Tool ActiveTool { get; set; }
    }
}
