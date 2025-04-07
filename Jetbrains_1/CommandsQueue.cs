namespace ShellRunnerGUI
{
    public class CommandsQueue
    {
        private Queue<string> commandsQueue;

        public int Count
        {
            get { return commandsQueue.Count; }
        }
        public CommandsQueue()
        {
            commandsQueue = new Queue<string>();
        }

        public CommandsQueue(int capacity)
        {
            commandsQueue = new Queue<string>(capacity);
        }

        public void Enqueue(string command)
        {
            commandsQueue.Enqueue(command);
        }

        public void Dequeue()
        {
            commandsQueue.Dequeue();
        }

        public string ElementAt(int index)
        {
            return commandsQueue.ElementAt(commandsQueue.Count - 1 - index);
        }        

    }
}