using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public class DefaultToolbox : ToolStrip, Toolbox
    {
        private Tool activeTool;

        public Tool ActiveTool
        {
            get
            {
                return this.activeTool;
            }
        }

        public event ToolSelectedEventHandler ToolSelected;

        public void AddTool(Tool tool)
        {
            Debug.WriteLine(tool.Name + " is added into toolbox.");

            if (tool is ToolStripButton)
            {
                ToolStripButton toggleButton = (ToolStripButton)tool;

                if (toggleButton.CheckOnClick)
                {
                    toggleButton.CheckedChanged += toggleButton_CheckedChanged;
                }

                this.Items.Add(toggleButton);
            }
        }

        public void RemoveTool(Tool tool)
        {
            foreach (ToolStripItem i in this.Items)
            {
                if (i is Tool)
                {
                    if (i.Equals(tool))
                    {
                        this.Items.Remove(i);
                    }
                }
            }
        }

        private void toggleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                ToolStripButton button = (ToolStripButton)sender;

                if (button.Checked)
                {
                    if (button is Tool)
                    {
                        this.activeTool = (Tool)button;
                        Debug.WriteLine(this.activeTool.Name + " is activated.");

                        if (ToolSelected != null)
                        {
                            ToolSelected(this.activeTool);
                        }

                        UncheckInactiveToggleButtons();
                    }
                    else
                    {
                        throw new InvalidCastException("The tool is not an instance of ITool.");
                    }
                }
            }
        }

        private void UncheckInactiveToggleButtons()
        {
            foreach (ToolStripItem item in this.Items)
            {
                if (item != this.activeTool)
                {
                    if (item is ToolStripButton)
                    {
                        ((ToolStripButton)item).Checked = false;
                    }
                }
            }
        }
    }
}
