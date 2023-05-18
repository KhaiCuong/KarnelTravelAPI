using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAPI.Model
{
    public class FeedbackModel
    {
        [Key]
        [Required]
        public int Feedback_id { get; set; }
        public string? content { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rate must be 1-5 start")]
        public int Rate { get; set; }

        [default: DateTime.now]
        public DateTime created_at { get; }


        // foreign key 
        public string booking_id { get; set; }
        public virtual BookingModel Booking { get; set; }

    }
}
