using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project1.data
{
    public partial class Project1DBContext : DbContext
    {
        public Project1DBContext()
        {
        }

        public Project1DBContext(DbContextOptions<Project1DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("locations", "pizzaproject");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cheeseinventory).HasColumnName("cheeseinventory");

                entity.Property(e => e.Orderhistory)
                    .HasColumnName("orderhistory")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pepperoniinventory).HasColumnName("pepperoniinventory");

                entity.Property(e => e.Sausageinventory).HasColumnName("sausageinventory");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Orderid);

                entity.ToTable("orders", "pizzaproject");

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cheesepizza).HasColumnName("cheesepizza");

                entity.Property(e => e.Currentprice).HasColumnName("currentprice");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.Ordertime)
                    .HasColumnName("ordertime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pepperonipizza).HasColumnName("pepperonipizza");

                entity.Property(e => e.Sausagepizza).HasColumnName("sausagepizza");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(30);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__username__59FA5E80");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("users", "pizzaproject");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(30)
                    .ValueGeneratedNever();

                entity.Property(e => e.Defaultlocationid).HasColumnName("defaultlocationid");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(30);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(30);
            });
        }
    }
}
