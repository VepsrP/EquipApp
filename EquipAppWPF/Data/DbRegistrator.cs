using System;
using EquipAppLib;
using EquipAppLib.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;

namespace EquipAppWPF.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDataBase(this IServiceCollection Service, IConfiguration Configuration)
        {
            var type = Configuration["Type"];
            var cString = Configuration.GetConnectionString(type);
            return Service.AddDbContext<EquipAppDb>(
                Opt =>
                {
                    switch (type)
                    {
                        case null: throw new InvalidOperationException("Не определен тип Базы данных!");

                        default: throw new InvalidOperationException("Неподдерживаемый тип Базы данных!");

                        case "MSSQL":
                            Opt.UseSqlServer(cString);
                            break;
                        case "MySQL":
                            Opt.UseMySql(cString, ServerVersion.AutoDetect(cString));
                            break;
                    }
                }).AddTransient<DbInitializer>().AddRepositoriesInDb();
        }
    }
}
