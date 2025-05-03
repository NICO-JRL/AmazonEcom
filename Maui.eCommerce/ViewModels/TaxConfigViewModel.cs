using System.Windows.Input;
using Microsoft.Maui.Controls;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{
    public class TaxConfigViewModel : BindableObject
    {
        private double taxRate;

        public static event Action? TaxRateChanged;

        public double TaxRate
        {
            get => taxRate;
            set
            {
                if (taxRate != value)
                {
                    taxRate = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveCommand { get; }

        public TaxConfigViewModel()
        {
            TaxRate = ShoppingCartService.Current.TaxRate;
            SaveCommand = new Command(SaveTaxRate);
        }

        private void SaveTaxRate()
        {
            ShoppingCartService.Current.TaxRate = TaxRate;
            TaxRateChanged?.Invoke();
        }
    }
}
