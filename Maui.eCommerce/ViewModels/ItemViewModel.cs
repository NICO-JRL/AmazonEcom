using Library.eCommerce.Models;
using Library.eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace Maui.eCommerce.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        public Item Model { get; set; }

        public ICommand? AddCommand { get; set; }

        private int quantityToAdd = 1;
        public int QuantityToAdd
        {
            get => quantityToAdd;
            set
            {
                if (quantityToAdd != value)
                {
                    quantityToAdd = value;
                    OnPropertyChanged(nameof(QuantityToAdd));
                }
            }
        }

        private void DoAdd()
        {
            for (int i = 0; i < QuantityToAdd; i++)
            {
                ShoppingCartService.Current.AddOrUpdate(Model);
            }
        }

        void SetupCommands()
        {
            AddCommand = new Command(DoAdd);
        }

        public ItemViewModel()
        {
            Model = new Item();
            SetupCommands();
        }

        public ItemViewModel(Item model)
        {
            Model = model;
            SetupCommands();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
