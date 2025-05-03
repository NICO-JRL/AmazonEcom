using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views
{
    public partial class TaxConfigPage : ContentPage
    {
        public TaxConfigPage()
        {
            InitializeComponent();
            BindingContext = new TaxConfigViewModel();
        }

        private async void GoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

