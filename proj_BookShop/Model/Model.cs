    namespace Model
    {
        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int PageCount { get; set; }
            public int YearOfPublication { get; set; }
            public decimal CostPrice { get; set; }
            public decimal SellingPrice { get; set; }
            public int StockCount { get; set; }
            public int SoldCount { get; set; }
            public bool IsWrittenOff { get; set; }
            public int? SequelId { get; set; }
            public virtual Book? Sequel { get; set; }
            public int PublisherId { get; set; }
            public virtual Publisher Publisher { get; set; }
            public int AuthorId { get; set; }
            public virtual Author Author { get; set; }
            public virtual int? GenreId { get; set; }
            public virtual Genre? Genre { get; set; }
            public virtual ICollection<Promotion>? Promotions { get; set; }
            public virtual ICollection<ReservedBook>? Reservations { get; set; }
        }

        public class Promotion
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public decimal DiscountPercentage { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public virtual ICollection<Book> BooksWithDiscount { get; set; }
        }

        public class Genre
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<Book> Books { get; set; }
        }

        public class Author
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public virtual ICollection<Book> Books { get; set; }
        }

        public class Publisher
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<Book> Books { get; set; }
        }
        public class Customer
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public virtual ICollection<SaleTransaction>? Purchases { get; set; }
            public virtual ICollection<ReservedBook>? Reservations { get; set; }
        }
        public class ReservedBook
        {
            public int Id { get; set; }
            public int BookId { get; set; }
            public virtual Book Book { get; set; }
            public int CustomerId { get; set; }
            public virtual Customer Customer { get; set; }
            public DateTime ReservedUntil { get; set; } 
        }
        public class SaleTransaction
        {
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public virtual Customer Customer { get; set; }
            public int BookId { get; set; }
            public virtual Book Book { get; set; }
            public DateTime SaleDate { get; set; }
            public decimal SalePrice { get; set; }
        }
    }
