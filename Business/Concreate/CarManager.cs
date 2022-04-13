using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarsListedByBrandId);
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarsListedByColorId);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.CarListed);
        }

        public IDataResult<List<CarDetailIdDto>> GetCarDetailsIdAll()
        {
            return new SuccessDataResult<List<CarDetailIdDto>>(_carDal.GetCarDetailByAllId(), Messages.CarsDetailsListed);
        }

        public IDataResult<List<CarDetailIdDto>> GetCarDetailsIdByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailIdDto>>(_carDal.GetCarDetailsIdByBrandId(brandId), Messages.CarsListedByBrandId);
        }

        public IDataResult<List<CarDetailIdDto>> GetCarDetailsIdByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailIdDto>>(_carDal.GetCarDetailsIdByColorId(colorId), Messages.CarsListedByColorId);
        }

        public IDataResult<List<CarDetailIdDto>> GetCarDetailsIdById(int carId)
        {
            return new SuccessDataResult<List<CarDetailIdDto>>(_carDal.GetCarDetailsIdById(carId), Messages.CarDetailListed);
        }

        public IDataResult<List<CarDetailIdDto>> GetCarDetailsIdByImageId(int imageId)
        {
            return new SuccessDataResult<List<CarDetailIdDto>>(_carDal.GetCarDetailsIdByImageId(imageId), Messages.CarDetailsListedByImage);
        }

        public IDataResult<List<CarDetailNameDto>> GetCarDetailsNameAll()
        {
            return new SuccessDataResult<List<CarDetailNameDto>>(_carDal.GetCarDetailByAllNames(), Messages.CarsDetailsListed);
        }

        public IDataResult<List<CarDetailNameDto>> GetCarDetailsNameByBrandName(string brandName)
        {
            return new SuccessDataResult<List<CarDetailNameDto>>(_carDal.GetCarDetailsNameByBrandName(brandName), Messages.CarsDetailsListedByBrandId);
        }

        public IDataResult<List<CarDetailNameDto>> GetCarDetailsNameByColorName(string colorName)
        {
            return new SuccessDataResult<List<CarDetailNameDto>>(_carDal.GetCarDetailsNameByColorName(colorName), Messages.CarsDetailsListedByColorId);
        }

        public IDataResult<List<CarDetailNameDto>> GetCarDetailsNameById(int id)
        {
            return new SuccessDataResult<List<CarDetailNameDto>>(_carDal.GetCarDetailsNameById(id), Messages.CarDetailListed);
        }

        public IDataResult<List<CarDetailNameDto>> GetCarDetailsNameByİmagePath(string imagePath)
        {
            return new SuccessDataResult<List<CarDetailNameDto>>(_carDal.GetCarDetailsNameByİmagePath(imagePath), Messages.CarDetailsListedByImage);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
