using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }


        public DbSet<Book> Books {get; set; }
        public DbSet<Comment> Comments {get; set; }
        public DbSet<Read> Reads {get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Read>(x => x.HasKey(p => new {p.AppUserId, p.BookId}));

            builder.Entity<Read>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Reads)
                .HasForeignKey(p => p.AppUserId);

             builder.Entity<Read>()
                .HasOne(u => u.Book)
                .WithMany(u => u.Reads)
                .HasForeignKey(p => p.BookId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}