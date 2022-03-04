using EquipAppLib.Entityes.Base;

namespace EquipAppLib.Entityes
{
    public class TypeEquipment : NamedEntity
    {
        public virtual ICollection<Parameter> Parameters { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}
