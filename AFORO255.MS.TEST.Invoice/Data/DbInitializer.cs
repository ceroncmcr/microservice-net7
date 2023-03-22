using AFORO255.MS.TEST.Invoice.Models;
using AFORO255.MS.TEST.Invoice.Persistences;

namespace AFORO255.MS.TEST.Invoice.Data;

public class DbInitializer
{
    public static void Initialize(ContextDatabase context)
    { 
        context.Database.EnsureCreated();

        if (context.Invoice.Any()) return;

        var invoices = new InvoiceModel[]
        { 
            new InvoiceModel{ InvoiceId = 1, Amount = 500, State = 0},
            new InvoiceModel{ InvoiceId = 2, Amount = 500, State = 0},
            new InvoiceModel{ InvoiceId = 3, Amount = 500, State = 0},
            new InvoiceModel{ InvoiceId = 4, Amount = 500, State = 0},
            new InvoiceModel{ InvoiceId = 5, Amount = 500, State = 0},
            new InvoiceModel{ InvoiceId = 6, Amount = 500, State = 0},
            new InvoiceModel{ InvoiceId = 7, Amount = 500, State = 0},
        };

        foreach (var invoice in invoices) { 
            context.Invoice.Add(invoice);
        }

        context.SaveChanges();
    }
}
