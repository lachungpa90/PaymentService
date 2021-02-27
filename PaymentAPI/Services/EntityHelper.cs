using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Entity;
using PaymentAPI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentAPI.Services
{
    public class EntityHelper : IEntityHelper
    {
        private readonly DataContext _data;
        public EntityHelper(DataContext data)
        {
            _data = data;

        }
        public async Task<List<PaymentDetail>> GetAll()
        {
            return await _data.PaymentDetails.ToListAsync();
        }

        public async Task  Insert(PaymentDetail paymentDetail)
        {
           _data.PaymentDetails.Add(paymentDetail);
           await  _data.SaveChangesAsync();
        }
    }
}
