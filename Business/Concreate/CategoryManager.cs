using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Category>> GetByName(string categoryName)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c => c.CategoryName == categoryName));
        }
    }
}
