using AFORO255.MS.TEST.Invoice.DTOs;
using AFORO255.MS.TEST.Invoice.Persistences;

namespace AFORO255.MS.TEST.Invoice.Services;

public class InvoiceService : IInvoiceService
{
    private readonly ContextDatabase _context;

    public InvoiceService(ContextDatabase context) => _context = context;

    public IEnumerable<InvoiceResponse> GetAll() { 
        var result = _context.Invoice.ToList();
        var response = new List<InvoiceResponse>();

        foreach (var item in result) 
        {
            response.Add(new InvoiceResponse()
            { 
                InvoiceId = item.InvoiceId,
                Amount = item.Amount,
                State = item.State,
            });
        }

        return response;
    }


    public InvoiceResponse GetById(int id)
    {
        var result = _context.Invoice.FirstOrDefault(x => x.InvoiceId == id);

        var response = new InvoiceResponse()
        {
            InvoiceId = result.InvoiceId,
            Amount = result.Amount,
            State = result.State,
        };

        return response;
    }
}
