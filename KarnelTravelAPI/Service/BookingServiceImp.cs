using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service
{
    public class BookingServiceImp : IBookingRepository
    {

        private readonly DatabaseContext _databaseContext;

        public BookingServiceImp(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<BookingModel> AddBooking(BookingModel Booking)
        {
            var book = await _databaseContext.Bookings.FirstOrDefaultAsync(p => p.booking_id.Equals(Booking.booking_id));
            if (book == null)
            {
                await _databaseContext.Bookings.AddAsync(Booking);
                await _databaseContext.SaveChangesAsync();
                return Booking;

            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteBooking(int Booking_id)
        {
            BookingModel book = await _databaseContext.Bookings.FindAsync(Booking_id);


            if (book != null)
            {
                _databaseContext.Bookings.Remove(book);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<BookingModel> GetBookingById(int Booking_id)
        {
            BookingModel book = await _databaseContext.Bookings.FindAsync(Booking_id);

            if (book != null)
            {

                return book;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<BookingModel>> GetBookings()
        {
            return await _databaseContext.Bookings.ToListAsync();
        }

        public async Task<BookingModel> UpdateBooking(BookingModel Booking)
        {
            BookingModel book = await _databaseContext.Bookings.FirstOrDefaultAsync(p => p.booking_id.Equals(Booking.booking_id));
            if (book != null)
            {
                _databaseContext.Entry(Booking).State = EntityState.Modified;
                await _databaseContext.SaveChangesAsync();
                return Booking;
            }
            else
            {
                return null;
            }
        }
    }
}
