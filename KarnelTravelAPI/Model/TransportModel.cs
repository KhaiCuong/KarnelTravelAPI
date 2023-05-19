using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KarnelTravelAPI.Model.MultiServiceModel;
using KarnelTravelAPI.Model.SingleServiceModel;

namespace KarnelTravelAPI.Model
{
    public class TransportModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Transport_id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-20 characters")]
        public string Transport_name { get; set; }
        public string Start_position { get; set; }
        [DataType(DataType.Currency)]
        [Range(1, 100000000000, ErrorMessage = "Quantity must be greater than 1")]
        public decimal Price { get; set; }

        [default: DateTime.now]
        public DateTime created_at { get; }
        [default: DateTime.now]
        public DateTime update_at { get; }

        // foreign key 
        public string Location_id { get; set; }
        public virtual LocationModel Location { get; set; }


        public virtual ICollection<MultiTransportModel> MultiTransports { get; set; }

        //public virtual ICollection<BookSingleServiceModel> BookSingleServices { get; set; }

        public virtual ICollection<BookingModel> Bookings { get; set; }




    }
}
