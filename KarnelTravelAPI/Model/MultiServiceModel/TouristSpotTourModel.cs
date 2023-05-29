namespace KarnelTravelAPI.Model.MultiServiceModel
{
    public class TouristSpotTourModel
    {
        public string Tour_id { get; set; }
        public virtual TourModel? Tours { get; set; }
        public string TouristSpot_id { get; set; }
        public virtual TouristSpotModel? TouristSpots { get; set; }



        [default: DateTime.now]
        public DateTime created_at { get; }


        
    }
}
