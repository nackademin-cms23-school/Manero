using Frontend.Models;

namespace Frontend.ViewModels;

public class ProductViewModel
{
    public List<CategoryModel> Categories { get; set; } = [];
	public List<ProductModel> Products { get; set; } = [];

    public ProductModel? Product { get; set; }
}
