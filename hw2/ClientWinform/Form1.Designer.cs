namespace ClientWinform
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
            textBoxChat = new TextBox();
            textBoxMessage = new TextBox();
            buttonSend = new Button();
            SuspendLayout();
            // 
            // textBoxChat
            // 
            textBoxChat.Location = new Point(12, 12);
            textBoxChat.Multiline = true;
            textBoxChat.Name = "textBoxChat";
            textBoxChat.ReadOnly = true;
            textBoxChat.Size = new Size(346, 377);
            textBoxChat.TabIndex = 0;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(12, 402);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(250, 23);
            textBoxMessage.TabIndex = 1;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(268, 402);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(90, 23);
            buttonSend.TabIndex = 2;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 437);
            Controls.Add(buttonSend);
            Controls.Add(textBoxMessage);
            Controls.Add(textBoxChat);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxChat;
        private TextBox textBoxMessage;
        private Button buttonSend;
    }
}
