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
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailNameDto> GetCarDetailByAllNames();
        List<CarDetailIdDto> GetCarDetailByAllId();

        List<CarDetailNameDto> GetCarDetailByName(string brandName);
        List<CarDetailIdDto> GetCarDetailById(int carId);
    }
}
