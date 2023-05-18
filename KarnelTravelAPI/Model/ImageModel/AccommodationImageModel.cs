using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAPI.Model.ImageModel
{
    public class AccommodationImageModel
    {
        [Key]
        [Required]
        public int Accommodation_img_id { get; set; }
        [Required]
        public string photo_url { get; set; }

        [default: DateTime.now]
        public DateTime created_at { get; }

        // foreign key 
        public string Accommodation_id { get; set; }
        public virtual AccommodationModel Accommodation { get; set; }
    }
}
