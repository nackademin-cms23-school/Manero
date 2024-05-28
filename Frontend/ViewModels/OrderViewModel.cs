namespace Frontend.ViewModels
{
    public class OrderViewModel
    {
        public string OrderId { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = null!;
        public double OrderPrice { get; set; }
        public List<string> Products { get; set; } = []; //Byt string till ProductViewModel eller nått!

    }
}
