using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
