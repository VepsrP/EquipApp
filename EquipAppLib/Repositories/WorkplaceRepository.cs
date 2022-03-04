using EquipAppLib.Context;
using EquipAppLib.Entityes;
using Microsoft.EntityFrameworkCore;

namespace EquipAppLib.Repositories
{
    internal class WorkplaceRepository : Repository<Workplace>
    {
        public override IQueryable<Workplace> Items => base.Items
            .Include(Item => Item.Cabinet)
            .Include(Item => Item.Employee)
        ;

        public WorkplaceRepository(EquipAppDb Db) : base(Db)
        {
        }
    }
}
