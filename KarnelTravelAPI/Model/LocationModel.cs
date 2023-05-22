using KarnelTravelAPI.Model.ImageModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace KarnelTravelAPI.Model
{
    public class LocationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Location_id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-20 characters")]
        public string Location_name { get; set; }
        public string? Description { get; set; }

        [Required]
        public bool Status_Location { get; set; }

        [default: DateTime.now]
        public DateTime created_at { get; }
        [default: DateTime.now]
        public DateTime update_at { get; }


        public virtual ICollection<TransportModel> Transports { get; set; }
        public virtual ICollection<AccommodationModel> Accommodations { get; set; }
        public virtual ICollection<TouristSpotModel> TouristSpots { get; set; }
        public virtual ICollection<RestaurantModel> Restaurants { get; set; }

        public virtual ICollection<LocationImageModel> LocationImages { get; set; }



    }
}
