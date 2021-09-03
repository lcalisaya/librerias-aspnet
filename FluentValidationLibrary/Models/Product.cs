namespace FluentValidationLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsExpiring { get; set; }
        public decimal Cost { get; set; }
    }
}
