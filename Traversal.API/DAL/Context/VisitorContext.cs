using Microsoft.EntityFrameworkCore;
using Traversal.API.DAL.Entities;

namespace Traversal.API.DAL.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=OGUZ;Initial Catalog=Traversal.API.DB;Integrated Security=True;");
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
