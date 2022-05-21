using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidaiton;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        //[SecuredOperation("admin, user")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandAdded);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);

            return new SuccessResult(Messages.BrandDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        [CacheAspect]
        public IDataResult<List<BrandDetailDto>> GetBrandDetailsAll()
        {
            return new SuccessDataResult<List<BrandDetailDto>>(_brandDal.GetBrandDetails(), Messages.BrandsListed);
        }

        [CacheAspect]
        public IDataResult<List<BrandDetailDto>> GetBrandDetailsIdByBrandId(int brandId)
        {
            return new SuccessDataResult<List<BrandDetailDto>>(_brandDal.GetBrandDetailsIdByBrandId(brandId), Messages.BrandsListed);
        }

        [CacheAspect]
        public IDataResult<List<BrandDetailDto>> GetBrandDetailsIdByImageId(int imageId)
        {
            return new SuccessDataResult<List<BrandDetailDto>>(_brandDal.GetBrandDetailsIdByImageId(imageId), Messages.BrandsListed);
        }

        [CacheAspect]
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id), Messages.BrandsListed);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);

            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
