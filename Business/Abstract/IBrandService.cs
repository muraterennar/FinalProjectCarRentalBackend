using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int id);

        IDataResult<List<BrandDetailDto>> GetBrandDetailsAll();
        IDataResult<List<BrandDetailDto>> GetBrandDetailsIdByImageId(int imageId);
        IDataResult<List<BrandDetailDto>> GetBrandDetailsIdByBrandId(int brandId);

        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
    }
}
