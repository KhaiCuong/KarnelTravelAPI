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
        public string User_id { get; set; }
        public virtual UserModel User { get; set; }


        public virtual ICollection<TourModel> TourModels { get; set; }

    }
}
