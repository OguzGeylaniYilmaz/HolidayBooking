﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public void Edit(Comment entity)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        {
           return _commentDal.GetList();
        }

        public List<Comment> GetDestinationById(int id)
        {
            return _commentDal.GetListByFilter(x=>x.DestinationID.Equals(id));
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public List<Comment> GetAllCommentsWithDestinations()
        {
            return _commentDal.GetCommentListWithDestination();
        }

        public List<Comment> GetCommentListWithUser(int id)
        {
           return _commentDal.GetCommentsWithUser(id);
        }
    }
}
