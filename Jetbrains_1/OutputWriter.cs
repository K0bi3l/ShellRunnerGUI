using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Jetbrains_1
{
    public class OutputTextboxWriter
    {
        RichTextBox outputTextbox;
        public OutputTextboxWriter(RichTextBox outputTextbox) 
        {
            this.outputTextbox = outputTextbox;
        }

        public void WriteToTextbox(string text, Color color)
        {
            outputTextbox.SelectionColor = color;       
            
            // should change the second condition, but it is correct because only input has the orange color 
            if (!string.IsNullOrEmpty(text) && !(color == Color.Orange)) text += Environment.NewLine;
            outputTextbox.AppendText(text);
            outputTextbox.ScrollToCaret();
        }
    }
}
