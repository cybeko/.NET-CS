namespace Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; } 
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Category> Categories { get; set; } 
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Promotion> Promotions { get; set; } 
    }

    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } 

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }  

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


}
