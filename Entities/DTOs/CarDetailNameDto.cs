﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailNameDto:IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string BrandModel { get; set; }
        public string ColorName { get; set; }
        public string ImagePath { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Descriptions { get; set; }
    }
}
