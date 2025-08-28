using JuanK.Maui.ViewModels;

namespace JuanK.Maui.Views;

public partial class TiendasPage : ContentPage
{
	public TiendasPage()
	{
		InitializeComponent();
		this.BindingContext = new TiendasViewModel();
	}
}