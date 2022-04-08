﻿using Core.DataAccess.EntityFramework;
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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RetnalDetailDto> GetRentalDetailById(int rentalId)
        {
            return GetRentalDetails().Where(x => x.RentalId == rentalId).ToList();
        }

        public List<RetnalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on rental.BrandId equals brand.Id
                             join user in context.Users on rental.UserId equals user.Id

                             select new RetnalDetailDto
                             {
                                 RentalId = rental.Id,
                                 CarId = car.Id,
                                 BrandName = brand.BrandName,
                                 BrandModel = brand.BrandModel,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 PhoneNumber = user.PhoneNumber,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
