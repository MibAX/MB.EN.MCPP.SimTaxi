using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.EN.MCPP.SimTaxi.Entities.Drivers;
using MB.EN.MCPP.SimTaxi.EntityFrameworkCore.Data;
using AutoMapper;
using MB.EN.MCPP.SimTaxi.Dtos.Drivers;

namespace MB.EN.MCPP.SimTaxi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        #region Data and Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DriversController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverDto>>> GetDrivers()
        {
            var drivers = await _context
                                    .Drivers
                                    .ToListAsync();

            var driverDtos = _mapper.Map<List<DriverDto>>(drivers);

            return driverDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DriverDetailsDto>> GetDriver(int id)
        {
            var driver = await _context
                                    .Drivers
                                    .Include(driver => driver.Cars)
                                    .Where(driver => driver.Id == id)
                                    .SingleOrDefaultAsync();

            if (driver == null)
            {
                return NotFound();
            }

            var driverDetailsDto = _mapper.Map<DriverDetailsDto>(driver);

            return driverDetailsDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditDriver(int id, CreateUpdateDriverDto createUpdateDriverDto)
        {
            if (id != createUpdateDriverDto.Id)
            {
                return BadRequest();
            }

            // Get the driver from the DB and check for nullability
            var driver = await _context
                                    .Drivers
                                    .Where(driver => driver.Id == id)
                                    .SingleOrDefaultAsync();

            if(driver == null)
            {
                return NotFound();
            }

            // Patch (Copy) createUpdateDriverDto into driver
            _mapper.Map(createUpdateDriverDto, driver);

            // SaveChanges to the DB
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Driver>> CreateDriver(CreateUpdateDriverDto createUpdateDriverDto)
        {
            var driver = _mapper.Map<Driver>(createUpdateDriverDto);

            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Private Methods

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        } 

        #endregion
    }
}
