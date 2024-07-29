using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        private readonly IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void Add(ContactUs entity)
        {
            _contactUsDal.Insert(entity);
        }

        public void Edit(ContactUs entity)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetAll()
        {
           return _contactUsDal.GetList();
        }

        public ContactUs GetById(int id)
        {
            return _contactUsDal.Get(id);
        }

        public void Remove(ContactUs entity)
        {
            _contactUsDal.Delete(entity);
        }
    }
}
