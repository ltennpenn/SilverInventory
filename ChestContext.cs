using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Silver_Inventory
{
    public class ChestContext : DbContext
    {
        public ChestContext()
        {
        }
        public ChestContext(DbContextOptions<ChestContext> options)
    : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ChestDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(e =>
            {
                e.ToTable("Items");
                e.HasKey(a => a.ItemNumber);
                e.Property(a => a.ItemNumber)
                    .ValueGeneratedOnAdd();
                e.Property(a => a.ChestName)
                    .HasMaxLength(50)
                    .IsRequired();
                e.Property(a => a.ItemName)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(a => a.ItemType)
                    .IsRequired();
            });

            modelBuilder.Entity<Transaction>(e =>
            {
                e.ToTable("Transactions");
                e.HasKey(t => t.Id);
                e.Property(t => t.Id)
                    .ValueGeneratedOnAdd();
                e.Property(t => t.TransactionDate)
                    .IsRequired();
                e.Property(t => t.Description)
                    .IsRequired();
                e.Property(t => t.TransactionType)
                    .IsRequired();
                e.HasOne(t => t.Item)
                    .WithMany()
                    .HasForeignKey(t => t.ItemNumber);
            });
        }
    }
}
