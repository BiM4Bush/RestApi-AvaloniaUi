using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using MVVMExampleApp.Frontend.Services;
using MVVMExampleApp.Frontend.ViewModels;
using System;

namespace MVVMExampleApp.Frontend
{
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = ServiceProvider.GetRequiredService<AddView>();
            }

            base.OnFrameworkInitializationCompleted();
        }

        //DI
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddHttpClient();

            services.AddSingleton<IApiService, ApiService>();
            services.AddSingleton<AddViewModel>();
            services.AddSingleton<AddView>();
        }
    }
}