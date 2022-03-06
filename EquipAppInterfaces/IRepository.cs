namespace EquipAppInterfaces
{
    public interface IRepository<T> where T: class, IEntity, new()
    {
        IQueryable<T> Items { get; }

        T GetById(int Id);
        Task<T> GetByIdAsync(int Id, CancellationToken Cancel = default);

        T Add(T Item);

        Task<T> AddAsync(T Item, CancellationToken Cancel = default);

        void Update (T Item);

        Task UpdateAsync(T Item, CancellationToken Cancel = default);

        void Delete(T Item);

        Task DeleteAsync(T Item, CancellationToken Cancel = default);
    }
}
