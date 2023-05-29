namespace KarnelTravelAPI.Model.MultiServiceModel
{
    public class RestaurantTourModel
    {

        public string Tour_id { get; set; }
        public virtual TourModel? Tours { get; set; }
        public string Restaurant_id { get; set; }
        public virtual RestaurantModel? Restaurants { get; set; }



        [default: DateTime.now]
        public DateTime created_at { get; }
    }
}
