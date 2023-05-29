namespace KarnelTravelAPI.Model.MultiServiceModel
{
    public class TransportTourModel
    {
        public string Tour_id { get; set; }
        public virtual TourModel? Tours { get; set; }
        public string Transport_id { get; set; }
        public virtual TransportModel? Transports { get; set; }



        [default: DateTime.now]
        public DateTime created_at { get; }



        
    }
}
