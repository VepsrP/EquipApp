using EquipAppLib.Entityes.Base;

namespace EquipAppLib.Entityes;

public class EquipmentParameter : Entity
{
    public virtual Equipment Equipment { get; set; }
    public virtual Parameter Parameter { get; set; }
    public string Value { get; set; }
}