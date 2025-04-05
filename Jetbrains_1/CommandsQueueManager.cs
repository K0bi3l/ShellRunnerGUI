using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jetbrains_1
{
     public class CommandsQueueManager
    {
        
        private CommandsQueue commandsQueue;
        private int queueIndex;
        private int queueMaxCapacity;

        public int QueueMaxCapacity
        {
            get { return queueMaxCapacity; }
            set { queueMaxCapacity = value; }
        }


        public CommandsQueueManager(int capacity)
        {
            queueMaxCapacity = capacity;
            commandsQueue = new CommandsQueue(capacity);
            queueIndex = -1;
            
        }        

        public void AddCommand(string command)
        {
            commandsQueue.Enqueue(command);
            if (commandsQueue.Count > queueMaxCapacity) commandsQueue.Dequeue();
            queueIndex = -1;
        }

        public string? GetNextCommand()
        {
            if (commandsQueue.Count - 1 == queueIndex) return null;
            string command = commandsQueue.ElementAt(++queueIndex);
            return command;
        }

        public string? GetPreviousCommand()
        {
            int index = queueIndex - 1;
            if (index <= -1)
            {
                queueIndex = -1;
                return null;               
            }
            else
            {
                string command = commandsQueue.ElementAt(--queueIndex);
                return command;
            }            
        }
    }
}
