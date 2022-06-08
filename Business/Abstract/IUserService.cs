using Core.Entities.Concreate;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<UserDetailsDto>> GetUserDetils();
        IDataResult<List<UserDetailsDto>> GetUserDetilsByUserId(int userId);
        IDataResult<List<UserDetailsDto>> GetUserDetilsByEmail(string email);
        IDataResult<User> GetById(int userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IResult Add(User user);
        IDataResult<User> EditProfile(UserProfileEditDto profile, string password);
        IResult Delete(User user);
    }
}
