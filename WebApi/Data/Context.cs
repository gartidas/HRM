using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Entities.Joins;

namespace WebApi.Data
{
    public class Context : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CorporateEvent> CorporateEvents { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HR_Worker> HR_Workers { get; set; }
        public DbSet<WorkPlaceLeader> WorkPlaceLeaders { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<FormerEmployee> FormerEmployees { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<WorkPlace> Workplaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");

            modelBuilder.Entity<Employee>().HasOne(x => x.IdentityUser).WithMany().IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<WorkPlaceLeader>().HasOne(x => x.IdentityUser).WithMany().IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<HR_Worker>().HasOne(x => x.IdentityUser).WithMany().IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>().HasMany(ev => ev.Evaluations).WithOne(e => e.Employee).HasForeignKey(k => k.EmployeeID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Employee>().HasMany(v => v.Vacations).WithOne(e => e.Employee).HasForeignKey(k => k.EmployeeID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Employee>().HasMany(eq => eq.Equipment).WithOne(e => e.Employee).HasForeignKey(k => k.EmployeeID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Employee>().HasMany(b => b.Bonuses).WithOne(e => e.Employee).HasForeignKey(k => k.EmployeeID).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Candidate>().HasMany(d => d.Documentation).WithOne(c => c.Candidate).HasForeignKey(k => k.CandidateID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FormerEmployee>().HasMany(d => d.Documentation).WithOne(f => f.FormerEmployee).HasForeignKey(k => k.FormerEmployeeID).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkPlace>().HasMany(s => s.Specialties).WithOne(w => w.Workplace).HasForeignKey(k => k.WorkplaceID).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeCorporateEvent>().HasKey(s => new { s.CorporateEventID, s.EmployeeID });
            modelBuilder.Entity<WorkPlaceLeaderCorporateEvent>().HasKey(s => new { s.CorporateEventID, s.WorkPlaceLeaderID });

            modelBuilder.Entity<Employee>().HasMany(d => d.Documentation).WithOne(e => e.Employee).HasForeignKey(k => k.EmployeeID);
            modelBuilder.Entity<Employee>().HasOne(w => w.WorkPlace).WithMany(e => e.Employees).HasForeignKey(k => k.WorkPlaceID);
            modelBuilder.Entity<HR_Worker>().HasMany(b => b.Bonuses).WithOne(h => h.HR_Worker).HasForeignKey(k => k.HR_WorkerID);
            modelBuilder.Entity<HR_Worker>().HasMany(ev => ev.Evaluations).WithOne(h => h.HR_Worker).HasForeignKey(k => k.HR_WorkerID);
            modelBuilder.Entity<HR_Worker>().HasMany(f => f.FormerEmployees).WithOne(h => h.HR_Worker).HasForeignKey(k => k.HR_WorkerID);
            modelBuilder.Entity<WorkPlace>().HasOne(wpl => wpl.WorkPlaceLeader).WithOne(w => w.WorkPlace).HasForeignKey<WorkPlace>(k => k.WorkPlaceLeaderID);
        }
    }
}
