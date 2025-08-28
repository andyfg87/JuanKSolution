using JuanK.Maui.Models;
using JuanK.Maui.Services;
using JuanK.Maui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Maui.ViewModels
{
    public class TiendasViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private ObservableCollection<TiendaDisplayVM> _tiendas;

        public ObservableCollection<TiendaDisplayVM> Tiendas
        {
            get => _tiendas;
            set => SetProperty(ref _tiendas, value);
        }

        public Command<TiendaDisplayVM> TiendaTappedCommand { get; }

        public TiendasViewModel(ApiService apiService)
        {
            _apiService = apiService;
            TiendaTappedCommand = new Command<TiendaDisplayVM>(OnTiendaTapped);
            LoadTiendas();
        }

        public TiendasViewModel()
        {
            TiendaTappedCommand = new Command<TiendaDisplayVM>(OnTiendaTapped);
            LoadTiendas();
        }

        private async void LoadTiendas()
        {
            IsBusy = true;

            try
            {
                var tiendas = await _apiService.GetAsync<List<TiendaDisplayVM>>("tiendas");
                Tiendas = new ObservableCollection<TiendaDisplayVM>(tiendas);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnTiendaTapped(TiendaDisplayVM tienda)
        {
            if (tienda == null) return;

            await Shell.Current.GoToAsync($"//productos?tiendaId={tienda.Id}");
        }
    }
}
