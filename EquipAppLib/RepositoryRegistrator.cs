using EquipAppInterfaces;
using EquipAppLib.Entityes;
using EquipAppLib.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EquipAppLib
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDb(this IServiceCollection Services) => Services
            .AddTransient<IRepository<Cabinet>, Repository<Cabinet>>()
            .AddTransient<IRepository<Employee>, Repository<Employee>>()
            .AddTransient<IRepository<Parameter>, ParametersRepository>()
            .AddTransient<IRepository<Workplace>, WorkplaceRepository>()
            .AddTransient<IRepository<TypeEquipment>, Repository<TypeEquipment>>()
            .AddTransient<IRepository<EquipmentParameter>, EquipmentParametersRepository>()
            .AddTransient<IRepository<Equipment>, EquipmentsRepository>()
        ;
    }
}
