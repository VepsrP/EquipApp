using EquipAppLib.Entityes.Base;

namespace EquipAppLib.Entityes
{
    public class Employee : NamedEntity
    {
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}
