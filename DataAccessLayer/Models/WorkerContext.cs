using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DataAccessLayer.Models
{
    public class WorkerContext : DbContext
    {
        public WorkerContext() : base("Workers")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Person> Workers { get; set; }
        public DbSet<Weekend> HolyDays { get; set; }
        public DbSet<Team> Teams{ get; set; }
        public DbSet<GlobalSetting> GlobalSettings { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                 .HasOptional(s => s.Team)
                 .WithMany(g => g.Workers)
                 .HasForeignKey(fk => fk.TeamId)
                 .WillCascadeOnDelete(false);
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

    }
}
