using Jetbrains_1;

namespace UnitTests
{   
    public class CommandsQueueTests
    {
        // Test enqueueuing one element
        [Fact]
        public void TestEnqueuingOneElement()
        {
            var commandsQueue = new CommandsQueue();
            commandsQueue.Enqueue("element1");            

            Assert.Equal(1, commandsQueue.Count);
        }

        // Test enqueueuing multiple elements
        [Fact]
        public void TestEnqueueingMulElems()
        {
            var commandsQueue = new CommandsQueue();
            commandsQueue.Enqueue("element1");
            commandsQueue.Enqueue("element2");
            commandsQueue.Enqueue("element3");
            Assert.Equal(3, commandsQueue.Count);
        }

        // Test dequeueuing 
        [Fact]
        public void TestDequeueing()
        {
            var commandsQueue = new CommandsQueue();
            commandsQueue.Enqueue("element1");
            commandsQueue.Enqueue("element2");            
            commandsQueue.Dequeue();
            Assert.Equal(1, commandsQueue.Count);
        }

        // Test correctness of the elementAt method
        [Fact]
        public void TestElementAt()
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