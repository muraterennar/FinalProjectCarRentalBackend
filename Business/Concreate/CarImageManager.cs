﻿using Business.Abstract;
using Business.Constants;
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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(int carId, List<IFormFile> file)
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
                _carImageDal.Add(new CarImage { ImagePath = imagePath, CarId = carId, ImageDate = DateTime.Now });
            }

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(int imageId)
        {
            var result = _carImageDal.Get(c => c.Id == imageId);
            _fileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(result);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageGetAll);
        }

        public IDataResult<CarImage> GetByCarId(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carId), Messages.CarImageGet);
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId), Messages.CarImageGetImageId);
        }

        public IDataResult<CarImage> GetByImagePath(string imagePath)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImagePath == imagePath), Messages.CarImageGetImagePath);
        }

        public IResult Update(int imageId, IFormFile file)
        {
            var result = _carImageDal.Get(c => c.Id == imageId);
            var oldFile = result.ImagePath;

            result.ImagePath = _fileHelper.Update(file, PathContants.ImagesPath, oldFile);

            _carImageDal.Update(result);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        //********************* RULES *********************\\

        private IResult CheckIfCarImagesLimit(List<IFormFile> files)
        {
            if (files.Count > 5)
            {
                return new ErrorResult(Messages.CarImagesLimitError);
            }

            return new SuccessResult();
        }
    }
}
