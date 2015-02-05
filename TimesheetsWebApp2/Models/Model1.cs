namespace TimesheetsWebApp2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ColorShop> ColorShops { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HoursWorked> HoursWorkeds { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<TimeSheet> TimeSheets { get; set; }
        public virtual DbSet<WagedEmployee> WagedEmployees { get; set; }
        public virtual DbSet<WeeklyTotal> WeeklyTotals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColorShop>()
                .Property(e => e.ShopName)
                .IsUnicode(false);

            modelBuilder.Entity<ColorShop>()
                .HasMany(e => e.HoursWorkeds)
                .WithRequired(e => e.ColorShop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ColorShop>()
                .HasMany(e => e.Managers)
                .WithRequired(e => e.ColorShop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ColorShop>()
                .HasMany(e => e.TimeSheets)
                .WithRequired(e => e.ColorShop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ColorShop>()
                .HasMany(e => e.WagedEmployees)
                .WithRequired(e => e.ColorShop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WeeklyTotals)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.HoursWorkeds)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Managers)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.TimeSheets)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.ApprovedBy);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.TimeSheets1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.PreparedBy);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WagedEmployees)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoursWorked>()
                .Property(e => e.StartTime)
                .HasPrecision(0);

            modelBuilder.Entity<HoursWorked>()
                .Property(e => e.EndTime)
                .HasPrecision(0);

            modelBuilder.Entity<TimeSheet>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<TimeSheet>()
                .Property(e => e.TimesheetFileName)
                .IsUnicode(false);
        }
    }
}
