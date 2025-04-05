namespace Jetbrains_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            outputTextBox = new RichTextBox();
            outputLabel = new Label();
            inputTextBox = new RichTextBox();
            inputLabel = new Label();
            commandsMemoryLabel = new Label();
            commandsMemoryButton = new Button();
            setCapacityGroupBox = new GroupBox();
            memoryCapacityControl = new NumericUpDown();
            setCapacityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)memoryCapacityControl).BeginInit();
            SuspendLayout();
            // 
            // outputTextBox
            // 
            outputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            outputTextBox.BackColor = SystemColors.MenuText;
            outputTextBox.ForeColor = SystemColors.Control;
            outputTextBox.Location = new Point(105, 604);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.ReadOnly = true;
            outputTextBox.Size = new Size(1316, 290);
            outputTextBox.TabIndex = 1;
            outputTextBox.Text = "";
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new Point(105, 559);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new Size(73, 25);
            outputLabel.TabIndex = 2;
            outputLabel.Text = "Output:";
            // 
            // inputTextBox
            // 
            inputTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            inputTextBox.BackColor = SystemColors.MenuText;
            inputTextBox.ForeColor = SystemColors.Control;
            inputTextBox.Location = new Point(105, 201);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.ScrollBars = RichTextBoxScrollBars.ForcedHorizontal;
            inputTextBox.Size = new Size(1316, 275);
            inputTextBox.TabIndex = 3;
            inputTextBox.Text = "";
            inputTextBox.KeyDown += InputTextBox_KeyDown;
            inputTextBox.KeyPress += InputTextBox_KeyPress;
            // 
            // inputLabel
            // 
            inputLabel.AutoSize = true;
            inputLabel.Location = new Point(105, 151);
            inputLabel.Name = "inputLabel";
            inputLabel.Size = new Size(58, 25);
            inputLabel.TabIndex = 4;
            inputLabel.Text = "Input:";
            // 
            // commandsMemoryLabel
            // 
            commandsMemoryLabel.AutoSize = true;
            commandsMemoryLabel.Location = new Point(25, 37);
            commandsMemoryLabel.Name = "commandsMemoryLabel";
            commandsMemoryLabel.Size = new Size(252, 25);
            commandsMemoryLabel.TabIndex = 5;
            commandsMemoryLabel.Text = "Commands Memory Capacity:";
            // 
            // commandsMemoryButton
            // 
            commandsMemoryButton.Location = new Point(64, 111);
            commandsMemoryButton.Name = "commandsMemoryButton";
            commandsMemoryButton.Size = new Size(179, 34);
            commandsMemoryButton.TabIndex = 7;
            commandsMemoryButton.Text = "Set new capacity";
            commandsMemoryButton.UseVisualStyleBackColor = true;
            commandsMemoryButton.Click += commandsMemoryButton_Click;
            // 
            // setCapacityGroupBox
            // 
            setCapacityGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            setCapacityGroupBox.Controls.Add(memoryCapacityControl);
            setCapacityGroupBox.Controls.Add(commandsMemoryLabel);
            setCapacityGroupBox.Controls.Add(commandsMemoryButton);
            setCapacityGroupBox.Location = new Point(1266, 12);
            setCapacityGroupBox.MaximumSize = new Size(300, 167);
            setCapacityGroupBox.MinimumSize = new Size(300, 167);
            setCapacityGroupBox.Name = "setCapacityGroupBox";
            setCapacityGroupBox.Size = new Size(300, 167);
            setCapacityGroupBox.TabIndex = 8;
            setCapacityGroupBox.TabStop = false;
            // 
            // memoryCapacityControl
            // 
            memoryCapacityControl.Location = new Point(63, 74);
            memoryCapacityControl.Name = "memoryCapacityControl";
            memoryCapacityControl.Size = new Size(180, 31);
            memoryCapacityControl.TabIndex = 9;
            memoryCapacityControl.ValueChanged += memoryCapacityControl_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 1144);
            Controls.Add(setCapacityGroupBox);
            Controls.Add(inputLabel);
            Controls.Add(inputTextBox);
            Controls.Add(outputLabel);
            Controls.Add(outputTextBox);
            MaximumSize = new Size(3200, 2400);
            MinimumSize = new Size(1600, 1200);
            Name = "Form1";
            Text = "ShellRunner";
            setCapacityGroupBox.ResumeLayout(false);
            setCapacityGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)memoryCapacityControl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox outputTextBox;
        private Label outputLabel;
        private RichTextBox inputTextBox;
        private Label inputLabel;
        private Label commandsMemoryLabel;
        private Button commandsMemoryButton;
        private GroupBox setCapacityGroupBox;
        private NumericUpDown memoryCapacityControl;
    }
}
