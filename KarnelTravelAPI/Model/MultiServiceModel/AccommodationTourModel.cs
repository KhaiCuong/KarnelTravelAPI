using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAPI.Model.MultiServiceModel
{
    public class AccommodationTourModel
    {

        public string Tour_id { get; set; }
        public virtual TourModel? Tours { get; set; }
        public string Accommodation_id { get; set; }
        public virtual AccommodationModel? Accommodations { get; set; }



        [default: DateTime.now]
        public DateTime created_at { get; }
    }
}
