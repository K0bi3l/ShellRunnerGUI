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

        CommandsQueue commandsQueue;
        int commandsQueueMaxCapacity = 20; //capacity to choose, so it is hardcoded
        int commandsQueueIndex;

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
            commandsQueue = new CommandsQueue(commandsQueueMaxCapacity);
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
                commandsQueue.Enqueue(input);
                if (commandsQueue.Count > commandsQueueMaxCapacity) commandsQueue.Dequeue();
                commandsQueueIndex = -1;
                InputProcesser inputProcesser = new InputProcesser(cmd.StandardInput);
                outputTextboxWriter.WriteToTextbox(input, Color.Orange);
                if (cmd != null && !cmd.HasExited)
                {
                    inputProcesser.ProcessInput(input);
                    //inputCleaner.CleanInput(WelcomeText);
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
                if (commandsQueue.Count - 1 == commandsQueueIndex) return;
                string command = commandsQueue.ElementAt(++commandsQueueIndex);
                inputCleaner.ChangeCommand(command, currentDirectory);
            }
            else if (e.KeyValue == (char)Keys.Down)
            {
                int index = commandsQueueIndex - 1;
                if (index <= -1)
                {
                    commandsQueueIndex = -1;
                    inputCleaner.CleanInput(currentDirectory);
                    return;
                }
                string command = commandsQueue.ElementAt(--commandsQueueIndex);
                inputCleaner.ChangeCommand(command, currentDirectory);
            }
            else if (e.KeyValue == (char)Keys.Left || e.KeyValue == (char)Keys.Back)
            {
                if (InputTextBox.SelectionStart < currentDirectory.Length + 1)
                {
                    e.SuppressKeyPress = true;
                }
            }
        }


    }
}
