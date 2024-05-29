namespace Frontend.ViewModels;

public class HomeProductModel
{
    public string ProductName { get; set; } = null!;
    public string ImgUrl { get; set; } = null!;
    public decimal OriginalPrice { get; set; }
    public bool IsBestseller { get; set; }  
}
