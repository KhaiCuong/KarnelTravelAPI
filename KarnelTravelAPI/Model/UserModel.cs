using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using KarnelTravelAPI.Model.SingleServiceModel;

namespace KarnelTravelAPI.Model
{
    public class UserModel
    {
        [Key]
        [Required]
        public int User_id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-20 characters")]
        public string User_name { get; set; }
        [Required]
        public string Phone_number { get; set; }
        public string? Address { get; set; }
        [Required]
        public bool isAdmin { get; set; }
        [Required]
        [DefaultValue("Silver")]
        public string member_lever { get; set; }
        public string? Charge_card { get; set; }


        [default: DateTime.now]
        public DateTime created_at { get; }
        [default: DateTime.now]
        public DateTime update_at { get; }




        public virtual ICollection<BookingModel> Bookings { get; set; }
        //public virtual ICollection<BookSingleServiceModel> BookSingleServices { get; set; }

    }
}
