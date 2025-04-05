using Jetbrains_1;
using System.Windows.Forms;

namespace UnitTests
{
    public class InputWindowManagerTests
    {

        private InputWindowManager inputWindowManager;
        private RichTextBox inputTextBox;
        public InputWindowManagerTests()
        {
            inputTextBox = new RichTextBox();
            inputWindowManager = new InputWindowManager(inputTextBox);
        }

        // Test clean input method
        [Fact]
        public void Test1()
        {
            string welcomeText = "Welcome";
            inputTextBox.Text = "test";
            inputWindowManager.CleanInput(welcomeText);
            Assert.Equal(welcomeText, inputTextBox.Text);
            Assert.Equal(welcomeText.Length, inputTextBox.SelectionStart);
        }

        // Test change command method
        [Fact]
        public void Test2()
        {
            inputTextBox.Text = "test";
            string command = "echo Hello";
            string currentDirectory = "C:\\";
            inputWindowManager.ChangeCommand(command, currentDirectory);
            Assert.Equal(currentDirectory + command, inputTextBox.Text);
            Assert.Equal(currentDirectory.Length + command.Length, inputTextBox.SelectionStart);
        }
    }
}
