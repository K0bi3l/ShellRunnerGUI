using Jetbrains_1;
using System.Windows.Forms;

namespace UnitTests
{
    public class OutputWriterTests
    {
        RichTextBox textBox;
        OutputWriter outputWriter;

        public OutputWriterTests()
        {
            textBox = new RichTextBox();
            outputWriter = new OutputWriter(textBox);
        }

        // Test WriteToTextbox method with OutputType.Error
        [Fact]
        public void TestWriteToTextboxError()
        {
            string text = "Error message";
            outputWriter.WriteToTextbox(text, OutputType.Error);            
            Assert.Equal(text + '\n', textBox.Text);            
        }

        // Test WriteToTextbox method with OutputType.Input
        [Fact]
        public void TestWriteToTextboxInput()
        {
            string text = "Input message";
            outputWriter.WriteToTextbox(text, OutputType.Input);
            Assert.Equal(text, textBox.Text);
            Assert.Equal(System.Drawing.Color.Orange, textBox.SelectionColor);
        }

        // Test WriteToTextbox method with null text
        [Fact]
        public void TestWriteToTextboxNullText()
        {
            string? text = null;
            outputWriter.WriteToTextbox(text, OutputType.Output);
            Assert.Equal(string.Empty, textBox.Text);
            Assert.Equal(System.Drawing.Color.White, textBox.SelectionColor);
        }
    }
}
