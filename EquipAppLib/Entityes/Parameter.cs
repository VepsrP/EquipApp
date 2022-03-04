using EquipAppLib.Entityes.Base;

namespace EquipAppLib.Entityes
{
    public class Parameter : NamedEntity
    {
        public virtual ICollection<TypeEquipment> EquipmentTypes { get; set; }
    }
}
