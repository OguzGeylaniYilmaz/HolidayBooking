using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void Add(Announcement entity)
        {
            _announcementDal.Insert(entity);
        }

        public void Edit(Announcement entity)
        {
          _announcementDal.Update(entity);
        }

        public List<Announcement> GetAll()
        {
            return _announcementDal.GetList();
        }

        public Announcement GetById(int id)
        {
            return _announcementDal.Get(id);
        }

        public void Remove(Announcement entity)
        {
            _announcementDal.Delete(entity);
        }
    }
}
