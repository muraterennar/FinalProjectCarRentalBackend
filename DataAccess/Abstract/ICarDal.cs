using Core.DataAccess;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailNameDto> GetCarDetailByAllNames();
        List<CarDetailIdDto> GetCarDetailByAllId();

        //List<CarDetailIdDto> GetCarDetailById(int carId);

        List<CarDetailIdDto> GetCarDetailsIdById(int carId);
        List<CarDetailIdDto> GetCarDetailsIdByBrandId(int brandId);
        List<CarDetailIdDto> GetCarDetailsIdByColorId(int colorId);
        List<CarDetailIdDto> GetCarDetailsIdByImageId(int imageId);

        List<CarDetailNameDto> GetCarDetailsNameById(int id);
        List<CarDetailNameDto> GetCarDetailsNameByBrandName(string brandName);
        List<CarDetailNameDto> GetCarDetailsNameByColorName(string ColorName);
        List<CarDetailNameDto> GetCarDetailsNameByİmagePath(string imagePath);
    }
}
