using Microsoft.EntityFrameworkCore;

namespace relation.Models
{
    public partial class RelationContext : DbContext
    {
        public virtual DbSet<Hero> Hero { get; set; }
        public virtual DbSet<Power> Power { get; set; }
        public virtual DbSet<HeroPower> HeroPower { get; set; }

        public RelationContext()
        {

        }

        public RelationContext(DbContextOptions<RelationContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;password=root;database=relation;Allow User Variables=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<HeroPower>().HasKey(i => new { i.HeroId, i.PowerId });
        }
    }
}