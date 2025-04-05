using Jetbrains_1;

namespace UnitTests
{
    public class CommandsQueueManagerTests
    {
        // Test max capacity setting
        [Fact]
        public void Test1()
        {
            var maxCapacity = 1;
            var commandsQueueManager = new CommandsQueueManager(maxCapacity);
            Assert.Equal(maxCapacity, commandsQueueManager.QueueMaxCapacity);
        }

        // Test GetNext Command called once
        [Fact]
        public void Test2()
        {
            var maxCapacity = 1;
            var commandsQueueManager = new CommandsQueueManager(maxCapacity);
            commandsQueueManager.AddCommand("element1");
            commandsQueueManager.AddCommand("element2");
            commandsQueueManager.AddCommand("element3");
            Assert.Equal("element3", commandsQueueManager.GetNextCommand());
        }

        // Test GetNextCommand called multiple times
        [Fact]
        public void Test3()
        {
            var maxCapacity = 3;
            var commandsQueueManager = new CommandsQueueManager(maxCapacity);
            commandsQueueManager.AddCommand("element1");
            commandsQueueManager.AddCommand("element2");
            commandsQueueManager.AddCommand("element3");
            commandsQueueManager.GetNextCommand();
            var command = commandsQueueManager.GetNextCommand();
            Assert.Equal("element2", command);
        }

        // Test GetNextCommand called more times than queue capacity
        [Fact]
        public void Test4()
        {
            var maxCapacity = 3;
            var commandsQueueManager = new CommandsQueueManager(maxCapacity);
            commandsQueueManager.AddCommand("element1");
            commandsQueueManager.AddCommand("element2");
            commandsQueueManager.AddCommand("element3");
            for (int i = 0; i < 10; i++) commandsQueueManager.GetNextCommand();
            var command = commandsQueueManager.GetNextCommand();
            Assert.Null(command);
        }

        // Test GetPreviousCommand called once
        [Fact]
        public void Test5()
        {
            var maxCapacity = 3;
            var commandsQueueManager = new CommandsQueueManager(maxCapacity);
            commandsQueueManager.AddCommand("element1");
            commandsQueueManager.AddCommand("element2");
            commandsQueueManager.AddCommand("element3");
            commandsQueueManager.GetNextCommand();
            commandsQueueManager.GetNextCommand();
            var command = commandsQueueManager.GetPreviousCommand();
            Assert.Equal("element3", command);
        }

        // Test GetPreviousCommand called multiple times
        [Fact]
        public void Test6()
        {
            var maxCapacity = 3;
            var commandsQueueManager = new CommandsQueueManager(maxCapacity);
            commandsQueueManager.AddCommand("element1");
            commandsQueueManager.AddCommand("element2");
            commandsQueueManager.AddCommand("element3");            
            for (int i = 0; i < 3; i++) commandsQueueManager.GetNextCommand();

            commandsQueueManager.GetPreviousCommand();
            var command = commandsQueueManager.GetPreviousCommand();
            Assert.Equal("element3", command);
        }

        // Test GetPreviousCommand called more times than queue capacity
        [Fact]
        public void Test7()
        {
            var maxCapacity = 3;
            var commandsQueueManager = new CommandsQueueManager(maxCapacity);
            commandsQueueManager.AddCommand("element1");
            commandsQueueManager.AddCommand("element2");
            commandsQueueManager.AddCommand("element3");
            for (int i = 0; i < 10; i++) commandsQueueManager.GetPreviousCommand();
            var command = commandsQueueManager.GetPreviousCommand();
            Assert.Null(command);
        }

        // Test GetPreviousCommand called when queue is empty
        [Fact]
        public void Test8()
        {
            var maxCapacity = 3;
            var commandsQueueManager = new CommandsQueueManager(maxCapacity);       
            var command = commandsQueueManager.GetPreviousCommand();
            Assert.Null(command);
        }

        // Test GetNextCommand called when queue is empty
        [Fact]
        public void Test9()
        {
            var maxCapacity = 3;
            var commandsQueueManager = new CommandsQueueManager(maxCapacity);
            var command = commandsQueueManager.GetNextCommand();
            Assert.Null(command);
        }

        // Test GetNextCommand called when queue is empty and then AddCommand
        [Fact]
        public void Test10()
        {
            var maxCapacity = 3;
            var commandsQueueManager = new CommandsQueueManager(maxCapacity);
            var command = commandsQueueManager.GetNextCommand();
            Assert.Null(command);
            commandsQueueManager.AddCommand("element1");
            commandsQueueManager.AddCommand("element2");
            command = commandsQueueManager.GetNextCommand();
            Assert.Equal("element2", command);
        }

        // Test mixed GetNextCommand and GetPreviousCommand
        [Fact]
        public void Test11()
        {
            var maxCapacity = 5;
            var commandsQueueManager = new CommandsQueueManager(maxCapacity);
            commandsQueueManager.AddCommand("element1");
            commandsQueueManager.AddCommand("element2");
            commandsQueueManager.AddCommand("element3");
            commandsQueueManager.AddCommand("element4");
            commandsQueueManager.AddCommand("element5");
            commandsQueueManager.GetNextCommand();
            var command = commandsQueueManager.GetNextCommand();
            Assert.Equal("element4", command);
            command = commandsQueueManager.GetPreviousCommand();
            
            Assert.Equal("element5", command);
            for (int i = 0; i < 10; i++) commandsQueueManager.GetNextCommand();
            command = commandsQueueManager.GetPreviousCommand();
            Assert.Equal("element2", command);
            for (int i = 0; i < 10; i++) commandsQueueManager.GetPreviousCommand();
            command = commandsQueueManager.GetPreviousCommand();
            Assert.Null(command);

        }


    }
}
