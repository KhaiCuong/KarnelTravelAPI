﻿using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingModel>> GetBookings();
        Task<IEnumerable<BookingModel>> GetBookingById(int Booking_id);
        Task<BookingModel> GetBookingByBookingId(int Booking_id);

        Task<BookingModel> AddBooking(BookingModel Booking);
        Task<BookingModel> UpdateBooking(BookingModel Booking);
        Task<bool> DeleteBooking(int Booking_id);
    }
}
