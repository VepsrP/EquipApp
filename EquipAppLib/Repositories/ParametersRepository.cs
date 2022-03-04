using EquipAppLib.Context;
using EquipAppLib.Entityes;
using Microsoft.EntityFrameworkCore;

namespace EquipAppLib.Repositories
{
    internal class ParametersRepository : Repository<Parameter>
    {
        public override IQueryable<Parameter> Items => base.Items
            .Include(Item => Item.EquipmentTypes);

        public ParametersRepository(EquipAppDb Db) : base(Db)
        {
        }
    }
}
