using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<FeedbackModel>> GetFeedbacks();
        Task<FeedbackModel> GetFeedbacksById(int Booking_id);
        Task<FeedbackModel> AddFeedback(FeedbackModel Feedback);
        Task<FeedbackModel> UpdateFeedback(FeedbackModel Feedback);
        Task<bool> DeleteFeedback(int Feedback_id);
    }
}
