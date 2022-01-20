using RentACar.WebAPI.Common;
using RentACar.WebAPI.Dto;

namespace RentACar.WebAPI.Interfaces
{
    public interface IRentACarService
    {
        PagedResult<CarDto> GetListOfCars(CarSearchDto search);

        CarDto GetCarById(int id);

        CarDto InsertCar(CarInsertDto insertData);

        CarDto UpdateCar(int id, CarUpdateDto updateData);

        bool DeleteCar(int id);
    }
}
