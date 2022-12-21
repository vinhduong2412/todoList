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
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Work"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Birth"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "School"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Healthcare"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Pet"
                },
                new Category 
                { 
                    CategoryId = 7,
                    CategoryName = "Exercicse"
                }
            );
        }
    }
}
