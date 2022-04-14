using Core.Utilities.Results;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserImageService
    {
        IDataResult<List<UserImage>> GetAll();
        IDataResult<List<UserImage>> GetByUserId(int userId);
        IDataResult<List<UserImage>> GetByUserImage(string imagePath);
        IResult Add(int userId, List<IFormFile> file);
        IResult Delete(int imageId);
        IResult Update(int imageId, IFormFile file);
    }
}
