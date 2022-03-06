using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using EquipAppLib.Context;
using Microsoft.EntityFrameworkCore;

namespace EquipAppWPF.Data
{
    internal class DbInitializer
    {
        private readonly EquipAppDb _Db;
        private readonly ILogger _Loger;

        public DbInitializer(EquipAppDb Db, ILogger<EquipAppDb> Loger)
        {
            _Db = Db;
            _Loger = Loger;
        }

        public async Task InitializeAsync()
        {
            if (!(await _Db.Database.CanConnectAsync().ConfigureAwait(false)))
            {
                var timer = Stopwatch.StartNew();
                _Loger.LogInformation("Инициализация БД...");

                //_Loger.LogInformation("Удаление существующей БД...");
                //await _Db.Database.EnsureDeletedAsync().ConfigureAwait(false);
                //_Loger.LogInformation($"Удаление существующей БД выполнено за {timer.ElapsedMilliseconds} мс.");
                _Loger.LogInformation("Миграция БД...");
                await _Db.Database.EnsureCreatedAsync().ConfigureAwait(false);
                _Loger.LogInformation("Миграция БД выполнена за {} мс.",timer.ElapsedMilliseconds);
            }
        }
    }
}
