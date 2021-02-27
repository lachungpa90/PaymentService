using PaymentAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentAPI.Interfaces
{
    public interface IEntityHelper
    {
        Task Insert(PaymentDetail paymentDetail);
        Task<List<PaymentDetail>> GetAll();
    }
}
