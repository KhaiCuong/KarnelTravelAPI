using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<PaymentModel>> GetPayments();
        Task<PaymentModel> GetPaymentById(int Payment_id);
        Task<PaymentModel> AddPayment(PaymentModel Payment);
        Task<PaymentModel> UpdatePayment(PaymentModel Payment);
        //Task<bool> DeletePayment(int Payment_id);
    }
}
