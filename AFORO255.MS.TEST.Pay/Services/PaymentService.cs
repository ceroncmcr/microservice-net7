using AFORO255.MS.TEST.Pay.Models;
using AFORO255.MS.TEST.Pay.Persistences;

namespace AFORO255.MS.TEST.Pay.Services;

public class PaymentService : IPaymentServices
{
    private readonly ContextDatabase _contextDatabase;

    public PaymentService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;
    
    public PaymentModel Payment(PaymentModel payment)
    {
        _contextDatabase.Payment.Add(payment);
        _contextDatabase.SaveChanges();
        return payment;
    }
}
