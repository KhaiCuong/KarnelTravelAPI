using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service
{
    public class PaymentServiceImp : IPaymentRepository
    {
        private readonly DatabaseContext _dbContext;

        public PaymentServiceImp(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaymentModel> AddPayment(PaymentModel Payment)
        {
            PaymentModel payment = await _dbContext.Payments.FirstOrDefaultAsync(a => a.Booking_id.Equals(Payment.Booking_id));
            if (payment == null)
            {
                await _dbContext.Payments.AddAsync(payment);
                await _dbContext.SaveChangesAsync();
                return payment;
            }
            else
            {
                return null;
            }
        }

        public async Task<PaymentModel> GetPaymentById(int booking_id)
        {
            PaymentModel payment = await _dbContext.Payments.FindAsync(booking_id);


            if (payment != null)
            {

                return payment;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<PaymentModel>> GetPayments()
        {
            return await _dbContext.Payments.ToListAsync();
        }

        public async Task<PaymentModel> UpdatePayment(int booking_id)
        {
            PaymentModel payment = await _dbContext.Payments.FindAsync(booking_id);
            if (payment != null)
            {
                var status = !payment.Status_payment;
                payment.Status_payment = status;
                _dbContext.Update(payment);
                await _dbContext.SaveChangesAsync();
                return payment;

            }
            else
            {
                return null;
            }
        }
    }
}
