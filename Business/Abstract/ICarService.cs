using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);

        IDataResult<List<CarDetailIdDto>> GetCarDetailsIdAll();
        IDataResult<List<CarDetailIdDto>> GetCarDetailsIdById(int carId);
        IDataResult<List<CarDetailIdDto>> GetCarDetailsIdByBrandId(int brandId);
        IDataResult<List<CarDetailIdDto>> GetCarDetailsIdByColorId(int colorId);
        IDataResult<List<CarDetailIdDto>> GetCarDetailsIdByImageId(int imageId);

        IDataResult<List<CarDetailNameDto>> GetCarDetailsNameAll();
        IDataResult<List<CarDetailNameDto>> GetCarDetailsNameById(int id);
        IDataResult<List<CarDetailNameDto>> GetCarDetailsNameByBrandName(string brandName);
        IDataResult<List<CarDetailNameDto>> GetCarDetailsNameByColorName(string colorName);
        IDataResult<List<CarDetailNameDto>> GetCarDetailsNameByİmagePath(string imagePath);

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
