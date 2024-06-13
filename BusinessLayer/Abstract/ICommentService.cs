using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> GetAllCommentsWithDestinations();
        List<Comment> GetCommentListWithUser(int id);
    }
}
