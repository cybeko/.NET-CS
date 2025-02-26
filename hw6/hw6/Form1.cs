using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hw6
{
    public partial class Form1 : Form
    {
        private Dictionary<int, string> optionsDictionary = new Dictionary<int, string>
        {
            { (int)Display.AllAuthors, "All authors" },
            { (int)Display.BooksAndAuthors, "Books and authors" },
            { (int)Display.StudentsAndGroups, "Students and groups" },
            { (int)Display.AllBooks, "All books" }
        };
        public enum Display
        {
            AllAuthors = 1,
            BooksAndAuthors = 2,
            StudentsAndGroups = 3,
            AllBooks = 4
        }

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            foreach (var option in optionsDictionary)
            {
                comboBoxChoice.Items.Add(option.Value);
            }

            comboBoxChoice.SelectedIndex = 0;
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            int selectedId = comboBoxChoice.SelectedIndex + 1;

            if (Enum.IsDefined(typeof(Display), selectedId))
            {
                Display option = (Display)selectedId;

                switch (option)
                {
                    case Display.AllAuthors:
                        LoadAuthors();
                        break;
                    case Display.BooksAndAuthors:
                        LoadBooksAndAuthors();
                        break;
                    case Display.StudentsAndGroups:
                        LoadStudentsAndGroups();
                        break;
                    case Display.AllBooks:
                        LoadBooks();
                        break;
                }
            }
        }
        private void LoadBooks()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Book Id", 50);
            listView1.Columns.Add("Book name", 200);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var context = new LibraryContext())
            {
                var books = context.Books.ToList();

                foreach (var book in books)
                {
                    ListViewItem item = new ListViewItem(book.Id.ToString());
                    item.SubItems.Add(book.Name);
                    listView1.Items.Add(item);
                }
            }
        }
        private void LoadAuthors()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 90);
            listView1.Columns.Add("Name", 300);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var context = new LibraryContext())
            {
                var authors = context.Authors.ToList();

                foreach (var author in authors)
                {
                    ListViewItem item = new ListViewItem(author.Id.ToString());
                    item.SubItems.Add(author.Name);
                    listView1.Items.Add(item);
                }
            }
        }

        private void LoadBooksAndAuthors()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Book Id", 50);
            listView1.Columns.Add("Book Name", 150);
            listView1.Columns.Add("Author", 150);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var context = new LibraryContext())
            {
                var booksWithAuthors = context.Temps.Where(t => t.BooksId != null && t.AuthorsId != null).Select(t => new
                    {
                        BookId = t.Books!.Id,
                        BookName = t.Books.Name,
                        AuthorName = t.Authors!.Name
                    }).ToList();

                foreach (var item in booksWithAuthors)
                {
                    ListViewItem listViewItem = new ListViewItem(item.BookId.ToString());
                    listViewItem.SubItems.Add(item.BookName);
                    listViewItem.SubItems.Add(item.AuthorName);
                    listView1.Items.Add(listViewItem);
                }
            }
        }

        private void LoadStudentsAndGroups()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Student Id", 80);
            listView1.Columns.Add("Student name", 150);
            listView1.Columns.Add("Age", 50);
            listView1.Columns.Add("Group", 100);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var context = new LibraryContext())
            {
                var studentsWithGroups = context.Students
                    .Select(s => new
                    {
                        StudentId = s.Id,
                        StudentName = s.Name,
                        Age = s.Age ?? 0,
                        GroupName = s.IdGroupsNavigation != null ? s.IdGroupsNavigation.Name : "No group"
                    })
                    .ToList();

                foreach (var student in studentsWithGroups)
                {
                    ListViewItem item = new ListViewItem(student.StudentId.ToString());
                    item.SubItems.Add(student.StudentName);
                    item.SubItems.Add(student.Age.ToString());
                    item.SubItems.Add(student.GroupName);
                    listView1.Items.Add(item);
                }
            }
        }
        
    }
}
