using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        private IConfiguration Configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=NewProject_DB; integrated security=true;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PaymentRoutineType>().HasData(new PaymentRoutineType
            {
                ID = 1,
                Description = "Aylık ödeme",
                Name = "Aylık",
                Status = true
            });
            builder.Entity<PaymentRoutineType>().HasData(new PaymentRoutineType
            {
                ID = 2,
                Description = "3 Aylık ödeme",
                Name = "3 Aylık",
                Status = true
            });

            builder.Entity<PaymentRoutineType>().HasData(new PaymentRoutineType
            {
                ID = 3,
                Description = " 6 Aylık ödeme",
                Name = "6 Aylık",
                Status = true
            });

            builder.Entity<PaymentRoutineType>().HasData(new PaymentRoutineType
            {
                ID = 4,
                Description = "Yıllık ödeme",
                Name = "Yıllık",
                Status = true
            });

            
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = "1",
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = "2",
                Name = "customer",
                NormalizedName = "CUSTOMER"
            });
            
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = "3",
                Name = "designer",
                NormalizedName = "DESIGNER"
            });
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = "4",
                Name = "ops",
                NormalizedName = "OPS"
            });
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = "5",
                Name = "marketing",
                NormalizedName = "MARKETING"
            });
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "22e40406-8a9d-2d82-912c-5d6a640ee696",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                NameSurname = "Sistem Yöneticisi",
                PasswordHash = "AQAAAAEAACcQAAAAEBnB8oXphFdmCsywKjHsM1T0Rqoy+MUE/X6BTKXc92U7kCDqn3k8JwfkAyO3GjGfuA==",
                SecurityStamp = "G4UWDNIBHRMGKMISDT73JLS7P3EBZMRV",
                ConcurrencyStamp = "15142b86-2dd6-4e0a-8731-0af709f5c26b"
            });
            // Add the user to the admin role
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "22e40406-8a9d-2d82-912c-5d6a640ee696"
            });
           
        }
        
        public DbSet<CustomerPayment> CustomerPayments { get; set; }
        public DbSet<CustomerProducts> CustomerProducts { get; set; }
        public DbSet<CustomerProductsFile> CustomerProductsFiles { get; set; }
        public DbSet<CustomerService> CustomerServices { get; set; }
        public DbSet<CustomerServicePlanning> CustomerServicesPlannings { get; set; }
        public DbSet<CustomerServicePlanningDate> CustomerServicesPlanningDates { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<DemandAnswer> DemandAnswers { get; set; }
        public DbSet<DemandFile> DemandFiles { get; set; }
        public DbSet<EmployeePerfonmanceScore> EmployeePerfonmanceScores { get; set; }
        public DbSet<PaymentRoutineType> PaymentRoutineTypes { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<ServicePackage> ServicePackages { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<EmployeeCalendar> EmployeeCalendar { get; set; }
        public DbSet<CustomerEmployee> CustomerEmployees { get; set; }
    }
}