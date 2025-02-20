namespace hw3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CreateDatabase()
        {
            using (var db = new CountryContext.CountryContext())
            {
                var countries = db.Countries.ToList();
                string message = "Countries:\n";
                foreach (var country in countries)
                {
                    message += $"{country.Name} - {country.Capital}, {country.Population}\n";
                }

                MessageBox.Show(message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CreateDatabase();
        }
    }
}
