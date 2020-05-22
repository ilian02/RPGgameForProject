using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Database
{
    public partial class MyDBcontext : DbContext
    {

        public MyDBcontext(DbContextOptions options)
            : base(options)
        { }


        public MyDBcontext()
            : base()
        { }

        public DbSet<HeroModel> Heroes { get; set; }
        public DbSet<PlaceModel> Place { get; set; }
        public DbSet<EnemyModel> Enemies { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<MarketItem> MarketItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-T5BV058\SQLEXPRESS;Initial Catalog=projectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

    }
}
