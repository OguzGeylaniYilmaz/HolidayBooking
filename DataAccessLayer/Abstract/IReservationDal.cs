using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> PreviousReservations(int id);
        List<Reservation> ConfirmedReservations(int id);
        List<Reservation> AwaitingReservations(int id);
    }
}
