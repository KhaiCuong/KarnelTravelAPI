using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Model
{
    public class AccommodationModel
    {
  
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Accommodation_id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-20 characters")]
        public string Accommodation_name { get; set; }
        [Required]
        [Range(1,5, ErrorMessage = "Rate must be 1-5 start")]
        public int Rate { get; set; }
        [Required]
        public bool Type { get; set; } // 1 is Resort , 0 is Hotel
        public string? Description { get; set; }
        [DataType(DataType.Currency)]
        [Range(1, 100000000000, ErrorMessage = "Quantity must be greater than 1")]
        public decimal Price { get; set; }

        [Required]
        public bool Status_Accommodation { get; set; }
        public int? Discount { get; set; }

        [default: DateTime.now]
        public DateTime created_at { get; }
        [default: DateTime.now]
        public DateTime update_at { get; }



        // foreign key 
        public string Location_id { get; set; }
        public virtual LocationModel? Location { get; set; }


        public virtual ICollection<AccommodationImageModel>? AccommodationImages { get; set; }
        public virtual ICollection<AccommodationTourModel>? AccommodationTours { get; set; }
        //public virtual ICollection<BookSingleServiceModel> BookSingleServices { get; set; }


        public virtual ICollection<BookingModel>? Bookings { get; set; }





    }
}
