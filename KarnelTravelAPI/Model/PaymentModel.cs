using KarnelTravelAPI.Model.MultiServiceModel;
using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAPI.Model
{
    public class PaymentModel
    {
        [Key]
        [Required]
        public int Payment_id { get; set; }
        [Required]
        public bool Status_payment { get; set; }
        [default: DateTime.now]
        public DateTime created_at { get; }
        [default: DateTime.now]
        public DateTime update_at { get; }



        // foreign key 

        public int Booking_id { get; set; }
        public virtual BookingModel ? Booking { get; set; }

    }
}
