using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAPI.Model.ImageModel
{
    public class LocationImageModel
    {
        [Key]
        [Required]
        public int Location_img_id { get; set; }
        [Required]
        public string photo_url { get; set; }

        [default: DateTime.now]
        public DateTime created_at { get; }

        // foreign key 
        public string Location_id { get; set; }
        public virtual LocationModel Location { get; set; }

    }
}