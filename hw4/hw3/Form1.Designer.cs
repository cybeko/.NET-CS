namespace hw3
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
            listBoxCountries = new ListBox();
            textBoxCountry = new TextBox();
            textBoxCapital = new TextBox();
            textBoxPopulation = new TextBox();
            textBoxArea = new TextBox();
            buttonSubmit = new Button();
            comboBoxContinent = new ComboBox();
            buttonDelete = new Button();
            SuspendLayout();
            // 
            // listBoxCountries
            // 
            listBoxCountries.FormattingEnabled = true;
            listBoxCountries.ItemHeight = 15;
            listBoxCountries.Location = new Point(12, 12);
            listBoxCountries.Name = "listBoxCountries";
            listBoxCountries.Size = new Size(304, 394);
            listBoxCountries.TabIndex = 1;
            // 
            // textBoxCountry
            // 
            textBoxCountry.Location = new Point(340, 25);
            textBoxCountry.Name = "textBoxCountry";
            textBoxCountry.Size = new Size(153, 23);
            textBoxCountry.TabIndex = 2;
            // 
            // textBoxCapital
            // 
            textBoxCapital.Location = new Point(340, 67);
            textBoxCapital.Name = "textBoxCapital";
            textBoxCapital.Size = new Size(153, 23);
            textBoxCapital.TabIndex = 3;
            // 
            // textBoxPopulation
            // 
            textBoxPopulation.Location = new Point(340, 107);
            textBoxPopulation.Name = "textBoxPopulation";
            textBoxPopulation.Size = new Size(153, 23);
            textBoxPopulation.TabIndex = 4;
            // 
            // textBoxArea
            // 
            textBoxArea.Location = new Point(340, 147);
            textBoxArea.Name = "textBoxArea";
            textBoxArea.Size = new Size(153, 23);
            textBoxArea.TabIndex = 5;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(384, 224);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(75, 30);
            buttonSubmit.TabIndex = 6;
            buttonSubmit.Text = "Submit";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // comboBoxContinent
            // 
            comboBoxContinent.FormattingEnabled = true;
            comboBoxContinent.Location = new Point(340, 186);
            comboBoxContinent.Name = "comboBoxContinent";
            comboBoxContinent.Size = new Size(153, 23);
            comboBoxContinent.TabIndex = 7;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(384, 269);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 30);
            buttonDelete.TabIndex = 8;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 416);
            Controls.Add(buttonDelete);
            Controls.Add(comboBoxContinent);
            Controls.Add(buttonSubmit);
            Controls.Add(textBoxArea);
            Controls.Add(textBoxPopulation);
            Controls.Add(textBoxCapital);
            Controls.Add(textBoxCountry);
            Controls.Add(listBoxCountries);
            Name = "Form1";
            Text = "Form1";
            Click += Form1_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBoxCountries;
        private TextBox textBoxCountry;
        private TextBox textBoxCapital;
        private TextBox textBoxPopulation;
        private TextBox textBoxArea;
        private Button buttonSubmit;
        private ComboBox comboBoxContinent;
        private Button buttonDelete;
    }
}
