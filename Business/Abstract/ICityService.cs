using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        IDataResult<List<City>> GetAll();
        IDataResult<City> GetById(int id);
        IDataResult<City> GetByName(string name);
    }
}
