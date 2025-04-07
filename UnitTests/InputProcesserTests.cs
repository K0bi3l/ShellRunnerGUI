using Jetbrains_1;

namespace UnitTests
{
    public class InputProcesserTests
    {
        public StreamWriter inputWriter;
        public InputProcesser inputProcesser;
        public MemoryStream stream;

        public InputProcesserTests()
        {
            stream = new MemoryStream();
            inputWriter = new StreamWriter(stream);
            inputProcesser = new InputProcesser(inputWriter);
        }

        // Test process input method
        [Fact]
        public void TestProcessInput()
        {
            string input = "input";
            inputProcesser.ProcessInput(input);            
            string result = System.Text.Encoding.UTF8.GetString((stream).ToArray());
            Assert.Equal(input + Environment.NewLine, result);
        }


    }
}
