using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Todo.Models
{
    public class DataAccessContext : IdentityDbContext<User>
    {
        public DataAccessContext(DbContextOptions<DataAccessContext> opt): base (opt)
        {

        }
        #region DbSet
        public DbSet<todoTask>? todoTasks { get; set; }
        public DbSet<Category> categories { get; set; }
        #endregion  
    }
}
