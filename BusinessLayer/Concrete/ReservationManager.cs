using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void Add(Reservation entity)
        {
            _reservationDal.Insert(entity);
        }

        public void Edit(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetApprovedReservations(int id)
        {
           return _reservationDal.ConfirmedReservations(id);
        }

        public List<Reservation> GetAwaitingReservations(int id)
        {
            return _reservationDal.AwaitingReservations(id);
        }

        public Reservation GetById(int id)
        {
          return  _reservationDal.Get(id);
        }

        public List<Reservation> GetPreviousReservations(int id)
        {
           return _reservationDal.PreviousReservations(id);
        }

        public void Remove(Reservation entity)
        {
            _reservationDal.Delete(entity);
        }
    }
}
