namespace Jetbrains_1
{
    public class HistoryNavigationHandler
    {
        CommandsQueueManager commandsQueueManager;
        InputWindowManager inputWindowManager;

        public HistoryNavigationHandler(CommandsQueueManager commandsQueueManager, InputWindowManager inputWindowManager)
        {
            this.commandsQueueManager = commandsQueueManager;
            this.inputWindowManager = inputWindowManager;
        }

        public bool HandleHistoryNavigation(KeyEventArgs e, string currentDirectory)
        {
            if (HandleKeyUp(e, currentDirectory)) return true;
            if(HandleKeyDown(e, currentDirectory)) return true;
            return false;
        }

        public bool HandleKeyUp(KeyEventArgs e, string currentDirectory)
        {
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                string? command = commandsQueueManager.GetNextCommand();
                if (command is not null)
                {
                    inputWindowManager.ChangeCommand(command, currentDirectory);
                }
                return true;
            }
            return false;
        }

        public bool HandleKeyDown(KeyEventArgs e, string currentDirectory)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                string? command = commandsQueueManager.GetPreviousCommand();
                if (command is null)
                {
                    inputWindowManager.CleanInput(currentDirectory);
                    return true;
                }
                inputWindowManager.ChangeCommand(command, currentDirectory);
                return true;
            }
            return false;
        }
    }
}
