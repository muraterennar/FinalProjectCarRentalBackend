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
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarRentalContext>, IBrandDal
    {
        public List<BrandDetailDto> GetBrandDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from brand in context.Brands
                             join brandImage in context.BrandImages on brand.Id equals brandImage.BrandId
                             select new BrandDetailDto
                             {
                                 BrandId = brand.Id,
                                 BrandModel = brand.BrandModel,
                                 BrandName = brand.BrandName,
                                 ImageId = brandImage.Id,
                                 ImagePath = brandImage.ImagePath,
                                 ImageDate = brandImage.ImageDate,
                             };

                return result.ToList();
            }
        }

        public List<BrandDetailDto> GetBrandDetailsIdByBrandId(int brandId)
        {
            var result = GetBrandDetails().Where(b => b.BrandId == brandId);
            return result.ToList();
        }

        public List<BrandDetailDto> GetBrandDetailsIdByImageId(int imageId)
        {
            var result = GetBrandDetails().Where(b => b.ImageId == imageId);
            return result.ToList();
        }
    }
}
