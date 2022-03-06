using EquipAppLib.Entityes.Base;

namespace EquipAppLib.Entityes
{
    public class Workplace : Entity
    {
        public int Number { get; set; }
        public virtual Cabinet Cabinet { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}
