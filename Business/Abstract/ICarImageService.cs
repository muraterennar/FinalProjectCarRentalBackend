using Core.Utilities.Results;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int imageId);
        IDataResult<CarImage> GetByCarId(int carId);
        IDataResult<CarImage> GetByImagePath(string imagePath);

        IResult Add(int carId, List<IFormFile> file);
        IResult Delete(int imageId);
        IResult Update(int imageId, IFormFile file);

    }
}
