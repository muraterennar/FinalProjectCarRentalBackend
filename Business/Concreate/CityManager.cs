using Business.Abstract;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CityManager : ICityService
    {
        ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        [CacheAspect]
        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(), Messages.CitiesListed);
        }
        [CacheAspect]
        public IDataResult<City> GetById(int id)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.Id == id));
        }
        [CacheAspect]
        public IDataResult<City> GetByName(string name)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.CityName == name));
        }
    }
}
