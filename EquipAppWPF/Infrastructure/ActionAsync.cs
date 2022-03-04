using System.Threading.Tasks;

namespace EquipAppWPF.Infrastructure
{
    internal delegate Task ActionAsync();

    internal delegate Task ActionAsync<in T>(T parameter);
}
