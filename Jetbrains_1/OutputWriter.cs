namespace ShellRunnerGUI
{
    public class OutputWriter
    {
        RichTextBox outputTextbox;
        OutputColorManager outputColorManager;
        public OutputWriter(RichTextBox outputTextbox) 
        {
            this.outputTextbox = outputTextbox;
            outputColorManager = new OutputColorManager();
        }

        public void WriteToTextbox(string? text, OutputType type)
        {
            var color = outputColorManager.GetColor(type);
            outputTextbox.SelectionColor = color;       
                    
            if (!string.IsNullOrEmpty(text) && !(type == OutputType.Input)) text += Environment.NewLine;
            outputTextbox.AppendText(text);
            outputTextbox.ScrollToCaret();            
        }
    }
}
