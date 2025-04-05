using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jetbrains_1
{
     public class CommandsQueueManager
    {
        
        CommandsQueue commandsQueue;
        int commandsQueueIndex;
        public CommandsQueueManager() 
        {
            commandsQueue = new CommandsQueue();
            commandsQueueIndex = -1;
        }

        public string GetNextCommand()
        {
            if (commandsQueue.Count - 1 == commandsQueueIndex) return commandsQueue.ElementAt(commandsQueueIndex); //??
            string command = commandsQueue.ElementAt(++commandsQueueIndex);
            return command;
        }

        public string GetPreviousCommand()
        {
            int index = commandsQueueIndex - 1;
            if (index <= -1)
            {
                commandsQueueIndex = -1;
                return null;
                //inputCleaner.CleanInput(currentDirectory);
            }
            else
            {
                string command = commandsQueue.ElementAt(--commandsQueueIndex);
                return command;
            }
            //inputCleaner.ChangeCommand(command, currentDirectory);
        }
    }
}
