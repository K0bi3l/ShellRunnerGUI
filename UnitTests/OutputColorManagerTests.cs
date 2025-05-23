﻿using ShellRunnerGUI;
using System.Drawing;

namespace UnitTests
{
    public class OutputColorManagerTests
    {
        // Test GetColor method
        [Fact]
        public void TestGetColor()
        {
            OutputColorManager outputColorManager = new OutputColorManager();
            Assert.Equal(Color.White, outputColorManager.GetColor(OutputType.Output));
            Assert.Equal(Color.Orange, outputColorManager.GetColor(OutputType.Input));
            Assert.Equal(Color.Red, outputColorManager.GetColor(OutputType.Error));
        }
    }
}
