using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public int DestinationID { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public Destination Destination { get; set; }
    }
}
