using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service
{
    public class FeedbackServiceImp : IFeedbackRepository
    {
        private readonly DatabaseContext _databaseContext;

        public FeedbackServiceImp(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<FeedbackModel> AddFeedback(FeedbackModel Feedback)
        {
            //var fb = await _databaseContext.Feedbacks.FirstOrDefaultAsync(p => p.booking_id.Equals(Feedback.booking_id));
            //if (fb == null)
            //{
                await _databaseContext.Feedbacks.AddAsync(Feedback);
                await _databaseContext.SaveChangesAsync();
                return Feedback;

            //}
            //else
            //{
            //    return null;
            //}
        }

        public async Task<bool> DeleteFeedback(int Feedback_id)
        {
            FeedbackModel fb = await _databaseContext.Feedbacks.FindAsync(Feedback_id);


            if (fb != null)
            {
                _databaseContext.Feedbacks.Remove(fb);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<IEnumerable<FeedbackModel>> GetFeedbacks()
        {
            return await _databaseContext.Feedbacks.ToListAsync();
        }

        public async Task<FeedbackModel> GetFeedbacksById(int Feedback_id)
        {
            FeedbackModel fb = await _databaseContext.Feedbacks.FirstOrDefaultAsync(p => p.Feedback_id.Equals(Feedback_id));
            if (fb != null)
            {
                return fb;
            }
            else
            {
                return null;
            }
        }

        public async Task<FeedbackModel> UpdateFeedback(FeedbackModel Feedback)
        {
            FeedbackModel fb = await _databaseContext.Feedbacks.FirstOrDefaultAsync(p => p.Feedback_id.Equals(Feedback.Feedback_id));
            if (fb != null)
            {
                _databaseContext.Entry(Feedback).State = EntityState.Modified;
                await _databaseContext.SaveChangesAsync();
                return Feedback;
            }
            else
            {
                return null;
            }
        }
    }
}
