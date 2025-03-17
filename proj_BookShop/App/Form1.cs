using BookShopDb;
using Microsoft.EntityFrameworkCore;
using Model;

namespace App
{
    public partial class Form1 : Form
    {
        bool isBookSelected = false;
        private Dictionary<int, string> optionsDictionary = new Dictionary<int, string>
        {
            { (int)Display.AllBooks, "All books" },
            { (int)Display.BookName, "Book name" },
            { (int)Display.BooksByAuthor, "By author" },
            { (int)Display.BooksByGenre, "By genre" },
            { (int)Display.MostSoldBooks, "Most sold books" },
            { (int)Display.MostSoldAuthors, "Most sold authors" },
            { (int)Display.MostSoldGenres, "Most sold genres" }
        };
        public enum Display
        {
            AllBooks = 1,
            BookName = 2,
            BooksByAuthor = 3,
            BooksByGenre = 4,
            MostSoldBooks = 5,
            MostSoldAuthors = 6,
            MostSoldGenres = 7,
        }
        public Form1()
        {
            InitializeComponent();
            CheckConnection();
            DisplayAllBooks();
            UpdateButton();
            PopulateComboBoxes();
            ClearFields();
            PopulateComboBoxSearchOptions();
            comboBoxSearchOption.SelectedIndex = 0;
            numericUpDownAmount.Value = 1;
            numericUpDownAmount.Minimum = 1;
            this.Click += new EventHandler(Form_Click);
        }
        private void PopulateListView(List<Book> books)
        {
            foreach (var book in books)
            {
                ListViewItem item = new ListViewItem(book.Id.ToString());
                item.SubItems.Add(book.Title);
                item.SubItems.Add(book.PageCount.ToString());
                item.SubItems.Add(book.YearOfPublication.ToString());
                item.SubItems.Add(book.SellingPrice.ToString("C"));
                item.SubItems.Add(book.StockCount.ToString());
                item.SubItems.Add(book.SoldCount.ToString());
                item.SubItems.Add(book.IsWrittenOff ? "Yes" : "No");
                item.SubItems.Add(book.Publisher.Name);

                listView1.Items.Add(item);
            }
        }
        private void PopulateComboBoxSearchOptions()
        {
            foreach (var option in optionsDictionary)
            {
                comboBoxSearchOption.Items.Add(option.Value);
            }
        }
        private void PopulateComboBoxes()
        {
            using (var context = new BookShopDb.BookShopDbContext())
            {
                var authors = context.Authors.ToList();
                comboBoxAuthor.DisplayMember = "FullName";
                comboBoxAuthor.ValueMember = "Id";
                comboBoxAuthor.DataSource = authors.Select(a => new { FullName = $"{a.FirstName} {a.LastName}", a.Id }).ToList();

                var publishers = context.Publishers.ToList();
                comboBoxPublisher.DisplayMember = "Name";
                comboBoxPublisher.ValueMember = "Id";
                comboBoxPublisher.DataSource = publishers.Select(p => new { p.Name, p.Id }).ToList();

                var genres = context.Genres.ToList();
                comboBoxGenre.DisplayMember = "Name";
                comboBoxGenre.ValueMember = "Id";
                comboBoxGenre.DataSource = genres.Select(g => new { g.Name, g.Id }).ToList();
                comboBoxGenre.SelectedIndex = -1;

                var customers = context.Customers.ToList();
                comboBoxCustomer.DisplayMember = "FullName";
                comboBoxCustomer.ValueMember = "Id";
                comboBoxCustomer.DataSource = customers
                    .Select(c => new { FullName = $"{c.FirstName} {c.LastName}", c.Id })
                    .ToList();
            }
            PopulateComboBoxSequel();
        }
        private void SetupListViewForBooks()
        {
            listView1.Columns.Clear();

            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Title", 100);
            listView1.Columns.Add("Page Count", 80);
            listView1.Columns.Add("Year", 70);
            listView1.Columns.Add("Selling Price", 80);
            listView1.Columns.Add("In Stock", 80);
            listView1.Columns.Add("Sold Count", 80);
            listView1.Columns.Add("Written Off", 80);
            listView1.Columns.Add("Publisher", 150);

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();
        }
        private void SetupListViewForAuthorsAndGenres()
        {
            listView1.Columns.Clear();

            listView1.Columns.Add("Name", 200);
            listView1.Columns.Add("Sold Count", 80);

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();
        }
        public void CheckConnection()
        {
            using (var db = new BookShopDb.BookShopDbContext())
            {
                if (!db.Database.CanConnect())
                {
                    MessageBox.Show("Couldn't connect to the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void DisplayAllBooks()
        {
            SetupListViewForBooks();

            using (var context = new BookShopDbContext())
            {
                var books = context.Books.Include(b => b.Publisher).ToList();

                foreach (var book in books)
                {
                    ListViewItem item = new ListViewItem(book.Id.ToString());
                    item.SubItems.Add(book.Title);
                    item.SubItems.Add(book.PageCount.ToString());
                    item.SubItems.Add(book.YearOfPublication.ToString());
                    item.SubItems.Add(book.SellingPrice.ToString("C"));
                    item.SubItems.Add(book.StockCount.ToString());
                    item.SubItems.Add(book.SoldCount.ToString());
                    item.SubItems.Add(book.IsWrittenOff ? "Yes" : "No");
                    item.SubItems.Add(book.Publisher.Name);

                    listView1.Items.Add(item);
                }
            }
        }
        private bool IsSearchFieldEmpty(string message)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearchInput.Text))
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        private void SearchBooksByTitle(string title)
        {
            SetupListViewForBooks();
            listView1.Items.Clear();

            using (var context = new BookShopDbContext())
            {
                var books = context.Books
                                   .Include(b => b.Publisher)
                                   .Where(b => b.Title.Contains(title))
                                   .ToList();

                PopulateListView(books);
            }
        }
        private void SearchBooksByAuthor(string authorName)
        {
            SetupListViewForBooks();
            listView1.Items.Clear();

            using (var context = new BookShopDbContext())
            {
                var books = context.Books
                                   .Include(b => b.Publisher)
                                   .Include(b => b.Author)
                                   .Where(b => (b.Author.FirstName + " " + b.Author.LastName).Contains(authorName))
                                   .ToList();

                PopulateListView(books);
            }
        }
        private void SearchBooksByGenre(string genreName)
        {
            SetupListViewForBooks();
            listView1.Items.Clear();

            using (var context = new BookShopDbContext())
            {
                var books = context.Books
                                   .Include(b => b.Publisher)
                                   .Include(b => b.Genre)
                                   .Where(b => b.Genre.Name.Contains(genreName))
                                   .ToList();

                PopulateListView(books);
            }
        }
        private void DisplayMostSoldBooks()
        {
            SetupListViewForBooks();
            listView1.Items.Clear();

            using (var context = new BookShopDbContext())
            {
                var books = context.Books
                                   .Include(b => b.Publisher)
                                   .OrderByDescending(b => b.SoldCount)
                                   .Take(10)
                                   .ToList();

                PopulateListView(books);
            }
        }
        private void DisplayMostSoldGenres()
        {
            SetupListViewForAuthorsAndGenres();
            listView1.Items.Clear();

            using (var context = new BookShopDbContext())
            {
                var genresSales = context.Genres
                    .Select(g => new
                    {
                        GenreName = g.Name,
                        TotalSold = g.Books.Sum(b => b.SoldCount)
                    })
                    .OrderByDescending(g => g.TotalSold)
                    .ToList();

                foreach (var genreSales in genresSales)
                {
                    ListViewItem item = new ListViewItem(genreSales.GenreName);
                    item.SubItems.Add(genreSales.TotalSold.ToString());
                    listView1.Items.Add(item);
                }
            }
        }
        private void DisplayMostSoldAuthors()
        {
            SetupListViewForAuthorsAndGenres();
            listView1.Items.Clear();

            using (var context = new BookShopDbContext())
            {
                var authorsSales = context.Authors
                    .Select(a => new
                    {
                        AuthorName = a.FirstName + " " + a.LastName,
                        TotalSold = a.Books.Sum(b => b.SoldCount)
                    })
                    .OrderByDescending(a => a.TotalSold)
                    .ToList();

                foreach (var authorSales in authorsSales)
                {
                    ListViewItem item = new ListViewItem(authorSales.AuthorName);
                    item.SubItems.Add(authorSales.TotalSold.ToString());
                    listView1.Items.Add(item);
                }
            }
        }
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                isBookSelected = true;
                var selectedItem = listView1.SelectedItems[0];
                int bookId = int.Parse(selectedItem.SubItems[0].Text);

                using (var context = new BookShopDbContext())
                {
                    var book = context.Books.Include(b => b.Publisher)
                                            .Include(b => b.Author)
                                            .Include(b => b.Sequel)
                                            .Include(b => b.Genre)
                                            .FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        textBoxTitle.Text = book.Title;
                        textBoxPageCount.Text = book.PageCount.ToString();
                        textBoxYearOfPublication.Text = book.YearOfPublication.ToString();
                        textBoxCostPrice.Text = book.CostPrice.ToString("F2");
                        textBoxSellingPrice.Text = book.SellingPrice.ToString("F2");
                        textBoxStockCount.Text = book.StockCount.ToString();
                        textBoxSoldCount.Text = book.SoldCount.ToString();
                        textBoxIsWrittenOff.Text = book.IsWrittenOff ? "Yes" : "No";
                        textBoxTotalPrice.Text = (book.SellingPrice * numericUpDownAmount.Value).ToString("F2");

                        comboBoxAuthor.SelectedValue = book.AuthorId;
                        comboBoxPublisher.SelectedValue = book.PublisherId;
                        comboBoxSequel.SelectedValue = book.SequelId.HasValue ? book.SequelId.Value : (object)DBNull.Value;

                        comboBoxGenre.SelectedValue = book.GenreId.HasValue ? book.GenreId.Value : (object)DBNull.Value;
                    }
                }
            }
            else
            {
                isBookSelected = false;
                ClearFields();
                textBoxTotalPrice.Clear();
            }
            UpdateButton();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int selectedId = comboBoxSearchOption.SelectedIndex + 1;

