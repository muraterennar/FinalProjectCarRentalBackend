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

        public List<User> GetUser(User user)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from person in context.Users
                             join city in context.Cities on person.CityName equals city.CityName
                             select new User
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 Address = user.Address,
                                 Birthdate = user.Birthdate,
                                 Gender = user.Gender,
                                 PhoneNumber = user.PhoneNumber,
                                 CityName = city.CityName,
                                 Status = user.Status,
                                 PasswordHash = user.PasswordHash,
                                 PasswordSalt = user.PasswordSalt,
                             };

                return result.ToList();

            }
        }
    }
}
