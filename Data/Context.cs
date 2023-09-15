using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LawFirmTemplate.Data
{
    public class Context : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-T1U3KI6\\SQLSERVER2017EXP;database=LawFirmTemplateDB;integrated security=true;TrustServerCertificate=True");
        }

        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<PracticeAreas> PracticeAreas { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<GeneralSetting> GeneralSettings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        
    }
}
