using Microsoft.EntityFrameworkCore;
using Pustok.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Pustok.DAL
{
    public class RelationsBooksShop:DbContext
    {

        public RelationsBooksShop( DbContextOptions<RelationsBooksShop> options):base(options) { 
        
        
        
        }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<BooksImage> BooksImages { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<BooksOrders> BooksOrders { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Sliders> Sliders { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<BooksTags> BooksTags { get; set; }
        public DbSet<Settings> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksOrders>().HasKey(x => new { x.OrdersId, x.BooksId });
            modelBuilder.Entity<BooksTags>().HasKey(x => new { x.TagsId, x.BooksId });
        }
      
    }
}
