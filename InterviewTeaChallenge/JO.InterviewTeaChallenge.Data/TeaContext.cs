using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JO.InterviewTeaChallenge.Data
{
    public class TeaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Tea In Memory Database");
        }
        //public DbSet<User> Users { get; set; }
    }
}
