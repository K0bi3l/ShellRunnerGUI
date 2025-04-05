using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Text;

namespace Jetbrains_1
{
    public partial class Form1 : Form
    {
        readonly Process cmd;
        readonly OutputTextboxWriter outputTextboxWriter;
        readonly InputCleaner inputCleaner;
        readonly InputProcesser inputProcesser;
       
        CommandsQueueManager commandsQueueManager;
        int commandsQueueMaxCapacity = 20; //capacity to choose, so it is hardcoded       

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
                    Append(e.Data, Color.White);
                }
            };

            cmd.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    Append(e.Data, Color.Red);
                }
            };

            cmd.BeginOutputReadLine();
            cmd.BeginErrorReadLine();
            InputTextBox.Focus();
            currentDirectory = Environment.CurrentDirectory + ">";
            InputTextBox.Text = currentDirectory;

            outputTextboxWriter = new OutputTextboxWriter(OutputTextBox);
            inputCleaner = new InputCleaner(InputTextBox);
            inputProcesser = new InputProcesser(cmd.StandardInput);
            commandsQueue = new CommandsQueue(commandsQueueMaxCapacity);
            commandsQueueManager = new CommandsQueueManager(commandsQueueMaxCapacity);
            commandsQueueIndex = -1;

        }

        private void Append(string text, Color color)
        {
            if (OutputTextBox.InvokeRequired)
            {
                //wynieœæ do innej metody
                if (text.StartsWith("PS"))
                {
                    currentDirectory = text[3..];
                    InputTextBox.Invoke(new Action(() => inputCleaner.CleanInput(currentDirectory)));
                    return;
                }

                OutputTextBox.Invoke(new Action(() => outputTextboxWriter.WriteToTextbox(text, color)));
                return;
            }
            outputTextboxWriter.WriteToTextbox(text, color);
        }


        private void InputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string input = InputTextBox.Text.Split(">")[1];               
                commandsQueueManager.AddCommand(input);
               
                outputTextboxWriter.WriteToTextbox("Command: " + input, Color.Orange);
                if (cmd != null && !cmd.HasExited)
                {
                    inputProcesser.ProcessInput(input);                    
                }
                e.Handled = true;
            }
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

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Up)
            {                
                string command = commandsQueueManager.GetNextCommand();
                inputCleaner.ChangeCommand(command, currentDirectory);
            }
            else if (e.KeyValue == (char)Keys.Down)
            {                
                string command = commandsQueueManager.GetPreviousCommand();
                if (command == null)
                {
                    inputCleaner.CleanInput(currentDirectory);
                    return;
                }
                inputCleaner.ChangeCommand(command, currentDirectory);
            }
            else if (e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Back)
            {
                if (InputTextBox.SelectionStart <= currentDirectory.Length)
                {
                    e.SuppressKeyPress = true;
                }
            }          
        }
    }
}
