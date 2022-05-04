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
    public class EfCreditCardPaymnet : EfEntityRepositoryBase<CreditCard, CarRentalContext>, ICreditCardPaymentDal
    {
     
    }
}
