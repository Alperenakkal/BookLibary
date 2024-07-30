using BookLibary.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibary.Api.Data.Context
{
    public class UserLibaryDbContext:DbContext
    {
        public UserLibaryDbContext(DbContextOptions<UserLibaryDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ALPEREN; database=UserLibary;Integrated Security= True; TrustServerCertificate=True");
        }

        public DbSet<User> Users { get; set; }
    }
}
