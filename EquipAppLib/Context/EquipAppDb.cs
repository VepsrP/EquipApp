using EquipAppLib.Entityes;
using Microsoft.EntityFrameworkCore;

namespace EquipAppLib.Context
{
    public class EquipAppDb : DbContext
    {
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentParameter> EquipmentsParameters { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<TypeEquipment> TypesEquipment { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }

        public EquipAppDb(DbContextOptions<EquipAppDb> Options) : base(Options)
        {

        }
    }
}
