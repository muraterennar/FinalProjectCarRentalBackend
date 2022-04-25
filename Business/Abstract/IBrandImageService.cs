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
    public interface IBrandImageService
    {
        IDataResult<List<BrandImage>> GetAll();
        IDataResult<List<BrandImage>> Get(int id);
        IDataResult<List<BrandImage>> GetBrandId(int brandId);
        IDataResult<List<BrandImage>> GetImagePath(string imagePath);

        IResult Add(int brandId, List<IFormFile> file);
        IResult Delete(int imageId);
        IResult Update(int imageId, IFormFile file);
    }
}
