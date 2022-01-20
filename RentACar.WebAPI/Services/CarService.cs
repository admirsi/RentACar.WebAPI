using AutoMapper;
using RentACar.WebAPI.Common;
using RentACar.WebAPI.Dto;
using RentACar.WebAPI.Entities;
using RentACar.WebAPI.Exceptions;
using RentACar.WebAPI.Infrastructure.Database;
using RentACar.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentACar.WebAPI.Services
{
    public class CarService : IRentACarService
    {
        protected readonly RentACarDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger<CarService> _logger;

        public CarService(RentACarDbContext context, IMapper mapper, ILogger<CarService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public bool DeleteCar(int id)
        {
            var dbCar = _context.Cars.FirstOrDefault(x=>x.Id == id);
            if (dbCar == null)
            {
                throw new NoCarException("No car in database.");
            }

            _context.Cars.Remove(dbCar);

            return _context.SaveChanges() > 0;
        }

        public CarDto GetCarById(int id)
        {
            var dbCar = _context.Cars.FirstOrDefault(x => x.Id == id);

            if (dbCar == null)
            {
                throw new NoCarException("No car in database.");
            }

            return _mapper.Map<CarDto>(dbCar);
        }

        public PagedResult<CarDto> GetListOfCars(CarSearchDto search)
        {
            var query = _context.Cars.AsQueryable();
            
            if (!string.IsNullOrEmpty(search.Title))
            {
                query = query.Where(x=>x.Brand.ToLower() == search.Title.ToLower());
            }

            PagedResult<CarDto> result = new();
            result.TotalCount = query.LongCount();

            query = query.Skip(search.Page * search.PageSize)
                .Take(search.PageSize);

            List<Car> res = query.ToList();
            result.Data = _mapper.Map<List<CarDto>>(res);
            return result;
        }

        public CarDto InsertCar(CarInsertDto insertData)
        {
            var dbCar = _mapper.Map<Car>(insertData);
            _context.Cars.Add(dbCar);
            _context.SaveChanges();
            return _mapper.Map<CarDto>(dbCar);
        }

        public CarDto UpdateCar(int id, CarUpdateDto updateData)
        {
            _logger.LogInformation($"Updating the Car with id {id}");

            var dbCar = _context.Cars.FirstOrDefault(x => x.Id == id);

            if (dbCar == null)
            {
                throw new NoCarException("No car in database.");
            }

            _mapper.Map(updateData, dbCar);
            _context.SaveChanges();

            return _mapper.Map<CarDto>(dbCar);
        }
    }
}
