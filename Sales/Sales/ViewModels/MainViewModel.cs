namespace Sales.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Sales.Views;
    using Xamarin.Forms;

    public class MainViewModel
    {
        public ProductsViewModel Products { get; set; }

        public NewProductViewModel NewProduct { get; set; }

        public MainViewModel()
        {
            this.Products = new ProductsViewModel();
        }

        public ICommand NewProductCommand
        {
            get
            {
                return new RelayCommand(AddProduct);
            }
        }

        private async void AddProduct()
        {
            this.NewProduct = new NewProductViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new NewProductPage());
        }
    }
}
