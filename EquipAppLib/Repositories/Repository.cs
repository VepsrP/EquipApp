using EquipAppInterfaces;
using EquipAppLib.Context;
using EquipAppLib.Entityes.Base;
using Microsoft.EntityFrameworkCore;

namespace EquipAppLib.Repositories
{
    internal class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly EquipAppDb _Db;
        private readonly DbSet<T> _DbSet;

        public bool AutoSaveChanges { get; set; } = true;

        public Repository(EquipAppDb Db)
        {
            _Db = Db;
            _DbSet = _Db.Set<T>();
        }

        public virtual IQueryable<T> Items => _DbSet;
        public T GetById(int Id) => Items.FirstOrDefault(Item => Item.Id == Id);

        public Task<T> GetByIdAsync(int Id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public T Add(T Item)
        {
            if (Item is null) throw new ArgumentNullException(nameof(Item));
            _Db.Entry(Item).State = EntityState.Added;
            if (AutoSaveChanges) _Db.SaveChanges();
            return Item;
        }

        public async Task<T> AddAsync(T Item, CancellationToken Cancel = default)
        {
            if (Item is null) throw new ArgumentNullException(nameof(Item));
            _Db.Entry(Item).State = EntityState.Added;
            if(AutoSaveChanges) await _Db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return Item;
        }

        public void Update(T Item)
        {
            if (Item is null) throw new ArgumentNullException(nameof(Item));
            _Db.Entry(Item).State = EntityState.Modified;
            if (AutoSaveChanges) _Db.SaveChanges();
        }

        public async Task UpdateAsync(T Item, CancellationToken Cancel = default)
        {
            if (Item is null) throw new ArgumentNullException(nameof(Item));
            _Db.Entry(Item).State = EntityState.Modified;
            if (AutoSaveChanges) await _Db.SaveChangesAsync(Cancel);
        }

        public void Delete(T Item)
        {
            if (Item is null) throw new ArgumentNullException(nameof(Item));
            _Db.Entry(Item).State = EntityState.Deleted;
            if (AutoSaveChanges) _Db.SaveChanges();
        }

        public async Task DeleteAsync(T Item, CancellationToken Cancel = default)
        {
            if (Item is null) throw new ArgumentNullException(nameof(Item));
            _Db.Entry(Item).State = EntityState.Deleted;
            if (AutoSaveChanges) await _Db.SaveChangesAsync(Cancel);
        }
    }
}
