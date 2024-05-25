using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ConsoleApp3.Models;
using System.Data;
using System.Linq;

namespace ConsoleApp3
{
    internal class AnimalContext : DbContext
    {
        // Product entites can be accessed by this context
        public virtual DbSet<Animals> Animals { get; set; }
        // Shop entities can be accessed by this context
        public virtual DbSet<Species> Species { get; set; }

        // OnConfiguring is a hook that executes while the context configures itself
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // I add a connection to a database instance while the context configures
            optionsBuilder.UseSqlServer(
                @"Server=127.0.0.1;Database=Animals;user id=sa;pwd=Toto123*;TrustServerCertificate=True;MultipleActiveResultSets=true;Integrated Security=False");
        }
    }
}
