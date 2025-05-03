using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views
{
    public partial class CheckoutPage : ContentPage
    {
        public CheckoutPage()
        {
            InitializeComponent();
            BindingContext = new CheckoutViewModel();
        }

        private async void GoBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }


    }
}
