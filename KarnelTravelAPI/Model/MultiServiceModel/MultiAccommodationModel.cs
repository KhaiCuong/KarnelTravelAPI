namespace KarnelTravelAPI.Model.MultiServiceModel
{
    public class MultiAccommodationModel
    {
        public int Tour_id { get; set; }
        public virtual TourModel Tours { get; set; }
        public string Accommodation_id { get; set; }
        public virtual AccommodationModel Accommodations { get; set; }



        [default: DateTime.now]
        public DateTime created_at { get; }
    }
}
