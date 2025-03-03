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
            comboBoxSearchOption = new ComboBox();
            buttonSearch = new Button();
            textBoxSearchInput = new TextBox();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            comboBoxPosition = new ComboBox();
            buttonAddEmployee = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(429, 398);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            // 
            // comboBoxSearchOption
            // 
            comboBoxSearchOption.FormattingEnabled = true;
            comboBoxSearchOption.Location = new Point(528, 42);
            comboBoxSearchOption.Name = "comboBoxSearchOption";
            comboBoxSearchOption.Size = new Size(151, 23);
            comboBoxSearchOption.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(447, 41);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // textBoxSearchInput
            // 
            textBoxSearchInput.Location = new Point(447, 12);
            textBoxSearchInput.Name = "textBoxSearchInput";
            textBoxSearchInput.Size = new Size(232, 23);
            textBoxSearchInput.TabIndex = 3;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(447, 116);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(232, 23);
            textBoxFirstName.TabIndex = 4;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(447, 160);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(232, 23);
            textBoxLastName.TabIndex = 5;
            // 
            // comboBoxPosition
            // 
            comboBoxPosition.FormattingEnabled = true;
            comboBoxPosition.Location = new Point(447, 204);
            comboBoxPosition.Name = "comboBoxPosition";
            comboBoxPosition.Size = new Size(232, 23);
            comboBoxPosition.TabIndex = 6;
            // 
            // buttonAddEmployee
            // 
            buttonAddEmployee.Location = new Point(528, 243);
            buttonAddEmployee.Name = "buttonAddEmployee";
            buttonAddEmployee.Size = new Size(75, 23);
            buttonAddEmployee.TabIndex = 7;
            buttonAddEmployee.Text = "Add";
            buttonAddEmployee.UseVisualStyleBackColor = true;
            buttonAddEmployee.Click += buttonAddEmployee_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(447, 98);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 8;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(447, 142);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 9;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(447, 186);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 10;
            label3.Text = "Position";
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 422);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonAddEmployee);
            Controls.Add(comboBoxPosition);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirstName);
            Controls.Add(textBoxSearchInput);
            Controls.Add(buttonSearch);
            Controls.Add(comboBoxSearchOption);
            Controls.Add(listView1);
            Name = "AppForm";
            Text = "Form1";
            FormClosed += AppForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ComboBox comboBoxSearchOption;
        private Button buttonSearch;
        private TextBox textBoxSearchInput;

        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private ComboBox comboBoxPosition;
        private Button buttonAddEmployee;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
