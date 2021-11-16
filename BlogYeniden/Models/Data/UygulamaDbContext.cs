using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogYeniden.Models.Data
{
    public class UygulamaDbContext :DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User () { Id= 1, Username="admin", Password="123" },
                new User() { Id = 2, Username = "admin2", Password = "123" }
                );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
