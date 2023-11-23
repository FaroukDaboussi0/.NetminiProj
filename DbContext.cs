
using Microsoft.EntityFrameworkCore;
using farouk.Models;

public class StoresContext : DbContext
{
   

   
 public StoresContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Ticket> tickets { get; set; }
   
}

