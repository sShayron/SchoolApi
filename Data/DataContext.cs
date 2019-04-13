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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Teacher>()
                .HasData(
                    new List<Teacher>() {
                        new Teacher() {
                            Id = 1,
                            Name = "Vinicius"
                        },
                        new Teacher() {
                            Id = 2,
                            Name = "Saulo"
                        },
                        new Teacher() {
                            Id = 3,
                            Name = "Paulo"
                        }
                    }
                );

            builder.Entity<Student>()
            .HasData(
                new List<Student>() {
                        new Student() {
                            Id = 1,
                            Name = "Maria",
                            LastName = "Josefina",
                            BirthDate = "20/01/1999",
                            TeacherId = 1
                        },
                        new Student() {
                            Id = 2,
                            Name = "Leandro",
                            LastName = "Rasan",
                            BirthDate = "01/02/1987",
                            TeacherId = 2
                        },
                        new Student() {
                            Id = 3,
                            Name = "Jose",
                            LastName = "Lito",
                            BirthDate = "01/12/1990",
                            TeacherId = 3
                        }
                }
            );
        }
    }
}