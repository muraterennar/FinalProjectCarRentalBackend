using Core.Entities.Concreate;
using Core.Utilities.Results;
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
        IDataResult<User> GetById(int userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<User>> GetUser(User user);
        IDataResult<User> GetByMail(string email);
        IResult Add(User user);
    }
}
