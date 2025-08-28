using JuanK.Maui.Services;
using JuanK.Maui.ViewModels;

namespace JuanK.Maui.Views;

public partial class LoginPage : ContentPage
{
	private AuthService _authService;
	public LoginPage()
	{
		InitializeComponent();
		this.BindingContext = new LoginViewModel();
	}
}