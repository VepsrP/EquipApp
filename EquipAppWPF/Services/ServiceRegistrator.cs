using EquipAppWPF.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace EquipAppWPF.Services
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
           .AddTransient<IDataService, DataService>()
           .AddTransient<IUserDialog, UserDialog>()
        ;
    }
}
