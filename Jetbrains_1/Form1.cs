using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Text;

namespace Jetbrains_1
{
    public partial class Form1 : Form
    {
        readonly Process cmd;
        readonly OutputWriter outputTextboxWriter;
        readonly InputWindowManager inputWindowManager;
        readonly InputProcesser inputProcesser;
        readonly HistoryNavigationHandler historyNavigationHandler;
        readonly CommandsQueueManager commandsQueueManager;        
        int commandsQueueMaxCapacity; 
        string currentDirectory;
        public Form1()
        {
            InitializeComponent();            

            var startCmd = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                UseShellExecute = false,
                Arguments = "-NoLogo",
            };
            cmd = new Process
            {
                StartInfo = startCmd,
                EnableRaisingEvents = true,
            };
            cmd.Start();
            cmd.OutputDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    Append(e.Data, OutputType.Output);
                }
            };

            cmd.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    Append(e.Data, OutputType.Error);
                }
            };
            cmd.BeginOutputReadLine();
            cmd.BeginErrorReadLine();

            //sample value to initiate the queue capacity, not to small not to big to avoid multiple capacity increasing and not to allocate too much memory at start
            commandsQueueMaxCapacity = 20;
            memoryCapacityControl.Value = commandsQueueMaxCapacity;

            outputTextboxWriter = new OutputWriter(outputTextBox);
            inputWindowManager = new InputWindowManager(inputTextBox);
            inputProcesser = new InputProcesser(cmd.StandardInput);
            commandsQueueManager = new CommandsQueueManager(commandsQueueMaxCapacity);
            historyNavigationHandler = new HistoryNavigationHandler(commandsQueueManager, inputWindowManager);

            inputTextBox.Focus();
            currentDirectory = Environment.CurrentDirectory + "> ";
            inputTextBox.Text = currentDirectory;

        }        

        private bool TryUpdateDirectory(string text)
        {
            if (text.StartsWith("PS"))
            {
                currentDirectory = text[3..];
                inputTextBox.Invoke(new Action(() => inputWindowManager.CleanInput(currentDirectory)));
                return true;
            }
            return false;
        }

        private void Append(string text, OutputType type)
        {
            if (outputTextBox.InvokeRequired)
            {
                if(TryUpdateDirectory(text)) return;

                outputTextBox.Invoke(new Action(() => outputTextboxWriter.WriteToTextbox(text, type)));
                return;
            }
            if (TryUpdateDirectory(text)) return;
            outputTextboxWriter.WriteToTextbox(text, type);
        }


        private void InputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string input = inputTextBox.Text.Split(">")[1];
                commandsQueueManager.AddCommand(input);

                outputTextboxWriter.WriteToTextbox("Command: " + input, OutputType.Input);
                if (cmd != null && !cmd.HasExited)
                {
                    inputProcesser.ProcessInput(input);
                }
                e.Handled = true;
            }
        }
        
        private void BlockDirectoryDeleting(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (inputTextBox.SelectionStart <= currentDirectory.Length)
                {
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {           
            if (historyNavigationHandler.HandleHistoryNavigation(e,currentDirectory)) return;
            BlockDirectoryDeleting(e);
        }
       
        private void commandsMemoryButton_Click(object sender, EventArgs e)
        {
            commandsQueueManager.QueueMaxCapacity = (int)memoryCapacityControl.Value;
        }

        private void memoryCapacityControl_ValueChanged(object sender, EventArgs e)
        {
            if (memoryCapacityControl.Value < 1) memoryCapacityControl.Value = 1;
            if (memoryCapacityControl.Value > 9999) memoryCapacityControl.Value = 9999;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (cmd != null && !cmd.HasExited)
            {
                cmd.Close();
                cmd.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}
