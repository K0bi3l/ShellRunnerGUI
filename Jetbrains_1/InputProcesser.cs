using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
