using System.ComponentModel.DataAnnotations.Schema;
using EquipAppLib.Entityes.Base;

namespace EquipAppLib.Entityes
{
    public class Equipment : NamedEntity
    {
        public virtual TypeEquipment Type { get; set; }
        public virtual ICollection<EquipmentParameter> EquipmentParameters { get; set; }
        public string SerialNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal InventoryNumber { get; set; }
        public virtual Workplace Workplace { get; set; }
    }
}
