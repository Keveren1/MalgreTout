using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MalgreTout.Models
{
    public partial class Malgretout_DataContext : DbContext
    {
        public virtual DbSet<Kontaktperson> Kontaktperson { get; set; }
        public virtual DbSet<Udleveringssted> Udleveringssted { get; set; }

        public Malgretout_DataContext(DbContextOptions<Malgretout_DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=malgretout.database.windows.net; Initial Catalog=malgretout_data;User ID=Malthe;Password=Zealand123; Integrated Security=False;Persist Security Info=False;;");
            }
        }

        internal object Entry(object kontaktperson)
        {
            throw new NotImplementedException();
        }

        //"Data Source=malgretout.database.windows.net;Initial Catalog=malgretout_data;Persist Security Info=True;User ID=Malthe;Password=Zealand123;Trust Server Certificate=True;Command Timeout=300"
        //Data Source=malgretout.database.windows.net; Initial Catalog=malgretout_data;User ID=Malthe; Integrated Security=SSPI;Persist Security Info=False;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kontaktperson>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Mail).IsUnicode(false);

                entity.Property(e => e.Person).IsUnicode(false);
            });

            modelBuilder.Entity<Udleveringssted>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Adresse).IsUnicode(false);

                entity.Property(e => e.Virksomhed).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
