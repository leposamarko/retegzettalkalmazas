// <copyright file="Db.cs" company="Z3VJC0">
// Copyright (c) Z3VJC0. All rights reserved.
// </copyright>

namespace KutyaVerseny.Data.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.EntityFrameworkCore.Metadata;

    /// <summary>
    /// main class.
    /// </summary>
    public partial class Db : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Db"/> class.
        /// This is the constructor.
        /// </summary>
        public Db()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Db"/> class.
        /// public db.
        /// </summary>
        /// <param name="options">something.</param>
        public Db(DbContextOptions<Db> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets the database of dogs.
        /// </summary>
        public virtual DbSet<Dog> Dog { get; set; }

        /// <summary>
        /// Gets or sets Intervention database.
        /// </summary>
        public virtual DbSet<Intervention> Intervention { get; set; }

        /// <summary>
        /// Gets or sets database of medals.
        /// </summary>
        public virtual DbSet<Medal> Medal { get; set; }

        /// <summary>
        /// this is the conncton for the mdf.
        /// </summary>
        /// <param name="optionsBuilder">connecton.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
                }
            }
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder?.Entity<Dog>(entity =>
            {
                entity.HasKey(e => e.ChipNum)
                    .HasName("PK__Dog__7476179439C4C731");

                entity.Property(e => e.ChipNum)
                    .HasColumnName("chip_num")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.BornDate)
                    .HasColumnName("born_date")
                    .HasColumnType("date");

                entity.Property(e => e.Breed)
                    .HasColumnName("breed")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DogName)
                    .IsRequired()
                    .HasColumnName("dog_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasColumnName("owner_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Intervention>(entity =>
            {
                entity.Property(e => e.InterventionId)
                    .HasColumnName("interventionID")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Desript)
                    .HasColumnName("desript")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Doctor)
                    .HasColumnName("doctor")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorPhone)
                    .HasColumnName("doctorPhone")
                    .HasColumnType("numeric(11, 0)");

                entity.Property(e => e.DogChipNum)
                    .HasColumnName("dog_chip_num")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.InterventionDate)
                    .HasColumnName("interventionDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.DogChipNumNavigation)
                    .WithMany(p => p.Intervention)
                    .HasForeignKey(d => d.DogChipNum)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("beavatkozas_fk");
            });

            modelBuilder.Entity<Medal>(entity =>
            {
                entity.Property(e => e.MedalId)
                    .HasColumnName("medalID")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Degree)
                    .HasColumnName("degree")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DogChipNum)
                    .HasColumnName("dog_chip_num")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.RaceName)
                    .HasColumnName("raceName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StartersNum)
                    .HasColumnName("startersNum")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.WonDate)
                    .HasColumnName("won_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.DogChipNumNavigation)
                    .WithMany(p => p.Medal)
                    .HasForeignKey(d => d.DogChipNum)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("erem_fk");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
