using JuanK.Maui.Services;
using JuanK.Maui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Maui.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AuthService _authService;

        private string _correo;
        public string Correo
        {
            get => _correo;
            set => SetProperty(ref _correo, value);
        }

        private string _clave;
        public string Clave
        {
            get => _clave;
            set => SetProperty(ref _clave, value);
        }

        public Command LoginCommand { get; }

        public LoginViewModel(AuthService authService)
        {
            _authService = authService;
            LoginCommand = new Command(async () => await LoginAsync());
        }

        public LoginViewModel()
        {
           
            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                var success = await _authService.LoginAsync(Correo, Clave);
                if (success)
                {
                    await Shell.Current.GoToAsync("//main");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Credenciales inválidas", "OK");
                }
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
    }
}
