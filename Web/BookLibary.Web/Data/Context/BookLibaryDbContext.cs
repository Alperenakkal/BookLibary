using BookLibary.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookLibary.Web.Data.Context
{
public class BookLibaryDbContext: DbContext
{
    public BookLibaryDbContext(DbContextOptions<BookLibaryDbContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source =ALPEREN; database=BookLibary;Integrated Security= True; TrustServerCertificate=True");

    }
    public DbSet<Book> Books { get; set; }
}
}
