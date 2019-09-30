using System.Net.Mime;
using Microsoft.EntityFrameworkCore;

namespace AnimalFarmDatabase
{
    public class DatabaseContext : DbContext 
    {
        public DbSet<Animal> Animals { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Animal>().HasKey(x => x.Id);
            modelBuilder.Entity<Animal>().HasMany(x => x.TextAttributes).WithOne();
            modelBuilder.Entity<Animal>().HasMany(x => x.IntAttributes).WithOne();
            modelBuilder.Entity<Animal>().HasMany(x => x.DateTimeAttributes).WithOne();
            
            modelBuilder.Entity<TextAttribute>().HasKey(x => x.Id);
            modelBuilder.Entity<IntAttribute>().HasKey(x => x.Id);
            modelBuilder.Entity<DateTimeAttribute>().HasKey(x => x.Id);

            modelBuilder.Entity<TextAttribute>().ToTable("text_attributes");
            modelBuilder.Entity<IntAttribute>().ToTable("int_attributes");
            modelBuilder.Entity<DateTimeAttribute>().ToTable("datetime_attributes");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}