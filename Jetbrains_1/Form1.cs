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

        Queue<string> inputQueue;
        int inputQueueMaxCapacity = 20; //capacity to choose, so it is hardcoded
        int inputQueuePointer;

        string currentDirectory;
        string input { get; set; }
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
            outputTextboxWriter = new OutputTextboxWriter(OutputTextBox);
            inputCleaner = new InputCleaner(InputTextBox);
            inputQueue = new Queue<string>();
            inputQueuePointer = 0;

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
                input = InputTextBox.Text.Split(">")[1];
                inputQueue.Enqueue(input);
                if (inputQueue.Count > inputQueueMaxCapacity) inputQueue.Dequeue();
                inputQueuePointer = 0;
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

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyValue == (char)Keys.Up)
            {
                if (inputQueue.Count <= inputQueuePointer) return;
                string command = inputQueue.ElementAt(inputQueuePointer++);
                inputCleaner.ChangeCommand(command, currentDirectory);
            }
            else if (e.KeyValue == (char)Keys.Down)
            {
                if (inputQueuePointer == 0) return;
                string command = inputQueue.ElementAt(--inputQueuePointer);
                inputCleaner.ChangeCommand(command, currentDirectory);
            }
        }
    }
}
