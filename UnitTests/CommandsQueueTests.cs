using Jetbrains_1;

namespace UnitTests
{   
    public class CommandsQueueTests
    {
        // Test enqueueuing one element
        [Fact]
        public void Test1()
        {
            var commandsQueue = new CommandsQueue();
            commandsQueue.Enqueue("element1");            

            Assert.Equal(1, commandsQueue.Count);
        }

        // Test enqueueuing multiple elements
        [Fact]
        public void Test2()
        {
            var commandsQueue = new CommandsQueue();
            commandsQueue.Enqueue("element1");
            commandsQueue.Enqueue("element2");
            commandsQueue.Enqueue("element3");
            Assert.Equal(3, commandsQueue.Count);
        }

        // Test dequeueuing 
        [Fact]
        public void Test3()
        {
            var commandsQueue = new CommandsQueue();
            commandsQueue.Enqueue("element1");
            commandsQueue.Enqueue("element2");            
            commandsQueue.Dequeue();
            Assert.Equal(1, commandsQueue.Count);
        }

        // Test correctness of the elementAt method
        [Fact]
        public void Test4()
        {
            var commandsQueue = new CommandsQueue();
            commandsQueue.Enqueue("element1");
            commandsQueue.Enqueue("element2");
            commandsQueue.Enqueue("element3");
            Assert.Equal("element3", commandsQueue.ElementAt(0));
            Assert.Equal("element2", commandsQueue.ElementAt(1));
            Assert.Equal("element1", commandsQueue.ElementAt(2));
        }
    }   
}