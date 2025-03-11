namespace App
{
    partial class FormApp
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
            buttonConnect = new Button();
            comboBoxOption = new ComboBox();
            buttonSelect = new Button();
            listView1 = new ListView();
            textBox = new TextBox();
            SuspendLayout();
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(248, 12);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(142, 23);
            buttonConnect.TabIndex = 0;
            buttonConnect.Text = "Check Connection";
            buttonConnect.UseVisualStyleBackColor = true;
            //buttonConnect.Click += buttonConnect_Click;
            // 
            // comboBoxOption
            // 
            comboBoxOption.FormattingEnabled = true;
            comboBoxOption.Location = new Point(184, 41);
            comboBoxOption.Name = "comboBoxOption";
            comboBoxOption.Size = new Size(252, 23);
            comboBoxOption.TabIndex = 1;
            // 
            // buttonSelect
            // 
            buttonSelect.Location = new Point(442, 40);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(75, 23);
            buttonSelect.TabIndex = 2;
            buttonSelect.Text = "Select";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += buttonSelect_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 99);
            listView1.Name = "listView1";
            listView1.Size = new Size(609, 381);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // textBox
            // 
            textBox.Location = new Point(184, 70);
            textBox.Name = "textBox";
            textBox.Size = new Size(252, 23);
            textBox.TabIndex = 4;
            // 
            // FormApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 492);
            Controls.Add(textBox);
            Controls.Add(listView1);
            Controls.Add(buttonSelect);
            Controls.Add(comboBoxOption);
            Controls.Add(buttonConnect);
            Name = "FormApp";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonConnect;
        private ComboBox comboBoxOption;
        private Button buttonSelect;
        private ListView listView1;
        private TextBox textBox;
    }
}
