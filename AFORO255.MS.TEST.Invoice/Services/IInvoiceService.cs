using AFORO255.MS.TEST.Invoice.DTOs;

namespace AFORO255.MS.TEST.Invoice.Services;

public interface IInvoiceService
{
    IEnumerable<InvoiceResponse> GetAll();
    InvoiceResponse GetById(int id);
}
