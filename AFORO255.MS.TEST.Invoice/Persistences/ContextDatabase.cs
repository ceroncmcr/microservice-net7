using AFORO255.MS.TEST.Invoice.Models;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Invoice.Persistences;

public class ContextDatabase : DbContext
{
    public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
    {
    }
    public DbSet<InvoiceModel> Invoice => Set<InvoiceModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvoiceModel>().ToTable("Invoice");
    }
}
