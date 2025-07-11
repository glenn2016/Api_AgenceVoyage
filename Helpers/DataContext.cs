using Api_AgenceVoyage.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Api_AgenceVoyage.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(DbContextOptions<DataContext> options)
              : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Agence> Agences { get; set; }
        public DbSet<Chauffeur> Chauffeurs { get; set; }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }



    }
}
