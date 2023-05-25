using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KarnelTravelAPI.Model
{
    public class BookingModel
    {
        [Key]
        [Required]
        public int booking_id { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Quantity must be greater than 1")]
        public int Quantity { get; set; }
        [default: DateTime.now]
        public DateTime created_at { get; }
        [default: DateTime.now]
        public DateTime update_at { get; }

        // foreign key 
        //public string User_id { get; set; }
        //public virtual UserModel User { get; set; }
        //public string Tour_id { get; set; }
        //public virtual TourModel Tour { get; set; }


        public int User_id { get; set; }
        public virtual UserModel? User { get; set; }
        public int? Tour_id { get; set; }
        public virtual TourModel? Tour { get; set; }
        public string? Accommodation_id { get; set; }
        public virtual AccommodationModel? Accommodation { get; set; }
        public string? Restaurant_id { get; set; }
        public virtual RestaurantModel? Restaurant { get; set; }
        public string? TouristSpot_id { get; set; }
        public virtual TouristSpotModel? TouristSpot { get; set; }
        public string? Transport_id { get; set; }
        public virtual TransportModel? Transport { get; set; }

        public virtual ICollection<FeedbackModel>? Feedbacks { get; set; }
        public virtual ICollection<PaymentModel>? Payments { get; set; }


    }
}
