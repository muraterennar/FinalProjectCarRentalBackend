﻿using Core.DataAccess;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBrandDal : IEntityRepository<Brand>
    {
        List<BrandDetailDto> GetBrandDetails();
        List<BrandDetailDto> GetBrandDetailsIdByBrandId(int brandId);
        List<BrandDetailDto> GetBrandDetailsIdByImageId(int imageId);
    }
}
