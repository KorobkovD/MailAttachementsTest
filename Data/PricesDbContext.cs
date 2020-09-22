using MailAttachementsTest.Entities;
using MailAttachementsTest.Managers;
using Microsoft.EntityFrameworkCore;

namespace MailAttachementsTest.Data
{
    internal class PricesDbContext : DbContext
    {
        public DbSet<PriceItem> PriceItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(OptionsManager.GetConnectionString());
        }
    }
}
