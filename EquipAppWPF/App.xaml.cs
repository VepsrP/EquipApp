using EquipAppWPF.Data;
using EquipAppWPF.Services;
using EquipAppWPF.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Windows;

namespace EquipAppWPF
{
    public partial class App
    {
        public static Window ActivedWindow => Current.Windows.Cast<Window>().FirstOrDefault(W => W.IsActive);

        public static Window FocusedWindow => Current.Windows.Cast<Window>().FirstOrDefault(W => W.IsFocused);

        private static IHost _Host;

        private static IHost Host => _Host ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        private static IHostBuilder CreateHostBuilder(string[] Args) => Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(Args)
            .ConfigureAppConfiguration(Cfg => Cfg.AddJsonFile("appsettings.json", true, true)).ConfigureServices((HostBuilderContext, Services) => Services
                .AddDataBase(HostBuilderContext.Configuration.GetSection("Database"))
                .AddViews()
                .AddServices()
            );

        public static IServiceProvider Services => Host.Services;

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            using (var scope = Services.CreateScope())
                scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();
            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            using var host = Host;
            await host.StopAsync();
        }
    }
}
