using Microsoft.EntityFrameworkCore;
using Model.Model;


namespace VMO_Back
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<ContractType> ContractType { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<AllocatedAssets> AllocatedAssets { get; set; }
        public DbSet<Allowance> Allowance { get; set; }
        public DbSet<Benefit> Benefit { get; set; }
        public DbSet<SalaryProfile> SalaryProfile { get; set; }
        public DbSet<BenefitSalaryProfile> BenefitSalaryProfiles { get; set; }
        public DbSet<AllowanceSalaryProfile> AllowanceSalaryProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Employee
            modelBuilder.Entity<AllocatedAssets>()
                .HasOne(d => d.Employee)
                .WithMany(c => c.AllocatedAssets)
                .HasForeignKey(a => a.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Title)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.TitleId);

            modelBuilder.Entity<Title>()
               .HasOne(sp => sp.Department)
               .WithMany(b => b.Titles)
               .HasForeignKey(b => b.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasOne(sp => sp.Department)
                .WithMany(b => b.Employees)
                .HasForeignKey(b => b.DepartmentId);

            modelBuilder.Entity<Contract>()
                .HasOne(e => e.Employee)
                .WithOne(c => c.Contract)
                .HasForeignKey<Contract>(c => c.EmployeeId);


            modelBuilder.Entity<Contract>()
                .HasOne(e => e.ContractType)
                .WithMany(c => c.Contracts)
                .HasForeignKey(b => b.ContractTypeId);

            modelBuilder.Entity<Contract>()
                .HasOne(e => e.SalaryProfile)
                .WithOne(c => c.Contract)
                .HasForeignKey<Contract>(e => e.SalaryProfileId);

            modelBuilder.Entity<BenefitSalaryProfile>()
                .HasKey(bsp => new { bsp.BenefitId, bsp.SalaryProfileId });

            modelBuilder.Entity<BenefitSalaryProfile>()
                .HasOne(bsp => bsp.Benefit)
                .WithMany(b => b.BenefitSalaryProfiles)
                .HasForeignKey(bsp => bsp.BenefitId);

            modelBuilder.Entity<BenefitSalaryProfile>()
                .HasOne(bsp => bsp.SalaryProfile)
                .WithMany(sp => sp.BenefitSalaryProfiles)
                .HasForeignKey(bsp => bsp.SalaryProfileId);

            modelBuilder.Entity<SalaryProfile>()
                .HasOne(sp => sp.Employee)
                .WithOne(b => b.SalaryProfile)
                .HasForeignKey<SalaryProfile>(bsp => bsp.EmployeeId);
        }
    }
}
