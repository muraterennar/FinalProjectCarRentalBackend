using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailIdDto> GetCarDetailByAllId()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join image in context.CarImages on car.ImageId equals image.Id
                             select new CarDetailIdDto
                             {
                                 CarId = car.Id,
                                 BrandId = brand.Id,
                                 ColorId = color.Id,
                                 ImageId = image.Id,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Descriptions = car.Descriptions
                             };
                return result.ToList();
            }
        }

        public List<CarDetailNameDto> GetCarDetailByAllNames()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join image in context.CarImages on car.ImageId equals image.Id
                             select new CarDetailNameDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.BrandName,
                                 BrandModel = brand.BrandModel,
                                 ColorName = color.ColorName,
                                 ImagePath = image.ImagePath,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Descriptions = car.Descriptions,
                             };
                return result.ToList();
            }
        }
        public List<CarDetailIdDto> GetCarDetailsIdById(int carId)
        {
            return GetCarDetailByAllId().Where(c => c.CarId == carId).ToList();
        }


        public List<CarDetailIdDto> GetCarDetailsIdByBrandId(int brandId)
        {
            return GetCarDetailByAllId().Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailIdDto> GetCarDetailsIdByColorId(int colorId)
        {
            return GetCarDetailByAllId().Where(c => c.ColorId == colorId).ToList();
        }

        public List<CarDetailIdDto> GetCarDetailsIdByImageId(int imageId)
        {
            return GetCarDetailByAllId().Where(c => c.ImageId == imageId).ToList();
        }

        public List<CarDetailNameDto> GetCarDetailsNameById(int id)
        {
            return GetCarDetailByAllNames().Where(c => c.CarId == id).ToList();
        }

        public List<CarDetailNameDto> GetCarDetailsNameByBrandName(string brandName)
        {
            return GetCarDetailByAllNames().Where(c => c.BrandName == brandName).ToList();
        }

        public List<CarDetailNameDto> GetCarDetailsNameByColorName(string ColorName)
        {
            return GetCarDetailByAllNames().Where(c => c.ColorName == ColorName).ToList();
        }

        public List<CarDetailNameDto> GetCarDetailsNameByİmagePath(string imagePath)
        {
            return GetCarDetailByAllNames().Where(c => c.ImagePath == imagePath).ToList();
        }
    }
}
