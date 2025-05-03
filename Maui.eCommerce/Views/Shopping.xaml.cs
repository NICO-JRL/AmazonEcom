using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

public partial class Shopping : ContentPage
{
    public Shopping()
    {
        InitializeComponent();
        BindingContext = new ShoppingManagementViewModel();
    }

    private void RemoveFromCartClicked(object sender, EventArgs e)
    {
        (BindingContext as ShoppingManagementViewModel).ReturnItem();
    }
    private void AddToCartClicked(object sender, EventArgs e)
    {
        (BindingContext as ShoppingManagementViewModel).PurchaseItem();
    }

    private void InlineAddClicked(object sender, EventArgs e)
    {
        (BindingContext as ShoppingManagementViewModel).RefreshUX();
    }

    private async void GoBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");

    }

    private async void CheckoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Checkout");
    }

}