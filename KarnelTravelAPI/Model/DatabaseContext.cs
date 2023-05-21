using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Model.MultiServiceModel;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // *** Intermediate table
            // TourModel - AccommodationModel (intermediate table : MultiAccommodationModel)
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MultiAccommodationModel>()
            .HasKey(t => new { t.Accommodation_id });
            modelBuilder.Entity<MultiAccommodationModel>()
                .HasOne(e => e.Accommodations)
                .WithMany(e => e.MultiAccommodations)
                .HasForeignKey(e => e.Accommodation_id);
            modelBuilder.Entity<MultiAccommodationModel>()
                .HasOne(e => e.Tours)
                .WithMany(e => e.MultiAccommodations)
                .HasForeignKey(e => e.Tour_id);
            // TourModel - RestauranModel (intermediate table : MultiRestaurantModel)
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MultiRestaurantModel>()
            .HasKey(t => new { t.Restaurant_id });
            modelBuilder.Entity<MultiRestaurantModel>()
                .HasOne(e => e.Restaurants)
                .WithMany(e => e.MultiRestaurants)
                .HasForeignKey(e => e.Restaurant_id);
            modelBuilder.Entity<MultiRestaurantModel>()
                .HasOne(e => e.Tours)
                .WithMany(e => e.MultiRestaurants)
                .HasForeignKey(e => e.Tour_id);
            // TourModel - TouristSpotModel (intermediate table : MultiTouristSpotModel)
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MultiTouristSpotModel>()
            .HasKey(t => new { t.TouristSpot_id });
            modelBuilder.Entity<MultiTouristSpotModel>()
                .HasOne(e => e.TouristSpots)
                .WithMany(e => e.MultiTouristSpots)
                .HasForeignKey(e => e.TouristSpot_id);
            modelBuilder.Entity<MultiTouristSpotModel>()
                .HasOne(e => e.Tours)
                .WithMany(e => e.MultiTouristSpots)
                .HasForeignKey(e => e.Tour_id);
            // TourModel - TouristSpotModel (intermediate table : MultiTransportModel)
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MultiTransportModel>()
            .HasKey(t => new { t.Transport_id });
            modelBuilder.Entity<MultiTransportModel>()
                .HasOne(e => e.Transports)
                .WithMany(e => e.MultiTransports)
                .HasForeignKey(e => e.Transport_id);
            modelBuilder.Entity<MultiTransportModel>()
                .HasOne(e => e.Tours)
                .WithMany(e => e.MultiTransports)
                .HasForeignKey(e => e.Tour_id);




            // *** Image table
            // AccommodationModel - AccommodationImageModel 
            modelBuilder.Entity<AccommodationImageModel>()
                           .HasOne(e => e.Accommodation)
                           .WithMany(e => e.AccommodationImages)
                           .HasForeignKey(e => e.Accommodation_id);
            // LocationModel - LocationImageModel 
            modelBuilder.Entity<LocationImageModel>()
                           .HasOne(e => e.Location)
                           .WithMany(e => e.LocationImages)
                           .HasForeignKey(e => e.Location_id);
            // RestaurantModel - RestaurantImageModel 
            modelBuilder.Entity<RestaurantImageModel>()
                           .HasOne(e => e.Restaurant)
                           .WithMany(e => e.RestaurantImages)
                           .HasForeignKey(e => e.Restaurant_id);
            // TouristSpotModel - TouristSpotImageModel 
            modelBuilder.Entity<TouristSpotImageModel>()
                           .HasOne(e => e.TouristSpot)
                           .WithMany(e => e.TouristSpotImages)
                           .HasForeignKey(e => e.TouristSpot_id);




            // *** Location table 
            // LocationModel - AccommodationModel
            modelBuilder.Entity<AccommodationModel>()
                       .HasOne(e => e.Location)
                       .WithMany(e => e.Accommodations)
                       .HasForeignKey(e => e.Location_id);
            // LocationModel - RestaurantModel
            modelBuilder.Entity<RestaurantModel>()
                       .HasOne(e => e.Location)
                       .WithMany(e => e.Restaurants)
                       .HasForeignKey(e => e.Location_id);
            // LocationModel - TouristSpotModel
            modelBuilder.Entity<TouristSpotModel>()
                       .HasOne(e => e.Location)
                       .WithMany(e => e.TouristSpots)
                       .HasForeignKey(e => e.Location_id);
            // LocationModel - TransportModel
            modelBuilder.Entity<TransportModel>()
                       .HasOne(e => e.Location)
                       .WithMany(e => e.Transports)
                       .HasForeignKey(e => e.Location_id);



            // *** Service 
           // Book Tour
            modelBuilder.Entity<BookingModel>()
                        .HasOne(e => e.Tour)
                        .WithMany(e => e.Bookings)
                        .HasForeignKey(e => e.Tour_id);
            modelBuilder.Entity<BookingModel>()
                      .HasOne(e => e.User)
                      .WithMany(e => e.Bookings)
                      .HasForeignKey(e => e.User_id);
            modelBuilder.Entity<FeedbackModel>()
                   .HasOne(e => e.Booking)
                   .WithMany(e => e.Feedbacks)
                   .HasForeignKey(e => e.Feedback_id);


            // Book single service
            //modelBuilder.Entity<BookSingleServiceModel>()
            //            .HasOne(e => e.Accommodation)
            //            .WithMany(e => e.BookSingleServices)
            //            .HasForeignKey(e => e.Accommodation_id);
            //modelBuilder.Entity<BookSingleServiceModel>()
            //            .HasOne(e => e.Restaurant)
            //            .WithMany(e => e.BookSingleServices)
            //            .HasForeignKey(e => e.Restaurant_id);
            //modelBuilder.Entity<BookSingleServiceModel>()
            //            .HasOne(e => e.TouristSpot)
            //            .WithMany(e => e.BookSingleServices)
            //            .HasForeignKey(e => e.TouristSpot_id);
            //modelBuilder.Entity<BookSingleServiceModel>()
            //            .HasOne(e => e.Transport)
            //            .WithMany(e => e.BookSingleServices)
            //            .HasForeignKey(e => e.Transport_id);

            // modelBuilder.Entity<BookSingleServiceModel>()
            //          .HasOne(e => e.User)
            //          .WithMany(e => e.BookSingleServices)
            //          .HasForeignKey(e => e.User_id);
            //modelBuilder.Entity<FeedbackSingleServiceModel>()
            //       .HasOne(e => e.BookSingleService)
            //       .WithMany(e => e.FeedbackSingleServices)
            //       .HasForeignKey(e => e.FeedbackService_id);



            modelBuilder.Entity<BookingModel>()
                        .HasOne(e => e.Accommodation)
                        .WithMany(e => e.Bookings)
                        .HasForeignKey(e => e.Accommodation_id);
            modelBuilder.Entity<BookingModel>()
                        .HasOne(e => e.Restaurant)
                        .WithMany(e => e.Bookings)
                        .HasForeignKey(e => e.Restaurant_id);
            modelBuilder.Entity<BookingModel>()
                        .HasOne(e => e.TouristSpot)
                        .WithMany(e => e.Bookings)
                        .HasForeignKey(e => e.TouristSpot_id);
            modelBuilder.Entity<BookingModel>()
                        .HasOne(e => e.Transport)
                        .WithMany(e => e.Bookings)
                        .HasForeignKey(e => e.Transport_id);



        }
        public DbSet<AccommodationModel> Accommodations { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<FeedbackModel> Feedbacks { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<TouristSpotModel> TouristSpots { get; set; }
        public DbSet<TourModel> Tours { get; set; }
        public DbSet<TransportModel> Transports { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AccommodationImageModel> AccommodationImages { get; set; }
        public DbSet<LocationImageModel> LocationImages { get; set; }
        public DbSet<RestaurantImageModel> RestaurantImages { get; set; }
        public DbSet<TouristSpotImageModel> TouristSpotImages { get; set; }
        public DbSet<MultiAccommodationModel> MultiAccommodations { get; set; }
        public DbSet<MultiRestaurantModel> MultiRestaurants { get; set; }
        public DbSet<MultiTouristSpotModel> MultiTouristSpots { get; set; }
        public DbSet<MultiTransportModel> MultiTransports { get; set; }
        //public DbSet<BookSingleServiceModel> BookSingleServices { get; set; }
        //public DbSet<FeedbackSingleServiceModel> FeedbackSingleServices { get; set; }

















    }
}
