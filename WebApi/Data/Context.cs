using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Entities.Joins;

namespace WebApi.Data
{
    public class Context : DbContext
    {
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CorporateEvent> CorporateEvents { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<FormerEmployee> FormerEmployees { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<WorkPlace> Workplaces { get; set; }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeCorporateEvent>().HasKey(s => new { s.CorporateEventID, s.EmployeeID });
            modelBuilder.Entity<Employee>().HasOne(a => a.Account).WithOne(e => e.Employee).HasForeignKey<UserAccount>(k => k.EmployeeID);
            modelBuilder.Entity<Employee>().HasOne(w => w.WorkPlace).WithMany(e => e.Employees).HasForeignKey(k => k.WorkPlaceID);
            modelBuilder.Entity<Employee>().HasMany(v => v.Vacations).WithOne(e => e.Employee).HasForeignKey(k => k.EmployeeID);
            modelBuilder.Entity<Employee>().HasMany(d => d.Documentation).WithOne(e => e.Employee).HasForeignKey(k => k.EmployeeID);
            modelBuilder.Entity<Employee>().HasMany(b => b.Bonuses).WithOne(e => e.Employee).HasForeignKey(k => k.EmployeeID);
            modelBuilder.Entity<Employee>().HasMany(eq => eq.Equipment).WithOne(e => e.Employee).HasForeignKey(k => k.EmployeeID);
            modelBuilder.Entity<Employee>().HasMany(ev => ev.Evaluations).WithOne(e => e.Employee).HasForeignKey(k => k.EmployeeID);
            modelBuilder.Entity<WorkPlace>().HasMany(s => s.Specialties).WithOne(w => w.Workplace).HasForeignKey(k => k.WorkplaceID);
            modelBuilder.Entity<FormerEmployee>().HasMany(d => d.Documentation).WithOne(f => f.FormerEmployee).HasForeignKey(k => k.EmployeeID);
            modelBuilder.Entity<Candidate>().HasMany(d => d.Documentation).WithOne(c => c.Candidate).HasForeignKey(k => k.EmployeeID);
        }
    }
}
