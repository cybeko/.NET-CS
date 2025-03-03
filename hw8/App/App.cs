using Context;
using Microsoft.EntityFrameworkCore;
using Model;

namespace App
{
    public partial class AppForm : Form
    {
        private Logger logger = new Logger();
        private Dictionary<int, string> optionsDictionary = new Dictionary<int, string>
        {
            { (int)Display.ByFirstName, "First Name" },
            { (int)Display.ByLastName, "Last Name" },
            { (int)Display.ByPosition, "Position" },
        };
        public enum Display
        {
            ByFirstName = 1,
            ByLastName = 2,
            ByPosition = 3,
        }
        public AppForm()
        {
            InitializeComponent();
            EnsureDbCreated();
            InitializeComboBoxSearchOptions();
            InitializeComboBoxPositions();
            DisplayAllEmployees();
        }
        public void EnsureDbCreated()
        {
            try
            {
                using (var context = new EmployeeDbContext())
                {
                    context.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing database: {ex.Message}");
            }
        }
        public void InitializeComboBoxSearchOptions()
        {
            foreach (var option in optionsDictionary)
            {
                comboBoxSearchOption.Items.Add(option.Value);
            }
            comboBoxSearchOption.SelectedIndex = 0;
        }
        public void InitializeComboBoxPositions()
        {
            using (var context = new EmployeeDbContext())
            {
                var positions = context.Positions.ToList();

                comboBoxPosition.Items.Clear();

                foreach (var position in positions)
                {
                    comboBoxPosition.Items.Add(position.Name);
                }
                comboBoxPosition.SelectedIndex = 0;
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int selectedId = comboBoxSearchOption.SelectedIndex + 1;
            if (Enum.IsDefined(typeof(Display), selectedId))
            {
                string text = textBoxSearchInput.Text.Trim();
                Display option = (Display)selectedId;
                string criteria = optionsDictionary[selectedId];
                logger.LogSearched(criteria, text);
                switch (option)
                {
                    case Display.ByFirstName:
                        DisplayByFirstName(text);
                        break;
                    case Display.ByLastName:
                        DisplayByLastName(text);
                        break;
                    case Display.ByPosition:
                        DisplayByPosition(text);
                        break;
                    default:
                        MessageBox.Show("Invalid selection");
                        break;
                }
            }
        }
        private void DisplayAllEmployees()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("FirstName", 100);
            listView1.Columns.Add("LastName", 100);
            listView1.Columns.Add("Position", 150);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var context = new EmployeeDbContext())
            {
                var employees = context.Employees.Include(e => e.Position).ToList();

                foreach (var employee in employees)
                {
                    var item = new ListViewItem(employee.Id.ToString());
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.LastName);
                    item.SubItems.Add(employee.Position.Name);

                    listView1.Items.Add(item);
                }
            }
        }
        private void DisplayByFirstName(string firstName)
        {
            listView1.Items.Clear();

            using (var context = new EmployeeDbContext())
            {
                var employees = context.Employees.Include(e => e.Position).Where(e => e.FirstName.Contains(firstName)).ToList();

                foreach (var employee in employees)
                {
                    var item = new ListViewItem(employee.Id.ToString());
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.LastName);
                    item.SubItems.Add(employee.Position.Name);

                    listView1.Items.Add(item);
                }
            }
        }
        private void DisplayByLastName(string lastName)
        {
            listView1.Items.Clear();

            using (var context = new EmployeeDbContext())
            {
                var employees = context.Employees.Include(e => e.Position).Where(e => e.LastName.Contains(lastName)).ToList();

                foreach (var employee in employees)
                {
                    var item = new ListViewItem(employee.Id.ToString());
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.LastName);
                    item.SubItems.Add(employee.Position.Name);

                    listView1.Items.Add(item);
                }
            }
        }
        private void DisplayByPosition(string positionName)
        {
            listView1.Items.Clear();

            using (var context = new EmployeeDbContext())
            {
                var employees = context.Employees.Include(e => e.Position).Where(e => e.Position.Name.Contains(positionName)).ToList();
                foreach (var employee in employees)
                {
                    var item = new ListViewItem(employee.Id.ToString());
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.LastName);
                    item.SubItems.Add(employee.Position.Name);

                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                int employeeId = int.Parse(selectedItem.Text);

                var res = MessageBox.Show("Are you sure you want to delete this employee?", "Delete", MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {
                    DeleteEmployee(employeeId);
                    DisplayAllEmployees();
                }
            }
        }
        private void DeleteEmployee(int employeeId)
        {
            using (var context = new EmployeeDbContext())
            {
                var employee = context.Employees.Find(employeeId);

                if (employee != null)
                {
                    logger.LogDeleted(employee.FirstName, employee.LastName);
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Employee not found");
                }
            }
        }
        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text.Trim();
            string lastName = textBoxLastName.Text.Trim();
            string positionName = comboBoxPosition.SelectedItem.ToString();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || positionName == "Select Position")
            {
                MessageBox.Show("Fill in all fields and select a position");
                return;
            }
            Position position;
            using (var context = new EmployeeDbContext())
            {
                position = context.Positions.FirstOrDefault(p => p.Name == positionName);

                if (position == null)
                {
                    MessageBox.Show("Position not found");
                    return;
                }
                var newEmployee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PositionId = position.Id
                };
                context.Employees.Add(newEmployee);
                context.SaveChanges();
                logger.LogAdded(firstName, lastName);
            }

            DisplayAllEmployees();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            comboBoxPosition.SelectedIndex = 0;
        }

        private void AppForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
