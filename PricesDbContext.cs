using MailAttachementsTest.Managers;
using Microsoft.EntityFrameworkCore;

namespace MailAttachementsTest
{
    internal class PricesDbContext : DbContext
    {
        public DbSet<PriceItem> PriceItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;User Id=postgres;Password=123;Database=rr.test;enlist=true;Timeout=60;");
            optionsBuilder.UseNpgsql(OptionsManager.GetConnectionString());
        }
    }
}
