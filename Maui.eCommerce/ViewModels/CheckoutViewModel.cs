using System.Collections.ObjectModel;
using System.Windows.Input;
using Library.eCommerce.Models;
using Library.eCommerce.Services;
using Microsoft.Maui.Controls;
using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.ViewModels
{
    public class CheckoutViewModel : BindableObject
    {
        public ObservableCollection<Item> CartItems { get; set; }

        public double TaxRate => ShoppingCartService.Current.TaxRate;
        public double Subtotal => CartItems.Sum(i => (double)((i.Product?.Price ?? 0) * i.Quantity));
        public double TaxAmount => Subtotal * TaxRate;
        public double Total => Subtotal + TaxAmount;

        public ICommand CheckoutCommand { get; }

        public CheckoutViewModel()
        {
            CartItems = new ObservableCollection<Item>(ShoppingCartService.Current.CartItems);
            CheckoutCommand = new Command(async () => await DoCheckout());

            TaxConfigViewModel.TaxRateChanged += () =>
            {
                OnPropertyChanged(nameof(TaxRate));
                OnPropertyChanged(nameof(TaxAmount));
                OnPropertyChanged(nameof(Total));
            };
        }

        private async Task DoCheckout()
        {
            ShoppingCartService.Current.ClearCart();
            CartItems.Clear();

            OnPropertyChanged(nameof(Subtotal));
            OnPropertyChanged(nameof(TaxAmount));
            OnPropertyChanged(nameof(Total));

            await Application.Current.MainPage.DisplayAlert("Order Placed", "Thank you for your purchase!", "OK");
        }

        protected void OnPropertyChanged(string propertyName) =>
            base.OnPropertyChanged(propertyName);
    }
}
