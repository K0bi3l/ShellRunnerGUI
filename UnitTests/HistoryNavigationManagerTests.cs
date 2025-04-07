using Jetbrains_1;
using System.Windows.Forms;

namespace UnitTests
{
    public class HistoryNavigationManagerTests
    {
        CommandsQueueManager commandsQueueManager;
        InputWindowManager inputWindowManager;
        HistoryNavigationHandler historyNavigationHandler;
        RichTextBox textBox;
        string currentDirectory = "C:\\";

        public HistoryNavigationManagerTests()
        {
            int maxCapacity = 3;
            textBox = new RichTextBox();
            commandsQueueManager = new CommandsQueueManager(maxCapacity);
            commandsQueueManager.AddCommand("element1");
            commandsQueueManager.AddCommand("element2");
            commandsQueueManager.AddCommand("element3");
            inputWindowManager = new InputWindowManager(textBox);
            historyNavigationHandler = new HistoryNavigationHandler(commandsQueueManager, inputWindowManager);
        }

        // Test wrong key
        [Fact]
        public void TestWrongKey()
        {
            var keyEventArgs = new KeyEventArgs(Keys.W);

            bool result = historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            Assert.False(result);
        }

        // Test up key called once
        [Fact]
        public void TestUpKey()
        {
            var keyEventArgs = new KeyEventArgs(Keys.Up);
            bool result = historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            Assert.True(result);
            Assert.Equal(currentDirectory + "element3", textBox.Text);
        }

        // Test up key called multiple times, but less than capacity
        [Fact]
        public void TestUpKeyMultTimes()
        {
            var keyEventArgs = new KeyEventArgs(Keys.Up);
            historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            bool result = historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            Assert.True(result);
            Assert.Equal(currentDirectory + "element2", textBox.Text);
        }

        // Test up key called multiple times, but more than capacity
        [Fact]
        public void TestUpKeyMoreThanCapacity()
        {
            var keyEventArgs = new KeyEventArgs(Keys.Up);
            for (int i = 0; i < 10; i++)
            {
                historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            }
            Assert.Equal(currentDirectory + "element1", textBox.Text);
        }

        // Test down key called once at start of the program
        [Fact]
        public void TestDownKeyOnce()
        {
            var keyEventArgs = new KeyEventArgs(Keys.Down);
            bool result = historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);               
            Assert.True(result);
            Assert.Equal(currentDirectory, textBox.Text);
        }

        // Test down key called once after up key
        [Fact]
        public void TestDownAfterUpKey()
        {
            var keyEventArgs = new KeyEventArgs(Keys.Up);
            historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            keyEventArgs = new KeyEventArgs(Keys.Down);
            bool result = historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            Assert.True(result);
            Assert.Equal(currentDirectory + "element3", textBox.Text);
        }

        // Test down key called multiple times
        [Fact]
        public void TestDownKeyMultTimes()
        {
            var keyEventArgs = new KeyEventArgs(Keys.Up);
            for (int i = 0; i < 10; i++)
            {
                historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            }
            keyEventArgs = new KeyEventArgs(Keys.Down);
            for (int i = 0; i < 10; i++)
            {
                historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            }
            Assert.Equal(currentDirectory, textBox.Text);
        }

        // Test down key called multiple times, but less than capacity
        [Fact]
        public void TestDownKeyMoreThanCapacity()
        {
            var keyEventArgs = new KeyEventArgs(Keys.Up);
            for (int i = 0; i < 3; i++)
            {
                historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            }
            keyEventArgs = new KeyEventArgs(Keys.Down);
            
            historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            bool result = historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            Assert.Equal(currentDirectory + "element3", textBox.Text);
        }

        // Test both keys called multiple times
        [Fact]
        public void TestDownAndUpMultTimes()
        {
            var keyEventArgs = new KeyEventArgs(Keys.Up);
            for (int i = 0; i < 10; i++)
            {
                historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            }
            keyEventArgs = new KeyEventArgs(Keys.Down);
            for (int i = 0; i < 3; i++)
            {
                historyNavigationHandler.HandleHistoryNavigation(keyEventArgs, currentDirectory);
            }
            Assert.Equal(currentDirectory, textBox.Text);
        }

    }
}
