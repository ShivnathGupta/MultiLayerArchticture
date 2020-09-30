using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiLayerProject.Core.Models;
using System;

namespace MultiLayerProject.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
    }
}
