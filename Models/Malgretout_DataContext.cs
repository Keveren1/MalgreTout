using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MalgreTout.Models
{
    public partial class Malgretout_DataContext : DbContext
    {
        public virtual DbSet<NewAllUdleveringssted> NewAllUdleveringssted { get; set; }

        public Malgretout_DataContext(DbContextOptions<Malgretout_DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = MalgreTout; Integrated Security=False;Persist Security Info=False;");
            }
        }                             

        //Denne bruges til Azure portal database (denne kører ikke på nuværende tidspunkt) 
        /*optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MalgreTout;Integrated Security=False;Trust Server Certificate=True;Command Timeout=30");
        optionsBuilder.UseSqlServer("Data Source=malgretoutnew.database.windows.net; Initial Catalog=MalgreTout;User ID=Malthe;Password=Zealand123; Integrated Security=False;Persist Security Info=False;");*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewAllUdleveringssted>(entity =>
            {
                entity.Property(e => e.Adresse).IsUnicode(false);

                entity.Property(e => e.Bynavn).IsUnicode(false);

                entity.Property(e => e.Mail).IsUnicode(false);

                entity.Property(e => e.Person).IsUnicode(false);

                entity.Property(e => e.Virksomhed).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
