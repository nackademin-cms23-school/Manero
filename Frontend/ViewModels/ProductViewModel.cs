using Frontend.Models;

namespace Frontend.ViewModels;

public class ProductViewModel
{
    public IEnumerable<Category>? Categories { get; set; }
    public IEnumerable<Product>? Products { get; set; }
}
