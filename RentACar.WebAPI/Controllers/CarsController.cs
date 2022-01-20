
using RentACar.WebAPI.Common;
using RentACar.WebAPI.Dto;
using RentACar.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IRentACarService _carService;
        private readonly ILogger<CarsController> _logger;

        public CarsController(IRentACarService carService, ILogger<CarsController> logger)
        {
            _carService = carService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public CarDto GetCarById(int id)
        {
            return _carService.GetCarById(id);
        }

        [HttpGet("")]
        public PagedResult<CarDto> GetCars([FromQuery] CarSearchDto search)
        {
            _logger.LogInformation("This is the log!");
            return _carService.GetListOfCars(search);
        }

        [HttpPost]
        public CarDto CreateCar(CarInsertDto insertCarRequest)
        {
            return _carService.InsertCar(insertCarRequest);
        }

        [HttpPut("{id}")]
        public CarDto UpdateCar(int id, CarUpdateDto updateRequest)
        {
            return _carService.UpdateCar(id, updateRequest);
        }

        [HttpDelete]
        public bool DeleteCar(int id)
        {
            return _carService.DeleteCar(id);
        }
    }
}
