using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.EN.MCPP.SimTaxi.Entities.Cars;
using MB.EN.MCPP.SimTaxi.EntityFrameworkCore.Data;
using AutoMapper;
using MB.EN.MCPP.SimTaxi.Dtos.Cars;

namespace MB.EN.MCPP.SimTaxi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        #region Data and Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CarsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            var cars = await _context
                                .Cars
                                .Include(car => car.Driver)
                                .ToListAsync();

            var carVMs = _mapper.Map<List<CarDto>>(cars);

            return Ok(carVMs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDetailsDto>> GetCar(int id)
        {
            var car = await _context
                                .Cars
                                .Include(car => car.Driver)
                                .Where(car => car.Id == id)
                                .SingleOrDefaultAsync();

            if (car == null)
            {
                return NotFound();
            }

            var carDetailsVM = _mapper.Map<CarDetailsDto>(car);

            return carDetailsVM;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCar(int id, CreateUpdateCarDto createUpdateCarDto)
        {
            if (id != createUpdateCarDto.Id)
            {
                return BadRequest();
            }

            // Get the car from DB
            var car = await _context
                                .Cars
                                .Where(car => car.Id == id)
                                .SingleOrDefaultAsync();

            if(car == null)
            {
                return NotFound();
            }

            // Patch (Copy) CreateUpdateCarDto to Car Entity
            _mapper.Map(createUpdateCarDto, car);

            // Update Context
            _context.Update(car);

            // Save
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(CreateUpdateCarDto createUpdateCarDto)
        {
            var car = _mapper.Map<Car>(createUpdateCarDto);

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return NoContent();

            //return CreatedAtAction("CreateCar", new { id = car.Id }, car);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Private Methods

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        } 

        #endregion
    }
}
