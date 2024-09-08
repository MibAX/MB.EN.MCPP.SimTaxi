using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.EN.MCPP.SimTaxi.Entities.Passengers;
using MB.EN.MCPP.SimTaxi.EntityFrameworkCore.Data;
using AutoMapper;
using MB.EN.MCPP.SimTaxi.Dtos.Passengers;

namespace MB.EN.MCPP.SimTaxi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        #region Data and Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PassengersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassengerDto>>> GetPassengers()
        {
            var passengers = await _context
                                    .Passengers
                                    .ToListAsync();

            var passengerDtos = _mapper.Map<List<PassengerDto>>(passengers);

            return passengerDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PassengerDetailsDto>> GetPassenger(int id)
        {
            var passenger = await _context
                                    .Passengers
                                    .Include(passenger => passenger.Bookings)
                                    .Where(passenger => passenger.Id == id)
                                    .SingleOrDefaultAsync();

            if (passenger == null)
            {
                return NotFound();
            }

            var passengerDetailsDto = _mapper.Map<PassengerDetailsDto>(passenger);

            return passengerDetailsDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPassenger(int id, CreateUpdatePassengerDto createUpdatePassengerDto)
        {
            if (id != createUpdatePassengerDto.Id)
            {
                return BadRequest();
            }

            var passenger = await _context
                                    .Passengers
                                    .Where(passenger => passenger.Id == id)
                                    .SingleOrDefaultAsync();

            if(passenger == null)
            {
                return NotFound();
            }

            _mapper.Map(createUpdatePassengerDto, passenger);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Passenger>> CreatePassenger(CreateUpdatePassengerDto createUpdatePassengerDto)
        {
            var passenger = _mapper.Map<Passenger>(createUpdatePassengerDto);

            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }

            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Private Methods

        private bool PassengerExists(int id)
        {
            return _context.Passengers.Any(e => e.Id == id);
        } 

        #endregion
    }
}
