using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }
        private bool CheckLogin(string login)
        {
            using (var context = new Context.EmployeeDbContext())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }
        private bool AuthUser(string login, string password)
        {
            using (var context = new Context.EmployeeDbContext())
            {
                return context.Users.Any(u => u.Login == login && u.Password == password);
            }
        }
        private bool ValidateInputs(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Fields cannot be empty.", "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (!ValidateInputs(login, password))
            {
                return;
            }

            if (!CheckLogin(login))
            {
                DialogResult res = MessageBox.Show("User does not exist. Would you like to create a new account?","Error",
                                                      MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    AddUser(login, password);
                    MessageBox.Show("Account successfully created!", "Success", MessageBoxButtons.OK);
                }
            }
            else if (!AuthUser(login, password))
            {
                MessageBox.Show("Incorrect password", "Error", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK);
                this.Hide();

                AppForm appForm = new AppForm();
                appForm.Show();
            }
        }

        private void AddUser(string login, string password)
        {
            using (var context = new Context.EmployeeDbContext())
            {
                var newUser = new Model.User { Login = login, Password = password };
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (!ValidateInputs(login, password))
            {
                return;
            }
            if (CheckLogin(login))
            {
                MessageBox.Show("This login is already in use", "Error", MessageBoxButtons.OK);
            }
            else
            {
                AddUser(login, password);
                MessageBox.Show("Account successfully created", "Success", MessageBoxButtons.OK);
            }
        }

        private void LogInForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
