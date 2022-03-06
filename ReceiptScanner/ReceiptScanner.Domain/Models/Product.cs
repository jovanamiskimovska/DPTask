namespace Domain.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public bool IsDomestic { get; set; }
        public float ProductPrice { get; set; }
        public int? ProductWeight { get; set; }
        public string ProductDesc { get; set; }

    }
}