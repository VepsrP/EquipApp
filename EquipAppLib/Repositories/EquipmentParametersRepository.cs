using EquipAppLib.Context;
using EquipAppLib.Entityes;
using Microsoft.EntityFrameworkCore;

namespace EquipAppLib.Repositories
{
    internal class EquipmentParametersRepository : Repository<EquipmentParameter>
    {
        public override IQueryable<EquipmentParameter> Items => base.Items
            .Include(Item => Item.Equipment)
            .Include(Item => Item.Parameter)
        ;

        public EquipmentParametersRepository(EquipAppDb Db) : base(Db)
        {
        }
    }
}
