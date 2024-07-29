using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        Destination GetDestinationWithGuide(int id);
    }
}
