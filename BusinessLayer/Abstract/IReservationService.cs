using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> GetAwaitingReservations(int id);
        List<Reservation> GetPreviousReservations(int id);
        List<Reservation> GetApprovedReservations(int id);
    }
}
