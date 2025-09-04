using JuanK.Maui.Models;
using JuanK.Maui.ViewModels;

namespace JuanK.Maui.Views;

public partial class TiendasPage : ContentPage
{
	public TiendasPage(TiendasViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Verificar si el BindingContext está correctamente inicializado
        if (BindingContext is TiendasViewModel viewModel)
        {            
              
        }
    }

    private void OnTiendaTapped(object sender, EventArgs e)
    {
        /*if (sender is Frame frame && frame.BindingContext is TiendaDisplayVM tienda)
        {
            if (BindingContext is TiendasViewModel viewModel)
            {
                viewModel.TiendaTappedCommand?.Execute(tienda);
            }
        */

        DisplayAlert("Alert", "Tab Tiendas", "cancelar");
    }
}