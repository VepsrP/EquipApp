using EquipAppLib.Context;
using EquipAppLib.Entityes;
using Microsoft.EntityFrameworkCore;

namespace EquipAppLib.Repositories
{
    internal class EquipmentsRepository : Repository<Equipment>
    {
        public override IQueryable<Equipment> Items => base.Items
            .Include(Item => Item.Type)
            .Include(Item => Item.Workplace)
        ;

        public EquipmentsRepository(EquipAppDb Db) : base(Db)
        {
        }
    }
}
