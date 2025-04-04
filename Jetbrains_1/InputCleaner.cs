using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jetbrains_1
{
    public class InputCleaner
    {
        private readonly RichTextBox inputTextBox;
       
        public InputCleaner(RichTextBox inputTextBox)
        {
            this.inputTextBox = inputTextBox;            
        }

        public void CleanInput(string welcomeText)
        {
            inputTextBox.Clear();
            inputTextBox.Text = welcomeText;
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
        }

        public void ChangeCommand(string command,string welcomeText)
        {
            CleanInput(welcomeText);
            inputTextBox.AppendText(command);
        }

    }
}
