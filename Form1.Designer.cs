namespace MTFRTexFix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            LogBox = new RichTextBox();
            PathBox = new TextBox();
            FolderButton = new Button();
            button2 = new Button();
            FolderDialog = new FolderBrowserDialog();
            button1 = new Button();
            button3 = new Button();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // LogBox
            // 
            LogBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogBox.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            LogBox.Location = new Point(12, 12);
            LogBox.Name = "LogBox";
            LogBox.ReadOnly = true;
            LogBox.Size = new Size(1120, 435);
            LogBox.TabIndex = 0;
            LogBox.Text = "";
            LogBox.WordWrap = false;
            LogBox.LinkClicked += LogBox_LinkClicked;
            LogBox.TextChanged += LogBox_TextChanged;
            // 
            // PathBox
            // 
            PathBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PathBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            PathBox.Location = new Point(12, 453);
            PathBox.Name = "PathBox";
            PathBox.ReadOnly = true;
            PathBox.Size = new Size(1120, 25);
            PathBox.TabIndex = 1;
            PathBox.TextChanged += PathBox_TextChanged;
            // 
            // FolderButton
            // 
            FolderButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FolderButton.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FolderButton.Location = new Point(12, 484);
            FolderButton.Name = "FolderButton";
            FolderButton.Size = new Size(203, 66);
            FolderButton.TabIndex = 2;
            FolderButton.Text = "Select Folder";
            FolderButton.UseVisualStyleBackColor = true;
            FolderButton.Click += FolderButton_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.Enabled = false;
            button2.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(639, 484);
            button2.Name = "button2";
            button2.Size = new Size(493, 66);
            button2.TabIndex = 3;
            button2.Text = "Fix!";
            toolTip1.SetToolTip(button2, "Edits all .TXT parameters to reflect your .DDS files");
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FolderDialog
            // 
            FolderDialog.SelectedPath = "C:\\";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Enabled = false;
            button1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(221, 484);
            button1.Name = "button1";
            button1.Size = new Size(203, 66);
            button1.TabIndex = 4;
            button1.Text = "Scan Files";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.Enabled = false;
            button3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(430, 484);
            button3.Name = "button3";
            button3.Size = new Size(203, 66);
            button3.TabIndex = 5;
            button3.Text = "Clear Log";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 500000;
            toolTip1.InitialDelay = 5;
            toolTip1.ReshowDelay = 100;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 561);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(FolderButton);
            Controls.Add(PathBox);
            Controls.Add(LogBox);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1160, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MTFWTF - MTFramework Text Fixer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox LogBox;
        private TextBox PathBox;
        private Button FolderButton;
        private Button button2;
        private FolderBrowserDialog FolderDialog;
        private Button button1;
        private Button button3;
        private ToolTip toolTip1;
    }
}