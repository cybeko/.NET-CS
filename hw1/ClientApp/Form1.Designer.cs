namespace ClientApp
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
            textBoxMessage = new TextBox();
            buttonSend = new Button();
            textBoxServerResponse = new TextBox();
            SuspendLayout();
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(12, 415);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(274, 23);
            textBoxMessage.TabIndex = 0;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(292, 414);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(100, 23);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // textBoxServerResponse
            // 
            textBoxServerResponse.Location = new Point(12, 12);
            textBoxServerResponse.Multiline = true;
            textBoxServerResponse.Name = "textBoxServerResponse";
            textBoxServerResponse.Size = new Size(380, 397);
            textBoxServerResponse.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 450);
            Controls.Add(textBoxServerResponse);
            Controls.Add(buttonSend);
            Controls.Add(textBoxMessage);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxMessage;
        private Button buttonSend;
        private TextBox textBoxServerResponse;
    }
}
