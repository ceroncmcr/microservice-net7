using AFORO255.MS.TEST.Pay.Models;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Pay.Persistences;

public class ContextDatabase : DbContext
{
    public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
    {
    }

    public DbSet<PaymentModel> Payment => Set<PaymentModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PaymentModel>().ToTable("Payment");
    }
}
