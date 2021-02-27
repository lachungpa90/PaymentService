using PaymentAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Interfaces
{
    public interface IEntityHelper
    {
        Task Insert(PaymentDetail paymentDetail);
        Task<List<PaymentDetail>> GetAll();
    }
}
