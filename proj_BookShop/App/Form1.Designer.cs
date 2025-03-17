namespace App
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
            buttonConfirm = new Button();
            textBoxTitle = new TextBox();
            textBoxPageCount = new TextBox();
            comboBoxAuthor = new ComboBox();
            comboBoxPublisher = new ComboBox();
            textBoxYearOfPublication = new TextBox();
            textBoxCostPrice = new TextBox();
            textBoxSellingPrice = new TextBox();
            textBoxStockCount = new TextBox();
            textBoxSoldCount = new TextBox();
            textBoxIsWrittenOff = new TextBox();
            comboBoxSequel = new ComboBox();
            comboBoxGenre = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            comboBoxCustomer = new ComboBox();
            textBoxTotalPrice = new TextBox();
            numericUpDownAmount = new NumericUpDown();
            buttonSell = new Button();
            comboBoxSearchOption = new ComboBox();
            textBoxSearchInput = new TextBox();
            buttonSearch = new Button();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).BeginInit();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 59);
            listView1.Name = "listView1";
            listView1.Size = new Size(781, 434);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged_1;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // buttonConfirm
            // 
            buttonConfirm.Location = new Point(975, 308);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(75, 23);
            buttonConfirm.TabIndex = 1;
            buttonConfirm.Text = "Confirm";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(812, 59);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(196, 23);
            textBoxTitle.TabIndex = 2;
            // 
            // textBoxPageCount
            // 
            textBoxPageCount.Location = new Point(812, 103);
            textBoxPageCount.Name = "textBoxPageCount";
            textBoxPageCount.Size = new Size(196, 23);
            textBoxPageCount.TabIndex = 3;
            // 
            // comboBoxAuthor
            // 
            comboBoxAuthor.FormattingEnabled = true;
            comboBoxAuthor.Location = new Point(1024, 147);
            comboBoxAuthor.Name = "comboBoxAuthor";
            comboBoxAuthor.Size = new Size(196, 23);
            comboBoxAuthor.TabIndex = 4;
            // 
            // comboBoxPublisher
            // 
            comboBoxPublisher.FormattingEnabled = true;
            comboBoxPublisher.Location = new Point(1024, 191);
            comboBoxPublisher.Name = "comboBoxPublisher";
            comboBoxPublisher.Size = new Size(196, 23);
            comboBoxPublisher.TabIndex = 5;
            // 
            // textBoxYearOfPublication
            // 
            textBoxYearOfPublication.Location = new Point(812, 147);
            textBoxYearOfPublication.Name = "textBoxYearOfPublication";
            textBoxYearOfPublication.Size = new Size(196, 23);
            textBoxYearOfPublication.TabIndex = 3;
            // 
            // textBoxCostPrice
            // 
            textBoxCostPrice.Location = new Point(812, 191);
            textBoxCostPrice.Name = "textBoxCostPrice";
            textBoxCostPrice.Size = new Size(196, 23);
            textBoxCostPrice.TabIndex = 3;
            // 
            // textBoxSellingPrice
            // 
            textBoxSellingPrice.Location = new Point(812, 235);
            textBoxSellingPrice.Name = "textBoxSellingPrice";
            textBoxSellingPrice.Size = new Size(196, 23);
            textBoxSellingPrice.TabIndex = 3;
            // 
            // textBoxStockCount
            // 
            textBoxStockCount.Location = new Point(812, 279);
            textBoxStockCount.Name = "textBoxStockCount";
            textBoxStockCount.Size = new Size(196, 23);
            textBoxStockCount.TabIndex = 3;
            // 
            // textBoxSoldCount
            // 
            textBoxSoldCount.Location = new Point(1024, 59);
            textBoxSoldCount.Name = "textBoxSoldCount";
            textBoxSoldCount.Size = new Size(196, 23);
            textBoxSoldCount.TabIndex = 6;
            // 
            // textBoxIsWrittenOff
            // 
            textBoxIsWrittenOff.Location = new Point(1024, 103);
            textBoxIsWrittenOff.Name = "textBoxIsWrittenOff";
            textBoxIsWrittenOff.Size = new Size(196, 23);
            textBoxIsWrittenOff.TabIndex = 6;
            // 
            // comboBoxSequel
            // 
            comboBoxSequel.FormattingEnabled = true;
            comboBoxSequel.Location = new Point(1024, 235);
            comboBoxSequel.Name = "comboBoxSequel";
            comboBoxSequel.Size = new Size(196, 23);
            comboBoxSequel.TabIndex = 7;
            // 
            // comboBoxGenre
            // 
            comboBoxGenre.FormattingEnabled = true;
            comboBoxGenre.Location = new Point(1024, 279);
            comboBoxGenre.Name = "comboBoxGenre";
            comboBoxGenre.Size = new Size(196, 23);
            comboBoxGenre.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(812, 41);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 9;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(812, 85);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 10;
            label2.Text = "Page Count";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(812, 129);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 11;
            label3.Text = "Year of publication";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(812, 173);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 12;
            label4.Text = "Cost price";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(812, 217);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 13;
            label5.Text = "Selling price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(812, 261);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 14;
            label6.Text = "Stock count";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1024, 41);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 15;
            label7.Text = "Sold count";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1024, 85);
            label8.Name = "label8";
            label8.Size = new Size(73, 15);
            label8.TabIndex = 16;
            label8.Text = "Is written off";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1024, 129);
            label9.Name = "label9";
            label9.Size = new Size(44, 15);
            label9.TabIndex = 17;
            label9.Text = "Author";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1024, 173);
            label10.Name = "label10";
            label10.Size = new Size(56, 15);
            label10.TabIndex = 18;
            label10.Text = "Publisher";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1024, 217);
            label11.Name = "label11";
            label11.Size = new Size(42, 15);
            label11.TabIndex = 19;
            label11.Text = "Sequel";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(1024, 261);
            label12.Name = "label12";
            label12.Size = new Size(38, 15);
            label12.TabIndex = 20;
            label12.Text = "Genre";
            // 
            // comboBoxCustomer
            // 
            comboBoxCustomer.FormattingEnabled = true;
            comboBoxCustomer.Location = new Point(812, 353);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(196, 23);
            comboBoxCustomer.TabIndex = 22;
            // 
            // textBoxTotalPrice
            // 
            textBoxTotalPrice.Location = new Point(812, 441);
            textBoxTotalPrice.Name = "textBoxTotalPrice";
            textBoxTotalPrice.Size = new Size(196, 23);
            textBoxTotalPrice.TabIndex = 26;
            // 
            // numericUpDownAmount
            // 
            numericUpDownAmount.Location = new Point(812, 397);
            numericUpDownAmount.Name = "numericUpDownAmount";
            numericUpDownAmount.Size = new Size(196, 23);
            numericUpDownAmount.TabIndex = 28;
            numericUpDownAmount.ValueChanged += numericUpDownAmount_ValueChanged;
            // 
            // buttonSell
            // 
            buttonSell.Location = new Point(872, 470);
            buttonSell.Name = "buttonSell";
            buttonSell.Size = new Size(75, 23);
            buttonSell.TabIndex = 29;
            buttonSell.Text = "Sell";
            buttonSell.UseVisualStyleBackColor = true;
            buttonSell.Click += buttonSell_Click;
            // 
            // comboBoxSearchOption
            // 
            comboBoxSearchOption.FormattingEnabled = true;
            comboBoxSearchOption.Location = new Point(12, 31);
            comboBoxSearchOption.Name = "comboBoxSearchOption";
            comboBoxSearchOption.Size = new Size(196, 23);
            comboBoxSearchOption.TabIndex = 30;
            // 
            // textBoxSearchInput
            // 
            textBoxSearchInput.Location = new Point(214, 31);
            textBoxSearchInput.Name = "textBoxSearchInput";
            textBoxSearchInput.Size = new Size(196, 23);
            textBoxSearchInput.TabIndex = 31;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(416, 30);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 32;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(812, 335);
            label13.Name = "label13";
            label13.Size = new Size(59, 15);
            label13.TabIndex = 33;
            label13.Text = "Customer";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(812, 379);
            label14.Name = "label14";
            label14.Size = new Size(51, 15);
            label14.TabIndex = 33;
            label14.Text = "Amount";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(812, 423);
            label15.Name = "label15";
            label15.Size = new Size(61, 15);
            label15.TabIndex = 33;
            label15.Text = "Total Price";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(12, 13);
            label16.Name = "label16";
            label16.Size = new Size(82, 15);
            label16.TabIndex = 34;
            label16.Text = "Search Option";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(214, 13);
            label17.Name = "label17";
            label17.Size = new Size(73, 15);
            label17.TabIndex = 35;
            label17.Text = "Search Input";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 504);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxSearchInput);
            Controls.Add(comboBoxSearchOption);
            Controls.Add(buttonSell);
            Controls.Add(numericUpDownAmount);
            Controls.Add(textBoxTotalPrice);
            Controls.Add(comboBoxCustomer);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxGenre);
            Controls.Add(comboBoxSequel);
            Controls.Add(textBoxIsWrittenOff);
            Controls.Add(textBoxSoldCount);
            Controls.Add(comboBoxPublisher);
            Controls.Add(comboBoxAuthor);
            Controls.Add(textBoxStockCount);
            Controls.Add(textBoxSellingPrice);
            Controls.Add(textBoxCostPrice);
            Controls.Add(textBoxYearOfPublication);
            Controls.Add(textBoxPageCount);
            Controls.Add(textBoxTitle);
            Controls.Add(buttonConfirm);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button buttonConfirm;

        private TextBox textBoxTitle;
        private TextBox textBoxPageCount;
        private ComboBox comboBoxAuthor;
        private ComboBox comboBoxPublisher;
        private TextBox textBoxYearOfPublication;
        private TextBox textBoxCostPrice;
        private TextBox textBoxSellingPrice;
        private TextBox textBoxStockCount;

        private TextBox textBoxSoldCount;
        private TextBox textBoxIsWrittenOff;
        private ComboBox comboBoxSequel;
        private ComboBox comboBoxGenre;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;

        private ComboBox comboBoxCustomer;
        private TextBox textBoxTotalPrice;
        private NumericUpDown numericUpDownAmount;
        private Button buttonSell;

        private ComboBox comboBoxSearchOption;
        private TextBox textBoxSearchInput;
        private Button buttonSearch;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
    }
}
