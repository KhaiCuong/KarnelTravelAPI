using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAPI.Model.ImageModel
{
    public class RestaurantImageModel
    {
        [Key]
        [Required]
        public int Restaurant_img_id { get; set; }
        [Required]
        public string photo_url { get; set; }

        [default: DateTime.now]
        public DateTime created_at { get; }

        // foreign key 
        public string Restaurant_id { get; set; }
        public virtual RestaurantModel? Restaurant { get; set; }
    }
}
