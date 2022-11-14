using firstEf.Data;
using Microsoft.EntityFrameworkCore;

namespace firstEf.Context
{
    public class PerContext : DbContext
    {
      
        public PerContext(DbContextOptions<PerContext> db) : base(db)
        {


        }
        public DbSet<Products>Products {get;set;}//tablo yarat
        public DbSet<Categories>Categories { get; set; }



    }
}
