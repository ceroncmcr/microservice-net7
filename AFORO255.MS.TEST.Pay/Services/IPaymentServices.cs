using AFORO255.MS.TEST.Pay.Models;

namespace AFORO255.MS.TEST.Pay.Services;

public interface IPaymentServices
{
    PaymentModel Payment(PaymentModel payment);
}
