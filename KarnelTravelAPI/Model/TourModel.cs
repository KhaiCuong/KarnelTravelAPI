using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Model
{
    public class TourModel
    {

        [Key]
        [Required]
        public string Tour_id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3-20 characters")]
        public string Tour_name { get; set; }
        [Required]
        public bool Status_tour { get; set; }
        public int? Discount { get; set; }
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



        public virtual ICollection<AccommodationTourModel>? AccommodationTours { get; set; }

        public virtual ICollection<TouristSpotTourModel>? TouristSpotTours { get; set; }

        public virtual ICollection<RestaurantTourModel>? RestaurantTours { get; set; }

        public virtual ICollection<TransportTourModel>? TransportTours { get; set; }

        public virtual ICollection<BookingModel>? Bookings { get; set; }

    }
}
