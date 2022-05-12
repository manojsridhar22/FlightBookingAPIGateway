using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdminAPIServices.Models
{
    public partial class UserDBContext : DbContext
    {
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Airline> Airline { get; set; }
        public virtual DbSet<BookingHistory> BookingHistory { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<TicketBooking> TicketBooking { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=JRDOTNETFSECO-2;Database=UserDB;User ID=sa;Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BookingHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookingDate).HasColumnType("date");

                entity.Property(e => e.Pnr).HasColumnName("PNR");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CouponCode).HasMaxLength(50);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<TicketBooking>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmailId).HasColumnName("EmailID");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastName).HasMaxLength(50);
            });
        }
    }
}
