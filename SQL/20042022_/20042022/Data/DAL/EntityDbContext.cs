using _20042022.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _20042022.Data.DAL
{
    internal class EntityDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-LOAUU63\SQLEXPRESS;Database=EntityLesson1;Trusted_Connection=true");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Stadion> Stadions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

    }
}
