using Core.DataAccess.EntityFramework;
using Core.Entities.Concreate;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, OperationName = operationClaim.OperationName };
                return result.ToList();
            }
        }

        public List<User> GetUserDetails(User user)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from us in context.Users
                             join gender in context.Genders on us.GenderId equals gender.Id
                             join city in context.Cities on us.CityId equals city.Id
                             where us.Id == user.Id
                             select new User
                             {
                                 Id = us.Id,
                                 CityId = city.Id,
                                 GenderId = gender.Id,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Email = us.Email,
                                 Address = us.Address,
                                 Birthdate = us.Birthdate,
                                 PasswordHash = us.PasswordHash,
                                 PasswordSalt = us.PasswordSalt,
                                 PhoneNumber = us.PhoneNumber,
                                 Status = us.Status
                             };
                return result.ToList();

            }
        }
    }
}
