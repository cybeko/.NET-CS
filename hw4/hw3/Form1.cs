using CountryModel;
using Microsoft.EntityFrameworkCore;

namespace hw3
{
    public partial class Form1 : Form
    {
        private bool isCountrySelected = false;
        public Form1()
        {
            InitializeComponent();
            LoadCountries();
            LoadContinents();
            UpdateButtonText();
            listBoxCountries.SelectedIndexChanged += listBoxCountries_SelectedIndexChanged;
        }

        private void LoadCountries()
        {
            using (var db = new CountryContext.CountryContext())
            {
                var countries = db.Countries.Include(c => c.Continent).ToList();
                listBoxCountries.Items.Clear();
                foreach (var country in countries)
                {
                    listBoxCountries.Items.Add($"{country.Name}, {country.Capital}, {country.Population}, {country.Continent.Name})");
                }
            }
        }
        private void LoadContinents()
        {
            using (var db = new CountryContext.CountryContext())
            {
                var continents = db.Continents.ToList();
                comboBoxContinent.Items.Clear();
                foreach (var continent in continents)
                {
                    comboBoxContinent.Items.Add(continent.Name);
                }
            }
        }
        private void listBoxCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountryText = listBoxCountries.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedCountryText))
            {
                using (var db = new CountryContext.CountryContext())
                {
                    string countryName = selectedCountryText.Split('-')[0].Trim();

                    var country = db.Countries.Include(c => c.Continent).FirstOrDefault(c => c.Name == countryName);

                    if (country != null)
                    {
                        textBoxCountry.Text = country.Name;
                        textBoxCapital.Text = country.Capital;
                        textBoxPopulation.Text = country.Population.ToString();
                        textBoxArea.Text = country.Area.ToString();

                        comboBoxContinent.SelectedItem = country.Continent?.Name;
                    }
                }

                isCountrySelected = true;
            }
            UpdateButtonText();
        }
        private void UpdateButtonText()
        {
            if (listBoxCountries.SelectedItem != null)
            {
                buttonSubmit.Text = "Update";
            }
            else
            {
                buttonSubmit.Text = "Add New";
            }
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            if (isCountrySelected)
            {
                listBoxCountries.ClearSelected();
                UpdateButtonText();
                ClearFields();
                isCountrySelected = false;
            }
        }
        private void ClearFields()
        {
            textBoxCountry.Clear();
            textBoxCapital.Clear();
            textBoxPopulation.Clear();
            textBoxArea.Clear();
            comboBoxContinent.SelectedItem = null;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string country = textBoxCountry.Text;
            string capital = textBoxCapital.Text;
            int population;
            double area;
            string continent = comboBoxContinent.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(capital) ||
                !int.TryParse(textBoxPopulation.Text, out population) ||
                !double.TryParse(textBoxArea.Text, out area) || string.IsNullOrEmpty(continent))
            {
                MessageBox.Show("Wrong data format.");
                return;
            }

            using (var db = new CountryContext.CountryContext())
            {
                if (listBoxCountries.SelectedItem != null)
                {
                    UpdateCountry(db, country, capital, population, area, continent);
                    MessageBox.Show("Country updated successfully.");
                }
                else
                {
                    AddCountry(db, country, capital, population, area, continent);
                    MessageBox.Show("Country added successfully.");
                }

                LoadCountries();
                ClearFields();
                buttonSubmit.Text = "Add New";
            }
        }

        private void AddCountry(CountryContext.CountryContext db, string countryName, string capital, int population, double area, string continentName)
        {
            var newCountry = new Country
            {
                Name = countryName,
                Capital = capital,
                Population = population,
                Area = area,
                Continent = db.Continents.FirstOrDefault(c => c.Name == continentName)
            };
            db.Countries.Add(newCountry);
            db.SaveChanges();
        }
        private void UpdateCountry(CountryContext.CountryContext db, string countryName, string capital, int population, double area, string continent)
        {
            string selectedCountryText = listBoxCountries.SelectedItem?.ToString();
            string selectedCountryName = selectedCountryText.Split('-')[0].Trim();

            var country = db.Countries.Include(c => c.Continent)
                                              .FirstOrDefault(c => c.Name == selectedCountryName);
            if (country != null)
            {
                country.Name = countryName;
                country.Capital = capital;
                country.Population = population;
                country.Area = area;
                country.Continent = db.Continents.FirstOrDefault(c => c.Name == continent);

                db.SaveChanges();
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxCountries.SelectedItem != null)
            {
                string selectedCountryText = listBoxCountries.SelectedItem?.ToString();
                string countryName = selectedCountryText.Split('-')[0].Trim();

                using (var db = new CountryContext.CountryContext())
                {
                    var countryToDelete = db.Countries.FirstOrDefault(c => c.Name == countryName);

                    if (countryToDelete != null)
                    {
                        db.Countries.Remove(countryToDelete); 
                        db.SaveChanges();

                        MessageBox.Show("Country deleted.");

                        LoadCountries();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Country not found.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a country to delete");
            }
        }

    }
}
