namespace Maui.eCommerce.Views;

public partial class Shopping : ContentPage
{
	public Shopping()
	{
		InitializeComponent();
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}