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
        IDataResult<Category> Get(int id);
        IDataResult<Category> Get(string categoryName);

        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
