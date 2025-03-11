using Dapper;
using Microsoft.Data.SqlClient;

namespace App
{
    public partial class FormApp : Form
    {
        const string connectionString = "Server=DESKTOP-N69P0E7;Database=CustomerDb;Integrated Security=SSPI;TrustServerCertificate=true";

        private Dictionary<int, string> optionsDictionary = new Dictionary<int, string>
        {
            { (int)Display.AllCustomers, "All customers" },
            { (int)Display.EmailsAndCustomers, "Emails and customers" },
            { (int)Display.AllCategories, "All categories" },
            { (int)Display.AllPromotions, "All promotions" },
            { (int)Display.AllCountries, "All countries" },
            { (int)Display.CustomersFromCountry, "All customers from a selected country" },
            { (int)Display.PromotionsForCountry, "All promotions for a selected country" }
        };
        public enum Display
        {
            AllCustomers = 1,
            EmailsAndCustomers = 2,
            AllCategories = 3,
            AllPromotions = 4,
            AllCountries = 5,
            CustomersFromCountry = 6,
            PromotionsForCountry = 7,
        }
        public FormApp()
        {
            InitializeComponent();
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {
            foreach (var option in optionsDictionary)
            {
                comboBoxOption.Items.Add(option.Value);
            }

            comboBoxOption.SelectedIndex = 0;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            int selectedId = comboBoxOption.SelectedIndex + 1;

            if (Enum.IsDefined(typeof(Display), selectedId))
            {
                Display option = (Display)selectedId;

                switch (option)
                {
                    case Display.AllCountries:
                        GetAllCountries();
                        break;
                    case Display.AllCustomers:
                        GetAllCustomers();
                        break;
                    case Display.AllPromotions:
                        GetAllPromotions();
                        break;
                    case Display.AllCategories:
                        GetAllCategories();
                        break;
                    case Display.EmailsAndCustomers:
                        GetEmailsAndCustomers();
                        break;
                    case Display.CustomersFromCountry:
                        GetCustomersFromCountry(textBox.Text.Trim());
                        break;
                    case Display.PromotionsForCountry:
                        GetPromotionsForCountry(textBox.Text.Trim());
                        break;
                    default:
                        MessageBox.Show("Error");
                        break;
                }
            }
        }
        private void GetCustomersFromCountry(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
            {
                MessageBox.Show("Field cannot be empty");
                return;
            }

            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Name", 200);
            listView1.Columns.Add("Email", 200);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT c.Id, c.FullName, c.Email 
                FROM Customers c
                INNER JOIN Countries co ON c.CountryId = co.Id
                WHERE LOWER(co.Name) = @CountryName";

                var customers = connection.Query(query, new { CountryName = countryName.ToLower() });

                if (customers.Any())
                {
                    foreach (var customer in customers)
                    {
                        ListViewItem item = new ListViewItem(customer.Id.ToString());
                        item.SubItems.Add(customer.FullName);
                        item.SubItems.Add(customer.Email);
                        listView1.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("No customers found for this country");
                }
            }
        }

        private void GetPromotionsForCountry(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
            {
                MessageBox.Show("Field cannot be empty");
                return;
            }

            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Name", 200);
            listView1.Columns.Add("Start date", 100);
            listView1.Columns.Add("End date", 100);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT p.Id, p.Name, p.StartDate, p.EndDate 
                FROM Promotion p
                INNER JOIN Countries co ON p.CountryId = co.Id
                WHERE LOWER(co.Name) = @CountryName";

                var promotions = connection.Query(query, new { CountryName = countryName.ToLower() });

                if (promotions.Any())
                {
                    foreach (var promotion in promotions)
                    {
                        ListViewItem item = new ListViewItem(promotion.Id.ToString());
                        item.SubItems.Add(promotion.Name);
                        item.SubItems.Add(((DateTime)promotion.StartDate).ToShortDateString());
                        item.SubItems.Add(((DateTime)promotion.EndDate).ToShortDateString());
                        listView1.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("No promotions found for this country");
                }
            }
        }


        private void GetEmailsAndCustomers()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Email", 200);
            listView1.Columns.Add("Customer", 200);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Email, FullName FROM Customers";
                var customers = connection.Query(query);

                foreach (var customer in customers)
                {
                    ListViewItem item = new ListViewItem(customer.Email);
                    item.SubItems.Add(customer.FullName);
                    listView1.Items.Add(item);
                }
            }
        }

        private void GetAllCategories()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Name", 200);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Categories";
                var categories = connection.Query(query);

                foreach (var category in categories)
                {
                    ListViewItem item = new ListViewItem(category.Id.ToString());
                    item.SubItems.Add(category.Name);
                    listView1.Items.Add(item);
                }
            }
        }


        private void GetAllPromotions()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Name", 200);
            listView1.Columns.Add("Category", 100);
            listView1.Columns.Add("Country", 100);
            listView1.Columns.Add("Start date", 100);
            listView1.Columns.Add("End date", 100);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT p.Id, p.Name, c.Name AS Category, co.Name AS Country, p.StartDate, p.EndDate
                FROM Promotion p
                INNER JOIN Categories c ON p.CategoryId = c.Id
                INNER JOIN Countries co ON p.CountryId = co.Id";

                var promotions = connection.Query(query);

                foreach (var promotion in promotions)
                {
                    ListViewItem item = new ListViewItem(promotion.Id.ToString());
                    item.SubItems.Add(promotion.Name);
                    item.SubItems.Add(promotion.Category);
                    item.SubItems.Add(promotion.Country);
                    item.SubItems.Add(((DateTime)promotion.StartDate).ToShortDateString());
                    item.SubItems.Add(((DateTime)promotion.EndDate).ToShortDateString());
                    listView1.Items.Add(item);
                }
            }
        }
        private void GetAllCountries()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Name", 200);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Countries";
                var countries = connection.Query(query);

                foreach (var country in countries)
                {
                    ListViewItem item = new ListViewItem(country.Id.ToString());
                    item.SubItems.Add(country.Name);
                    listView1.Items.Add(item);
                }
            }
        }

        private void GetAllCustomers()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Full name", 200);
            listView1.Columns.Add("Birth date", 100);
            listView1.Columns.Add("Gender", 100);
            listView1.Columns.Add("Email", 200);
            listView1.Columns.Add("Country", 150);

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT c.Id, c.FullName, c.BirthDate, c.Gender, c.Email, co.Name AS Country 
                FROM Customers c
                INNER JOIN Countries co ON c.CountryId = co.Id";

                var customers = connection.Query(query);

                foreach (var customer in customers)
                {
                    ListViewItem item = new ListViewItem(customer.Id.ToString());
                    item.SubItems.Add(customer.FullName);
                    item.SubItems.Add(((DateTime)customer.BirthDate).ToShortDateString());
                    item.SubItems.Add(customer.Gender);
                    item.SubItems.Add(customer.Email);
                    item.SubItems.Add(customer.Country);
                    listView1.Items.Add(item);
                }
            }
        }

    }
}
