using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAPI.Model.ImageModel
{
    public class TouristSpotImageModel
    {
        [Key]
        [Required]
        public int TouristSpot_img_id { get; set; }
        [Required]
        public string photo_url { get; set; }

        [default: DateTime.now]
        public DateTime created_at { get; }

        // foreign key 
        public string TouristSpot_id { get; set; }
        public virtual TouristSpotModel? TouristSpot { get; set; }
    }
}
