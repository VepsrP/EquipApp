using System;
using EquipAppLib;
using EquipAppLib.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EquipAppWPF.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDataBase(this IServiceCollection Service, IConfiguration Configuration)
        {
            return Service.AddDbContext<EquipAppDb>(
                Opt =>
                {
                    var type = Configuration["Type"];
                    switch (type)
                    {
                        case null: throw new InvalidOperationException("Не определен тип Базы данных!");

                        default: throw new InvalidOperationException("Неподдерживаемый тип Базы данных!");

                        case "MSSQL":
                            Opt.UseSqlServer(Configuration.GetConnectionString(type));
                            break;
                        case "MySQL":
                            Opt.UseMySQL(Configuration.GetConnectionString(type));
                            break;
                    }
                }).AddRepositoriesInDb();
        }
    }
}
