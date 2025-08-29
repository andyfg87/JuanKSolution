using JuanK.Maui.ViewModels;

namespace JuanK.Maui.Views;

public partial class TiendasPage : ContentPage
{
	public TiendasPage(TiendasViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}