            if (Enum.IsDefined(typeof(Display), selectedId))
            {
                Display option = (Display)selectedId;
                string searchText = textBoxSearchInput.Text.Trim();

                switch (option)
                {
                    case Display.AllBooks:
                        DisplayAllBooks();
                        break;
                    case Display.BookName:
                        if (IsSearchFieldEmpty("Please enter a book name")) return;
                        SearchBooksByTitle(searchText);
                        break;
                    case Display.BooksByAuthor:
                        if (IsSearchFieldEmpty("Please enter an author name")) return;
                        SearchBooksByAuthor(searchText);
                        break;
                    case Display.BooksByGenre:
                        if (IsSearchFieldEmpty("Please enter a genre")) return;
                        SearchBooksByGenre(searchText);
                        break;
                    case Display.MostSoldBooks:
                        DisplayMostSoldBooks();
                        break;
                    case Display.MostSoldAuthors:
                        DisplayMostSoldAuthors();
                        break;
                    case Display.MostSoldGenres:
                        DisplayMostSoldGenres();
                        break;
                    default:
                        MessageBox.Show("Invalid selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (!AreFieldsValid()) return;
            if (isBookSelected)
            {
                EditBook();
            }
            else
            {
                AddBook();
            }
            DisplayAllBooks();
            ClearFields();
        }
        public void AddBook()
        {
            using (var context = new BookShopDbContext())
            {
                var newBook = new Book
                {
                    Title = textBoxTitle.Text,
                    PageCount = int.Parse(textBoxPageCount.Text),
                    YearOfPublication = int.Parse(textBoxYearOfPublication.Text),
                    CostPrice = decimal.Parse(textBoxCostPrice.Text),
                    SellingPrice = decimal.Parse(textBoxSellingPrice.Text),
                    StockCount = int.Parse(textBoxStockCount.Text),
                    SoldCount = int.Parse(textBoxSoldCount.Text),
                    IsWrittenOff = textBoxIsWrittenOff.Text.ToLower() == "yes",
                    AuthorId = (int)comboBoxAuthor.SelectedValue,
                    PublisherId = (int)comboBoxPublisher.SelectedValue,
                    SequelId = comboBoxSequel.SelectedValue != null ? (int?)comboBoxSequel.SelectedValue : null,
                    GenreId = comboBoxGenre.SelectedValue != null ? (int?)comboBoxGenre.SelectedValue : null
                };

                context.Books.Add(newBook);
                context.SaveChanges();
                MessageBox.Show("New book added successfully");
            }

            PopulateComboBoxes();
        }
        private void DeleteBook(int bookId)
        {
            using (var context = new BookShopDbContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                    MessageBox.Show("Book deleted successfully", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Book not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            PopulateComboBoxes();
        }
        public void EditBook()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int bookId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

                using (var context = new BookShopDbContext())
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        book.Title = textBoxTitle.Text;
                        book.PageCount = int.Parse(textBoxPageCount.Text);
                        book.YearOfPublication = int.Parse(textBoxYearOfPublication.Text);
                        book.CostPrice = decimal.Parse(textBoxCostPrice.Text);
                        book.SellingPrice = decimal.Parse(textBoxSellingPrice.Text);
                        book.StockCount = int.Parse(textBoxStockCount.Text);
                        book.SoldCount = int.Parse(textBoxSoldCount.Text);
                        book.IsWrittenOff = textBoxIsWrittenOff.Text.ToLower() == "yes";
                        book.AuthorId = (int)comboBoxAuthor.SelectedValue;
                        book.PublisherId = (int)comboBoxPublisher.SelectedValue;
                        book.SequelId = comboBoxSequel.SelectedValue != null ? (int?)comboBoxSequel.SelectedValue : null;
                        book.GenreId = comboBoxGenre.SelectedValue != null ? (int?)comboBoxGenre.SelectedValue : null;

                        context.SaveChanges();
                        MessageBox.Show("Book updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            PopulateComboBoxes();
        }
        private void SellBook(int bookId, int customerId, int amount)
        {
            using (var context = new BookShopDbContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                if (book == null)
                {
                    MessageBox.Show("Book not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (book.StockCount < amount)
                {
                    MessageBox.Show("Not enough in stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                book.StockCount -= amount;
                book.SoldCount += amount;

                var transaction = new SaleTransaction
                {
                    CustomerId = customerId,
                    BookId = bookId,
                    SaleDate = DateTime.Now,
                    SalePrice = book.SellingPrice * amount
                };

                context.SaleTransactions.Add(transaction);
                context.SaveChanges();

                MessageBox.Show("Transaction successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                DisplayAllBooks();
                textBoxTotalPrice.Clear();
                numericUpDownAmount.Value = 1;
            }
        }
        private bool AreFieldsValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text) ||
                string.IsNullOrWhiteSpace(textBoxPageCount.Text) ||
                string.IsNullOrWhiteSpace(textBoxYearOfPublication.Text) ||
                string.IsNullOrWhiteSpace(textBoxCostPrice.Text) ||
                string.IsNullOrWhiteSpace(textBoxSellingPrice.Text) ||
                string.IsNullOrWhiteSpace(textBoxStockCount.Text) ||
                string.IsNullOrWhiteSpace(textBoxSoldCount.Text) ||
                string.IsNullOrWhiteSpace(textBoxIsWrittenOff.Text) ||
                comboBoxAuthor.SelectedIndex == -1 ||
                comboBoxPublisher.SelectedIndex == -1)
            {
                MessageBox.Show("Fields must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            textBoxTitle.Clear();
            textBoxPageCount.Clear();
            textBoxYearOfPublication.Clear();
            textBoxCostPrice.Clear();
            textBoxSellingPrice.Clear();
            textBoxStockCount.Clear();
            textBoxSoldCount.Clear();
            textBoxIsWrittenOff.Clear();
            comboBoxAuthor.SelectedIndex = -1;
            comboBoxPublisher.SelectedIndex = -1;
            comboBoxSequel.SelectedIndex = -1;
            comboBoxGenre.SelectedIndex = -1;
        }

        private void Form_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems.Clear();
            isBookSelected = false;
            UpdateButton();
        }
        private void UpdateButton()
        {
            if (isBookSelected)
            {
                buttonConfirm.Text = "Edit";
            }
            else
            {
                buttonConfirm.Text = "Add New";
            }
        }
        private void PopulateComboBoxSequel()
        {
            using (var context = new BookShopDb.BookShopDbContext())
            {
                var books = context.Books.ToList();
                comboBoxSequel.DisplayMember = "Title";
                comboBoxSequel.ValueMember = "Id";
                comboBoxSequel.DataSource = books.Select(b => new { b.Title, b.Id }).ToList();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int bookId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

                var result = MessageBox.Show(
                    "Are you sure you want to delete this book?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    DeleteBook(bookId);
                    DisplayAllBooks();

                }
            }
        }

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int bookId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

                using (var context = new BookShopDbContext())
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        textBoxTotalPrice.Text = (book.SellingPrice * numericUpDownAmount.Value).ToString("F2");
                    }
                }
            }
        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a book to sell", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Select a customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int bookId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            int customerId = (int)comboBoxCustomer.SelectedValue;
            int amount = (int)numericUpDownAmount.Value;

            SellBook(bookId, customerId, amount);
        }
    }
}
