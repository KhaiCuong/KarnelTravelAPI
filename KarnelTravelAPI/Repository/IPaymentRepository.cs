using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<PaymentModel>> GetPayments();
        Task<PaymentModel> GetPaymentById(int booking_id);
        Task<PaymentModel> AddPayment(PaymentModel Payment);
        Task<PaymentModel> UpdatePayment(int booking_id);
        //Task<bool> DeletePayment(int Payment_id);
    }
}
