using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void Add(Testimonial entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }

        public List<Testimonial> GetAll()
        {
            return _testimonialDal.GetList();
        }

        public Testimonial GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Testimonial entity)
        {
            throw new NotImplementedException();
        }
    }
}
