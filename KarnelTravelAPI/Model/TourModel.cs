using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAPI.Model
{
    public class TourModel
    {
        [Key]
        [Required]
        public int Tour_id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3-20 characters")]
        public string Tour_name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Quantity must be 1-100")]
        public int Quantity { get; set; }
        [Required]
        public DateTime Depature_date { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Quantity must be greater than 1")]
        public int Times { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(1, 100000000000, ErrorMessage = "Quantity must be greater than 1")]
        public decimal Price { get; set; }
        public string? Description { get; set; }

        [default: DateTime.now]
        public DateTime created_at { get; }
        [default: DateTime.now]
        public DateTime update_at { get; }



        // foreign key 
        public string Accommodation_id { get; set; }
        public virtual AccommodationModel Accommodation { get; set; }
        public string Restaurant_id { get; set; }
        public virtual RestaurantModel Restaurant { get; set; }
        public string TouristSpot_id { get; set; }
        public virtual TouristSpotModel TouristSpot { get; set; }
        public string Transport_id { get; set; }
        public virtual TransportModel Transport { get; set; }


        public virtual ICollection<BookingModel> Bookings { get; set; }

    }
}
