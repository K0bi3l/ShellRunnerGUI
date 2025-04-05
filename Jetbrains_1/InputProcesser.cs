namespace Jetbrains_1
{
    public class InputProcesser
    {
        private readonly StreamWriter inputWriter;

        public InputProcesser(StreamWriter inputWriter)
        {
            this.inputWriter = inputWriter;
        }

        public void ProcessInput(string input)
        {
            inputWriter.WriteLine(input);
            inputWriter.Flush();
        }

    }
}
