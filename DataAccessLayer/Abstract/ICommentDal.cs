﻿using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> GetCommentListWithDestination();
        List<Comment> GetCommentsWithUser(int id);
    }
}
