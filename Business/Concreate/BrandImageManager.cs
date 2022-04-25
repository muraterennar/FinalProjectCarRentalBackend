﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidaiton;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class BrandImageManager : IBrandImageService
    {
        IBrandImageDal _brandImageDal;
        IFileHelper _fileHelper;

        public BrandImageManager(IFileHelper fileHelper, IBrandImageDal brandImageDal)
        {
            _fileHelper = fileHelper;
            _brandImageDal = brandImageDal;
        }

        [SecuredOperation("admin, user")]
        [ValidationAspect(typeof(BrandImageValidator))]
        [CacheRemoveAspect("IBrandImageService.Get")]
        public IResult Add(int brandId, List<IFormFile> file)
        {
            var result = BusinessRules.Run
                (
                    CheckIfBrandImagesLimit(file)
                );

            if (result != null)
            {
                return result;
            }

            string folder = PathContants.ImagesPath;

            foreach (IFormFile f in file)
            {
                string imagePath = _fileHelper.Upload(f, folder);
                _brandImageDal.Add(new BrandImage { ImagePath = imagePath, BrandId = brandId, ImageDate = DateTime.Now });
            }

            return new SuccessResult(Messages.BrandImageAdded);
        }

        [SecuredOperation("admin, user")]
        [ValidationAspect(typeof(BrandImageValidator))]
        [CacheRemoveAspect("IBrandImageService.Get")]
        public IResult Delete(int imageId)
        {
            var result = _brandImageDal.Get(c => c.Id == imageId);
            _fileHelper.Delete(result.ImagePath);
            _brandImageDal.Delete(result);

            return new SuccessResult(Messages.UserImageDeleted);
        }

        [CacheAspect]
        public IDataResult<List<BrandImage>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<List<BrandImage>> GetAll()
        {
            return new SuccessDataResult<List<BrandImage>>(_brandImageDal.GetAll(), Messages.ImagesListed);
        }

        [CacheAspect]
        public IDataResult<List<BrandImage>> GetBrandId(int brandId)
        {
            return new SuccessDataResult<List<BrandImage>>(_brandImageDal.GetAll(b => b.BrandId == brandId), Messages.ImagesListedByBrandId);
        }

        [CacheAspect]
        public IDataResult<List<BrandImage>> GetImagePath(string imagePath)
        {
            return new SuccessDataResult<List<BrandImage>>(_brandImageDal.GetAll(b => b.ImagePath == imagePath), Messages.ImagesListedbyImagePath);
        }

        [SecuredOperation("admin, user")]
        [ValidationAspect(typeof(BrandImageValidator))]
        [CacheRemoveAspect("IBrandImageService.Get")]
        public IResult Update(int imageId, IFormFile file)
        {
            var result = _brandImageDal.Get(c => c.Id == imageId);
            var oldFile = result.ImagePath;

            result.ImagePath = _fileHelper.Update(file, PathContants.ImagesPath, oldFile);

            _brandImageDal.Update(result);

            return new SuccessResult(Messages.UserImageUpdated);
        }

        //********************* RULES *********************\\

        private IResult CheckIfBrandImagesLimit(List<IFormFile> files)
        {
            if (files.Count == 1)
            {
                return new ErrorResult(Messages.UserImagesLimitError);
            }

            return new SuccessResult();
        }
    }
}
