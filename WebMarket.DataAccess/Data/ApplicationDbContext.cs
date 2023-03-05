using Microsoft.EntityFrameworkCore;
using WebMarket.Models;

namespace WebMarket.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
            //create DB
        {

        }

        public DbSet<Category> Categories { get; set; }//create the table:"categories" according to the class: "category"
    }
}
