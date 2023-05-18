﻿using KarnelTravelAPI.Model.ImageModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAPI.Model
{
    public class TouristSpotModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TouristSpot_id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-20 characters")]
        public string TouristSpot_name { get; set; }
        public string? Activities { get; set; }
        public string? Description { get; set; }

        [default: DateTime.now]
        public DateTime created_at { get; }
        [default: DateTime.now]
        public DateTime update_at { get; }


        // foreign key 
        public string Location_id { get; set; }
        public virtual LocationModel Location { get; set; }


        public virtual ICollection<TouristSpotImageModel> TouristSpotImages { get; set; }
        public virtual ICollection<TourModel> TourModels { get; set; }


    }
}