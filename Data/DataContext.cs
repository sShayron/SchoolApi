using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<Professor>()
        //         .HasData(
        //             new List<Professor>() {
        //                 new Professor
        //             }
        //         )
        // }
    }
}