using System.Threading.Tasks;

namespace AcmeCorporation.Draw.Domain.Events
{
    public interface IEventDispatcher
    {
        Task DispatchEvents();
    }
}
