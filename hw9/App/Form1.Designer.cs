namespace App
{
    partial class AppForm
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
            listView1 = new ListView();
            comboBoxOptions = new ComboBox();
            buttonDisplay = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(480, 373);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // comboBoxOptions
            // 
            comboBoxOptions.FormattingEnabled = true;
            comboBoxOptions.Location = new Point(498, 12);
            comboBoxOptions.Name = "comboBoxOptions";
            comboBoxOptions.Size = new Size(179, 23);
            comboBoxOptions.TabIndex = 1;
            // 
            // buttonDisplay
            // 
            buttonDisplay.Location = new Point(552, 41);
            buttonDisplay.Name = "buttonDisplay";
            buttonDisplay.Size = new Size(75, 23);
            buttonDisplay.TabIndex = 2;
            buttonDisplay.Text = "Display";
            buttonDisplay.UseVisualStyleBackColor = true;
            buttonDisplay.Click += buttonDisplay_Click;
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 397);
            Controls.Add(buttonDisplay);
            Controls.Add(comboBoxOptions);
            Controls.Add(listView1);
            Name = "AppForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ComboBox comboBoxOptions;
        private Button buttonDisplay;
    }
}
