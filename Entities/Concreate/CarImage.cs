﻿using Core.Entities;
using System;

namespace Entities.Concreate
{
    public class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime ImageDate { get; set; }
    }
}
