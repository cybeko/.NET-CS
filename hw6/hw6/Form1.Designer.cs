namespace hw6
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
            listView1 = new ListView();
            comboBoxChoice = new ComboBox();
            buttonLoad = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(412, 363);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // comboBoxChoice
            // 
            comboBoxChoice.FormattingEnabled = true;
            comboBoxChoice.Location = new Point(12, 381);
            comboBoxChoice.Name = "comboBoxChoice";
            comboBoxChoice.Size = new Size(290, 23);
            comboBoxChoice.TabIndex = 1;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(308, 381);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(116, 23);
            buttonLoad.TabIndex = 2;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 416);
            Controls.Add(buttonLoad);
            Controls.Add(comboBoxChoice);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ComboBox comboBoxChoice;
        private Button buttonLoad;
    }
}
