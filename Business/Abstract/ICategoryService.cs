using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int id);
        IDataResult<List<Category>> GetByName(string categoryName);

        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
    }
}
