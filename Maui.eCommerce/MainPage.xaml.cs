using Maui.eCommerce.ViewModels;
using Maui.eCommerce.Views;

namespace Maui.eCommerce
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void InventoryClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//InventoryManagement");
        }

        private void ShopClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ShoppingManagement");
        }

        private async void OpenTaxConfigClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaxConfigPage());
        }

        private async void CheckoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Checkout");
        }

    }
}

