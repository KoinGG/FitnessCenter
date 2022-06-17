using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FitnessCenter
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public virtual DbSet<Coach> Coaches { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderStatusType> OrderStatusTypes { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<RoleType> RoleTypes { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<SubscriptionList> SubscriptionLists { get; set; } = null!;
        public virtual DbSet<SubscriptionType> SubscriptionTypes { get; set; } = null!;
        public virtual DbSet<TrainingType> TrainingTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<training> training { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=mssql;Database=gr602_stmti;Integrated Security=true; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>(entity =>
            {
                entity.HasKey(e => e.IdCoach)
                    .HasName("PK__Coach__448A1C7C53D9EE98");

                entity.ToTable("Coach");

                entity.Property(e => e.IdCoach).HasColumnName("idCoach");

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.Property(e => e.Surname).HasMaxLength(25);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__Order__C8AAF6FFB1B11414");

                entity.ToTable("Order");

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

                entity.Property(e => e.Amount).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IdCoach).HasColumnName("idCoach");

                entity.Property(e => e.IdOrderStatusType).HasColumnName("idOrderStatusType");

                entity.Property(e => e.IdPayment).HasColumnName("idPayment");

                entity.Property(e => e.IdSubscriptionList).HasColumnName("idSubscriptionList");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Time).HasColumnType("time(0)");

                entity.HasOne(d => d.IdCoachNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCoach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__idCoach__72C60C4A");

                entity.HasOne(d => d.IdOrderStatusTypeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdOrderStatusType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__idOrderSt__7B5B524B");

                entity.HasOne(d => d.IdPaymentNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdPayment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__idPayment__74AE54BC");

                entity.HasOne(d => d.IdSubscriptionListNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdSubscriptionList)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__idSubscri__71D1E811");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__idUser__73BA3083");
            });

            modelBuilder.Entity<OrderStatusType>(entity =>
            {
                entity.HasKey(e => e.IdOrderStatusType)
                    .HasName("PK__OrderSta__5113AF5A5922AC09");

                entity.ToTable("OrderStatusType");

                entity.Property(e => e.IdOrderStatusType).HasColumnName("idOrderStatusType");

                entity.Property(e => e.Name).HasMaxLength(15);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.IdPayment)
                    .HasName("PK__Payment__F22D4A453B68BF32");

                entity.ToTable("Payment");

                entity.Property(e => e.IdPayment).HasColumnName("idPayment");

                entity.Property(e => e.Amount).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(25);

                entity.Property(e => e.Time).HasColumnType("time(0)");

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<RoleType>(entity =>
            {
                entity.HasKey(e => e.IdRoleType)
                    .HasName("PK__RankType__B51FAA273FC36BD2");

                entity.ToTable("RoleType");

                entity.Property(e => e.IdRoleType).HasColumnName("idRoleType");

                entity.Property(e => e.Name).HasMaxLength(15);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.IdSchedule)
                    .HasName("PK__Schedule__5717CA94DBD524F0");

                entity.ToTable("Schedule");

                entity.Property(e => e.IdSchedule).HasColumnName("idSchedule");

                entity.Property(e => e.IdTraining).HasColumnName("idTraining");

                entity.HasOne(d => d.IdTrainingNavigation)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.IdTraining)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__idTrai__5BE2A6F2");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.IdSubscription)
                    .HasName("PK__Subscrip__AEF1EF213FAF5645");

                entity.ToTable("Subscription");

                entity.Property(e => e.IdSubscription).HasColumnName("idSubscription");

                entity.Property(e => e.Cost).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.IdSchedule).HasColumnName("idSchedule");

                entity.Property(e => e.IdSubscriptionType).HasColumnName("idSubscriptionType");

                entity.Property(e => e.Validity).HasMaxLength(25);

                entity.HasOne(d => d.IdScheduleNavigation)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.IdSchedule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subscript__idSch__619B8048");

                entity.HasOne(d => d.IdSubscriptionTypeNavigation)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.IdSubscriptionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subscript__idSub__60A75C0F");
            });

            modelBuilder.Entity<SubscriptionList>(entity =>
            {
                entity.HasKey(e => e.IdSubscriptionList)
                    .HasName("PK__Subscrip__424DE1E869B955F2");

                entity.ToTable("SubscriptionList");

                entity.Property(e => e.IdSubscriptionList).HasColumnName("idSubscriptionList");

                entity.Property(e => e.IdSubscription).HasColumnName("idSubscription");

                entity.HasOne(d => d.IdSubscriptionNavigation)
                    .WithMany(p => p.SubscriptionLists)
                    .HasForeignKey(d => d.IdSubscription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subscript__idSub__6477ECF3");
            });

            modelBuilder.Entity<SubscriptionType>(entity =>
            {
                entity.HasKey(e => e.IdSubscriptionType)
                    .HasName("PK__Subscrip__7683B663F56C77BC");

                entity.ToTable("SubscriptionType");

                entity.Property(e => e.IdSubscriptionType).HasColumnName("idSubscriptionType");

                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<TrainingType>(entity =>
            {
                entity.HasKey(e => e.IdTrainingType)
                    .HasName("PK__Training__1BB6B91B9D185539");

                entity.ToTable("TrainingType");

                entity.Property(e => e.IdTrainingType).HasColumnName("idTrainingType");

                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__3717C982FC406A24");

                entity.ToTable("User");

                entity.HasIndex(e => e.Login, "UQ__User__5E55825B814AA70E")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__User__85FB4E38B1F6DE34")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__User__A9D10534584F7B73")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IdRoleType).HasColumnName("idRoleType");

                entity.Property(e => e.Login).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.Patronymic).HasMaxLength(25);

                entity.Property(e => e.PhoneNumber).HasMaxLength(25);

                entity.Property(e => e.Surname).HasMaxLength(25);

                entity.HasOne(d => d.IdRoleTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRoleType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__idRoleType__7D439ABD");
            });

            modelBuilder.Entity<training>(entity =>
            {
                entity.HasKey(e => e.IdTraining)
                    .HasName("PK__Training__509B5960C1CA935C");

                entity.ToTable("Training");

                entity.Property(e => e.IdTraining).HasColumnName("idTraining");

                entity.Property(e => e.IdTrainingType).HasColumnName("idTrainingType");

                entity.Property(e => e.Time).HasMaxLength(25);

                entity.HasOne(d => d.IdTrainingTypeNavigation)
                    .WithMany(p => p.training)
                    .HasForeignKey(d => d.IdTrainingType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Training__idTrai__59063A47");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
