using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EfCore
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> AwaitingReservations(int id)
        {
            using var context = new Context();
            return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Awaiting Approval"
            && x.AppUserId.Equals(id)).ToList();
        }

        public List<Reservation> ConfirmedReservations(int id)
        {
            using var context = new Context();
            return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Approved"
            && x.AppUserId.Equals(id)).ToList();
        }

        public List<Reservation> PreviousReservations(int id)
        {
            using var context = new Context();
            return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Previous"
            && x.AppUserId.Equals(id)).ToList();
        }
    }
}
