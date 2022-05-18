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


        public List<CarDetailDto> GetCarDetail()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join carImage in context.CarImages on car.Id equals carImage.CarId
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandId = brand.Id,
                                 ColorId = color.Id,
                                 ImageId = carImage.Id,
                                 BrandName = brand.BrandName,
                                 BrandModel = brand.BrandModel,
                                 ColorName = color.ColorName,
                                 ImagePath = carImage.ImagePath,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Descriptions = car.Descriptions
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
        {
            var reult = GetCarDetail().Where(c => c.BrandId == brandId).ToList();
            return reult;
        }

        public List<CarDetailDto> GetCarDetailByCarId(int carId)
        {
            var reult = GetCarDetail().Where(c => c.CarId == carId).ToList();
            return reult;
        }

        public List<CarDetailDto> GetCarDetailByColorId(int colorId)
        {
            var reult = GetCarDetail().Where(c => c.ColorId == colorId).ToList();
            return reult;
        }

        public List<CarDetailDto> GetCarDetailByImageId(int imageId)
        {
            var reult = GetCarDetail().Where(c => c.ImageId == imageId).ToList();
            return reult;
        }

        public List<CarDetailDto> GetCarDetailNameByBrandName(string brandName)
        {
            var reult = GetCarDetail().Where(c => c.BrandName == brandName).ToList();
            return reult;
        }

        public List<CarDetailDto> GetCarDetailNameByColorName(string colorName)
        {
            var reult = GetCarDetail().Where(c => c.ColorName == colorName).ToList();
            return reult;
        }

        public List<CarDetailDto> GetCarDetailNameByİmagePath(string imagePath)
        {
            var reult = GetCarDetail().Where(c => c.ImagePath == imagePath).ToList();
            return reult;
        }
    }
}
