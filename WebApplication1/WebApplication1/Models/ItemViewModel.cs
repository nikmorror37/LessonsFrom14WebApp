namespace WebApplication1.Models
{
    public enum Category
    {
        Sport,
        Home,
        Electronics,
        Food,
        Beauty,
        Fashion
    }
    public class ItemViewModel
    {
        public int Id { get; set; } = 1;
        public string? Name { get; set; } = "";
        public int Count { get; set; } = 1;
        public string? Country { get; set; } = "";
        public Enum Category { get; set; }

        public ItemViewModel(int id, string name, int count, string country, Enum category)
        {
            Id = id;
            Name = name;
            Count = count;
            Country = country;
            Category = category;
        }


    }
}