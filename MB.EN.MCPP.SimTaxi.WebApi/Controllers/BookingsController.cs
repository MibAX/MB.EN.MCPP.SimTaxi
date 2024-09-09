using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.EN.MCPP.SimTaxi.Entities.Bookings;
using MB.EN.MCPP.SimTaxi.EntityFrameworkCore.Data;
using AutoMapper;
using MB.EN.MCPP.SimTaxi.Dtos.Bookings;
using System.Linq;

namespace MB.EN.MCPP.SimTaxi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        #region Data and Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookingsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetBookings()
        {
            var bookings = await _context
                                    .Bookings
                                    .Include(booking => booking.Driver)
                                    .Include(booking => booking.Car)
                                    .ToListAsync();

            var bookingDtos = _mapper.Map<List<BookingDto>>(bookings);

            return bookingDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetailsDto>> GetBooking(int id)
        {
            var booking = await _context
                                    .Bookings
                                    .Include(booking => booking.Driver)
                                    .Include(booking => booking.Car)
                                    .Include(booking => booking.Passengers)
                                    .SingleOrDefaultAsync();


            if (booking == null)
            {
                return NotFound();
            }

            var bookingDetailsDto = _mapper.Map<BookingDetailsDto>(booking);

            return bookingDetailsDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBooking(int id, CreateUpdateBookingDto createUpdateBookingDto)
        {
            if (id != createUpdateBookingDto.Id)
            {
                return BadRequest();
            }

            var booking = await _context
                                    .Bookings
                                    .Include(booking => booking.Passengers)
                                    .Where(booking => booking.Id == id)
                                    .SingleOrDefaultAsync();

            if(booking == null)
            {
                return NotFound();
            }

            _mapper.Map(createUpdateBookingDto, booking);

            await UpdateBookingPassengers(booking, createUpdateBookingDto.PassengerIds);

            booking.TotalPrice = GetBookingPrice();

            _context.Update(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(CreateUpdateBookingDto createUpdateBookingDto)
        {
            var booking = _mapper.Map<Booking>(createUpdateBookingDto);

            // UpdateBookingPassengers
            await UpdateBookingPassengers(booking, createUpdateBookingDto.PassengerIds);

            // Set Total Price
            booking.TotalPrice = GetBookingPrice();

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Private Methods

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }

        private async Task UpdateBookingPassengers(Booking booking, List<int> passengerIds)
        {
            // Clear booking.Passengers
            booking.Passengers.Clear();

            // Get passengers from DB using the passengerIds
            var passengers = await _context
                                        .Passengers
                                        .Where(passengers => passengerIds.Contains(passengers.Id))
                                        .ToListAsync();

            // Add the passengers to booking.Passenger
            booking.Passengers.AddRange(passengers);
        }

        private decimal GetBookingPrice()
        {
            Random random = new Random();

            // Generate the integer part between 10 and 1000
            var integerPart = random.Next(10, 1001);

            // Generate the fractional part (e.g., 0.00 to 0.99)
            var fractionalPart = (decimal)random.NextDouble();

            // Combine the integer and fractional parts
            var randomDecimal = integerPart + fractionalPart;

            return randomDecimal;
        }

        #endregion
    }
}
