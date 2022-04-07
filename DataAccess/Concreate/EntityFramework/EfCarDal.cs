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
        public List<CarDetailIdDto> GetCarDetailById()
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

        public List<CarDetailNameDto> GetCarDetailByNames()
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
                                Descriptions = car.Descriptions 
                             };
                return result.ToList();
            }
        }
    }
}
