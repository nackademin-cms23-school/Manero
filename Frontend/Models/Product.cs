namespace Frontend.Models;

public class Product
{
  
    public string BatchNumber { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Size { get; set; } = null!;
    public string SmallImage { get; set; } = null!;
    public int Stock { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsNew { get; set; }
    public bool IsSale { get; set; }
    public bool IsTop { get; set; }
    public string SubCategoryName { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public string OriginalPrice { get; set; } = null!;
    public string? DiscountPrice { get; set; }
    public List<string> BigImage { get; set; } = [];
}
