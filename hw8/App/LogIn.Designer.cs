namespace App
{
    partial class LogInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            buttonLogIn = new Button();
            buttonSignUp = new Button();
            SuspendLayout();
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(34, 36);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(257, 25);
            textBoxLogin.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(34, 87);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(257, 25);
            textBoxPassword.TabIndex = 1;
            // 
            // buttonLogIn
            // 
            buttonLogIn.Location = new Point(34, 139);
            buttonLogIn.Name = "buttonLogIn";
            buttonLogIn.Size = new Size(114, 26);
            buttonLogIn.TabIndex = 2;
            buttonLogIn.Text = "Log In";
            buttonLogIn.UseVisualStyleBackColor = true;
            buttonLogIn.Click += buttonLogIn_Click;
            // 
            // buttonSignUp
            // 
            buttonSignUp.Location = new Point(177, 139);
            buttonSignUp.Name = "buttonSignUp";
            buttonSignUp.Size = new Size(114, 26);
            buttonSignUp.TabIndex = 3;
            buttonSignUp.Text = "Sign Up";
            buttonSignUp.UseVisualStyleBackColor = true;
            buttonSignUp.Click += buttonSignUp_Click;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 199);
            Controls.Add(buttonSignUp);
            Controls.Add(buttonLogIn);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Font = new Font("Segoe UI", 10F);
            Name = "LogInForm";
            Text = "Form2";
            FormClosed += LogInForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button buttonLogIn;
        private Button buttonSignUp;
    }
}