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
            components = new System.ComponentModel.Container();
            OutputTextBox = new RichTextBox();
            OutputLabel = new Label();
            InputTextBox = new RichTextBox();
            InputLabel = new Label();
            MenuStrip = new ContextMenuStrip(components);
            oToolStripMenuItem = new ToolStripMenuItem();
            commandsMemorySizeToolStripMenuItem = new ToolStripMenuItem();
            MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // OutputTextBox
            // 
            OutputTextBox.BackColor = SystemColors.MenuText;
            OutputTextBox.ForeColor = SystemColors.Control;
            OutputTextBox.Location = new Point(105, 649);
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.ReadOnly = true;
            OutputTextBox.Size = new Size(1316, 290);
            OutputTextBox.TabIndex = 1;
            OutputTextBox.Text = "";
            // 
            // OutputLabel
            // 
            OutputLabel.AutoSize = true;
            OutputLabel.Location = new Point(105, 608);
            OutputLabel.Name = "OutputLabel";
            OutputLabel.Size = new Size(73, 25);
            OutputLabel.TabIndex = 2;
            OutputLabel.Text = "Output:";
            // 
            // InputTextBox
            // 
            InputTextBox.BackColor = SystemColors.MenuText;
            InputTextBox.ForeColor = SystemColors.Control;
            InputTextBox.Location = new Point(105, 111);
            InputTextBox.Name = "InputTextBox";
            InputTextBox.ScrollBars = RichTextBoxScrollBars.ForcedHorizontal;
            InputTextBox.Size = new Size(1316, 275);
            InputTextBox.TabIndex = 3;
            InputTextBox.Text = "";
            InputTextBox.KeyDown += InputTextBox_KeyDown;
            InputTextBox.KeyPress += InputTextBox_KeyPress;
            // 
            // InputLabel
            // 
            InputLabel.AutoSize = true;
            InputLabel.Location = new Point(105, 72);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(58, 25);
            InputLabel.TabIndex = 4;
            InputLabel.Text = "Input:";
            // 
            // MenuStrip
            // 
            MenuStrip.ImageScalingSize = new Size(24, 24);
            MenuStrip.Items.AddRange(new ToolStripItem[] { oToolStripMenuItem });
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(149, 36);
            // 
            // oToolStripMenuItem
            // 
            oToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { commandsMemorySizeToolStripMenuItem });
            oToolStripMenuItem.Name = "oToolStripMenuItem";
            oToolStripMenuItem.Size = new Size(148, 32);
            oToolStripMenuItem.Text = "Options";
            // 
            // commandsMemorySizeToolStripMenuItem
            // 
            commandsMemorySizeToolStripMenuItem.Name = "commandsMemorySizeToolStripMenuItem";
            commandsMemorySizeToolStripMenuItem.Size = new Size(312, 34);
            commandsMemorySizeToolStripMenuItem.Text = "Commands Memory size";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 1144);
            Controls.Add(InputLabel);
            Controls.Add(InputTextBox);
            Controls.Add(OutputLabel);
            Controls.Add(OutputTextBox);
            MinimumSize = new Size(800, 500);
            Name = "Form1";
            Text = "ShellRunner";
            MenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox OutputTextBox;
        private Label OutputLabel;
        private RichTextBox InputTextBox;
        private Label InputLabel;
        private ToolStripMenuItem oToolStripMenuItem;
        private ToolStripMenuItem commandsMemorySizeToolStripMenuItem;
        public ContextMenuStrip MenuStrip;
    }
}
