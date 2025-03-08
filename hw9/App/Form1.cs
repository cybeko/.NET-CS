using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App
{
    public partial class AppForm : Form
    {
        private Dictionary<int, string> optionsDictionary = new Dictionary<int, string>
        {
            { (int)Display.Subjects, "Subjects" },
            { (int)Display.Teachers, "Teachers" },
            { (int)Display.Curators, "Curators" },
            { (int)Display.Faculties, "Faculties" },
            { (int)Display.Departments, "Departments" },
            { (int)Display.Groups, "Groups" },

        };
        public enum Display
        {
            Subjects = 1,
            Teachers = 2,
            Curators = 3,
            Faculties = 4,
            Departments = 5,
            Groups = 6,
        }
        public AppForm()
        {
            InitializeComponent();
            CheckConnection();
            InitializeComboBoxSearchOptions();
        }
        public void CheckConnection()
        {
            try
            {
                using (var context = new AcademyDbContext())
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
                comboBoxOptions.Items.Add(option.Value);
            }
            comboBoxOptions.SelectedIndex = 0;
        }
        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            int selectedId = comboBoxOptions.SelectedIndex + 1;
            if (Enum.IsDefined(typeof(Display), selectedId))
            {
                Display option = (Display)selectedId;
                switch (option)
                {
                    case Display.Subjects:
                        DisplaySubjects();
                        break;
                    case Display.Teachers:
                        DisplayTeachers();
                        break;
                    case Display.Curators:
                        DisplayCurators();
                        break;
                    case Display.Faculties:
                        DisplayFaculties();
                        break;
                    case Display.Departments:
                        DisplayDepartments();
                        break;
                    case Display.Groups:
                        DisplayGroups();
                        break;
                    default:
                        MessageBox.Show("Invalid selection");
                        break;
                }
            }
        }

        private void DisplaySubjects()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Name", 100);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var context = new AcademyDbContext())
            {
                var subjects = context.Subjects.ToList();

                foreach (var subject in subjects)
                {
                    var item = new ListViewItem(subject.Id.ToString());
                    item.SubItems.Add(subject.Name);

                    listView1.Items.Add(item);
                }
            }
        }
        private void DisplayTeachers()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Surname", 100);
            listView1.Columns.Add("Salary", 80);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var context = new AcademyDbContext())
            {
                var teachers = context.Teachers.ToList();
                foreach (var teacher in teachers)
                {
                    var item = new ListViewItem(teacher.Id.ToString());
                    item.SubItems.Add(teacher.Name);
                    item.SubItems.Add(teacher.Surname);
                    item.SubItems.Add(teacher.Salary.ToString());

                    listView1.Items.Add(item);
                }
            }
        }
        private void DisplayCurators()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Surname", 100);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var context = new AcademyDbContext())
            {
                var curators = context.Curators.ToList();
                foreach (var curator in curators)
                {
                    var item = new ListViewItem(curator.Id.ToString());
                    item.SubItems.Add(curator.Name);
                    item.SubItems.Add(curator.Surname);

                    listView1.Items.Add(item);
                }
            }
        }
        private void DisplayFaculties()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Financing", 100);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var context = new AcademyDbContext())
            {
                var faculties = context.Faculties.ToList();
                foreach (var faculty in faculties)
                {
                    var item = new ListViewItem(faculty.Id.ToString());
                    item.SubItems.Add(faculty.Name);
                    item.SubItems.Add(faculty.Financing.ToString("C"));

                    listView1.Items.Add(item);
                }
            }
        }
        private void DisplayDepartments()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Financing", 100);
            listView1.Columns.Add("Faculty", 150); 
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var context = new AcademyDbContext())
            {
                var departments = context.Departments.Include(d => d.Faculty).ToList();

                foreach (var department in departments)
                {
                    var item = new ListViewItem(department.Id.ToString());
                    item.SubItems.Add(department.Name);
                    item.SubItems.Add(department.Financing.ToString("C"));
                    item.SubItems.Add(department.Faculty?.Name ?? "Unknown");

                    listView1.Items.Add(item);
                }
            }
        }
        private void DisplayGroups()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Year", 50);
            listView1.Columns.Add("Department", 150); 
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var context = new AcademyDbContext())
            {
                var groups = context.Groups.Include(g => g.Department).ToList();

                foreach (var group in groups)
                {
                    var item = new ListViewItem(group.Id.ToString());
                    item.SubItems.Add(group.Name);
                    item.SubItems.Add(group.Year.ToString());
                    item.SubItems.Add(group.Department?.Name ?? "Unknown");

                    listView1.Items.Add(item);
                }
            }
        }


    }
}
