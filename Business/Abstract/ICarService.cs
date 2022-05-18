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

        IDataResult<List<CarDetailDto>> GetCarDetail();
        IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailByImageId(int imageId);
        IDataResult<List<CarDetailDto>> GetCarDetailNameByBrandName(string brandName);
        IDataResult<List<CarDetailDto>> GetCarDetailNameByColorName(string colorName);
        IDataResult<List<CarDetailDto>> GetCarDetailNameByİmagePath(string imagePath);

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
