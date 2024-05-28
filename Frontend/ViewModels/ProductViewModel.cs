using Frontend.Models;

namespace Frontend.ViewModels;

public class ProductViewModel
{
    public List<Category> Categories { get; set; } = [];
	public List<Product> Products { get; set; } = [];
}
