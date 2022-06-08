using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidaiton;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concreate;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            if (!user.CityId.Equals(null) || !user.GenderId.Equals(null) || !user.Birthdate.Equals(null))
            {
                user.Birthdate = DateTime.Now;
                user.CityId = 1;
                user.GenderId = 1;
                user.Status = true;
            }

            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<User> EditProfile(UserProfileEditDto profile, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var newUser = new User
            {
                Id = profile.Id,
                Email = profile.Email,
                Comment = profile.Comment,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Address = profile.Address,
                Birthdate = profile.BirthDate,
                PhoneNumber = profile.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CityId = profile.CityId,
                GenderId = profile.GenderId
            };

            if (newUser.CityId.Equals(null) || newUser.GenderId.Equals(null) || newUser.Status.Equals(null))
            {
                newUser.CityId = 1;
                newUser.GenderId = 1;
                newUser.Status = true;
            }

            _userDal.Update(newUser);
            return new SuccessDataResult<User>(Messages.UserUpdated);
        }

        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }
        [CacheAspect]
        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId), Messages.UserListed);
        }
        [CacheAspect]
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        [CacheAspect]
        public IDataResult<List<UserDetailsDto>> GetUserDetils()
        {
            return new SuccessDataResult<List<UserDetailsDto>>(_userDal.GetUserDetails(), Messages.UsersListed);
        }

        [CacheAspect]
        public IDataResult<List<UserDetailsDto>> GetUserDetilsByEmail(string email)
        {
            return new SuccessDataResult<List<UserDetailsDto>>(_userDal.GetUserDetailsByEmail(email));
        }

        [CacheAspect]
        public IDataResult<List<UserDetailsDto>> GetUserDetilsByUserId(int userId)
        {
            return new SuccessDataResult<List<UserDetailsDto>>(_userDal.GetUserDetailsByUserId(userId), Messages.UserListed);
        }


    }
}
