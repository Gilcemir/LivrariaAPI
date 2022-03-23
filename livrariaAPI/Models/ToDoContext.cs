using Microsoft.EntityFrameworkCore;

namespace livrariaAPI.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> option)
            : base(option)
        {

        }

        public DbSet<Product> todoProducts { get; set; }
    }
}
