﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;  
using System.Collections.Generic;  
using System.Data.SqlClient;  
using System.Threading.Tasks;  
using Microsoft.EntityFrameworkCore;  
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MalgreTout.Models
{
    public partial class Malgretout_DataContext : DbContext
    {
       /* public Malgretout_DataContext()
        {
        }*/

        public Malgretout_DataContext(DbContextOptions<Malgretout_DataContext> options)
            : base(options)
        {
        }

      
        public virtual DbSet<Kontaktperson> Kontaktperson { get; set; }
        public virtual DbSet<Udleveringssted> Udleveringssted { get; set; }
        public virtual DbSet<Postnumre> Postnumre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=malgretoutnew.database.windows.net; Initial Catalog=MalgreTout;User ID=Malthe;Password=Zealand123; Integrated Security=False;Persist Security Info=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Kontaktperson>(entity =>
            {
                //Database er sat til AUTO Increment (Id IDENTITY 1,1) derfor har jeg udkommenteret denne linje da vi ikke skal tilføje Id. 
               // entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Mail).IsUnicode(false);

                entity.Property(e => e.Tlf).ValueGeneratedNever();

                entity.Property(e => e.Person).IsUnicode(false);
            });

            modelBuilder.Entity<Udleveringssted>(entity =>
            {
                //entity.Property(e => e.Id).ValueGeneratedNever();
               
               entity.Property(e => e.Virksomhed).IsUnicode(false);
               
               entity.Property(e => e.Adresse).IsUnicode(false);
               
            });
            
            modelBuilder.Entity<Postnumre>(entity =>
            {
                // entity.Property(e => e.Id).ValueGeneratedNever();
               
                entity.Property(e => e.Postnr).IsUnicode(false);
               
                entity.Property(e => e.Bynavn).IsUnicode(false);
               
            });
            
            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
        
    }
}