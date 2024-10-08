﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EfCore
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentListWithDestination()
        {
            using (var context = new Context())
            {
                return context.Comments.Include(x => x.Destination).ToList();
            }
        }

        public List<Comment> GetCommentsWithUser(int id)
        {
            using (var context = new Context())
            {
                return context.Comments.Where(x=>x.DestinationID.Equals(id)).Include(x => x.AppUser).ToList();
            }
        }
    }
}
