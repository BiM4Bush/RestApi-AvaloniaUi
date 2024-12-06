using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMExampleApp.Frontend.Models;
using MVVMExampleApp.Frontend.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVVMExampleApp.Frontend.ViewModels
{
    public class AddViewModel : ObservableObject
    {
        private readonly IApiService _apiService;

        public AddViewModel(IApiService apiService)
        {
            _apiService = apiService;
            AddCommand = new AsyncRelayCommand(AddNumbersAsync);
        }

        private int _firstInteger;
        public int FirstInteger
        {
            get => _firstInteger;
            set => SetProperty(ref _firstInteger, value);  
        }

        private int _secondInteger;
        public int SecondInteger
        {
            get => _secondInteger;
            set => SetProperty(ref _secondInteger, value);  
        }

        private int _result;
        public int Result
        {
            get => _result;
            set => SetProperty(ref _result, value);  
        }

        private bool _isProcessing;
        public bool IsProcessing
        {
            get => _isProcessing;
            set => SetProperty(ref _isProcessing, value);
        }
        public IAsyncRelayCommand AddCommand { get; }

        public async Task AddNumbersAsync()
        {
            IsProcessing = true;

            var request = new AddRequest { FirstInteger = FirstInteger, SecondInteger = SecondInteger };
            var response = await _apiService.AddNumbersAsync(request);
            Result = response.Result;

            IsProcessing = false;
        }
    }
}
