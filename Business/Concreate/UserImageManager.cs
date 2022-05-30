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
    public class UserImageManager : IUserImageService
    {
        IUserImageDal _userImageDal;
        IFileHelper _fileHelper;

        public UserImageManager(IFileHelper fileHelper, IUserImageDal userImageDal)
        {
            _fileHelper = fileHelper;
            _userImageDal = userImageDal;
        }

        //[SecuredOperation("admin, user")]
        [ValidationAspect(typeof(UserImageValidator))]
        [CacheRemoveAspect("IUserImageService.Get")]
        public IResult Add(int userId, List<IFormFile> file)
        {
            var result = BusinessRules.Run
                (
                    CheckIfCarImagesLimit(file)
                );

            if (result != null)
            {
                return result;
            }

            string folder = PathContants.ImagesPath;

            foreach (IFormFile f in file)
            {
                string imagePath = _fileHelper.Upload(f, folder);
                _userImageDal.Add(new UserImage { ImagePath = imagePath, UserId = userId, ImageDate = DateTime.Now });
            }

            return new SuccessResult(Messages.UserImageAdded);
        }

        //[SecuredOperation("admin, user")]
        [ValidationAspect(typeof(UserImageValidator))]
        [CacheRemoveAspect("IUserImageService.Get")]
        public IResult Delete(int imageId)
        {
            var result = _userImageDal.Get(c => c.Id == imageId);
            _fileHelper.Delete(result.ImagePath);
            _userImageDal.Delete(result);

            return new SuccessResult(Messages.UserImageDeleted);
        }
        [CacheAspect]
        public IDataResult<List<UserImage>> GetAll()
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(), Messages.ImagesListed);
        }
        [CacheAspect]
        public IDataResult<List<UserImage>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(u => u.UserId == userId), Messages.ImagesListedbyUserId);
        }
        [CacheAspect]
        public IDataResult<List<UserImage>> GetByUserImage(string imagePath)
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(u => u.ImagePath == imagePath), Messages.ImagesListedbyImagePath);
        }

        //[SecuredOperation("admin, user")]
        [ValidationAspect(typeof(UserImageValidator))]
        [CacheRemoveAspect("IUserImageService.Get")]
        public IResult Update(int imageId, IFormFile file)
        {
            var result = _userImageDal.Get(c => c.Id == imageId);
            var oldFile = result.ImagePath;

            result.ImagePath = _fileHelper.Update(file, PathContants.ImagesPath, oldFile);

            _userImageDal.Update(result);

            return new SuccessResult(Messages.UserImageUpdated);
        }


        //********************* RULES *********************\\

        private IResult CheckIfCarImagesLimit(List<IFormFile> files)
        {
            if (files.Count > 2)
            {
                return new ErrorResult(Messages.UserImagesLimitError);
            }

            return new SuccessResult();
        }
    }
}
