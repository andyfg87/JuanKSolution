using JuanK.Maui.Models;
using JuanK.Maui.Services;
using JuanK.Maui.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace JuanK.Maui.ViewModels
{
    public class TiendasViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private double _loadProgress;
        private ObservableCollection<TiendaDisplayVM> _tiendas;

        public ObservableCollection<TiendaDisplayVM> Tiendas
        {
            get => _tiendas;
            set => SetProperty(ref _tiendas, value);
        }

        public double LoadProgress
        {
            get => _loadProgress;
            set => SetProperty(ref _loadProgress, value);
        }

        public Command<TiendaDisplayVM> TiendaTappedCommand { get; }
        public Command LoadTiendasCommand { get; }

        public TiendasViewModel(ApiService apiService)
        {
            _apiService = apiService;
            TiendaTappedCommand = new Command<TiendaDisplayVM>(OnTiendaTapped);
            LoadTiendasCommand = new Command(ExecuteLoadTiendas);

            // Cargar tiendas cuando aparezca la página
            ExecuteLoadTiendas();
        }

        private async void ExecuteLoadTiendas()
        {
            if (IsBusy) return;

            IsBusy = true;
            LoadProgress = 0;

            try
            {
                Debug.WriteLine("📡 Iniciando carga con conexión lenta...");

                // Simular progreso para feedback visual
                await SimulateProgress();

                var tiendas = await _apiService.GetAsync<List<TiendaDisplayVM>>("tiendas");

                if (tiendas != null)
                {
                    Debug.WriteLine($"✅ Carga completada: {tiendas.Count} tiendas");
                    Tiendas = new ObservableCollection<TiendaDisplayVM>(tiendas);
                    LoadProgress = 1.0;
                }
            }
            catch (TimeoutException)
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Shell.Current.DisplayAlert("Conexión Lenta",
                        "La conexión está muy lenta. Por favor:\n\n" +
                        "1. Verifica tu conexión a internet\n" +
                        "2. Intenta en un área con mejor señal\n" +
                        "3. Reintenta más tarde", "OK");
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task SimulateProgress()
        {
            // Simular progreso durante la carga lenta
            for (int i = 0; i < 10; i++)
            {
                if (!IsBusy) break;
                LoadProgress = i * 0.1;
                await Task.Delay(1000); // Actualizar cada segundo
            }
        }

        private async void OnTiendaTapped(TiendaDisplayVM tienda)
        {
            if (tienda == null) return;

            // Navegación segura
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                //await Shell.Current.GoToAsync($"//productos?tiendaId={tienda.Id}");
                ExecuteLoadTiendas();
            });
        }
    }
}