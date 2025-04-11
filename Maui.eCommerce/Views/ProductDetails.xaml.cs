using AmazonEcom.Models;

namespace Maui.eCommerce.Views;

public partial class ProductDetails : ContentPage
{
	public ProductDetails()
	{
		InitializeComponent();
		BindingContext = new Product();
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//InventoryManagement");
    }
}