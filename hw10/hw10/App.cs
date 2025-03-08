using Context;

namespace hw10
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
            EnsureDbCreated();
        }
        public void EnsureDbCreated()
        {
            try
            {
                using (var context = new EmployeeDbContext())
                {
                    context.Database.EnsureCreated();
                    MessageBox.Show($"Db is initialized");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing database: {ex.Message}");
            }
        }
    }
}
