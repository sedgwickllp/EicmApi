
namespace Eicm.Core
{
    public interface IAttribute<out T>
    {
        T Value { get; }
    }
}
