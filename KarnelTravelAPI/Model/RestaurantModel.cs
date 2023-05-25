using KarnelTravelAPI.Model.ImageModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Model
{
    public class RestaurantModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Restaurant_id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-20 characters")]
        public string Restaurant_name { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rate must be 1-5 start")]
        public int Rate { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.Currency)]
        [Range(1, 100000000000, ErrorMessage = "Quantity must be greater than 1")]
        public decimal Price { get; set; }
        [Required]
        public bool Status_Restaurant { get; set; }
        public int? Discount { get; set; }

        [default: DateTime.now]
        public DateTime created_at { get; }
        [default: DateTime.now]
        public DateTime update_at { get; }



        // foreign key 
        public string Location_id { get; set; }
        public virtual LocationModel? Location { get; set; }


        public virtual ICollection<RestaurantImageModel>? RestaurantImages { get; set; }
        public virtual ICollection<RestaurantTourModel>? RestaurantTours { get; set; }
        //public virtual ICollection<BookSingleServiceModel> BookSingleServices { get; set; }
        public virtual ICollection<BookingModel>? Bookings { get; set; }

    }
}
