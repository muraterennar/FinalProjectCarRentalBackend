using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidaiton;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concreate;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CreditCardPaymentManager : ICreditCardPaymetService
    {
        ICreditCardPaymentDal _creditCardPayment;

        public CreditCardPaymentManager(ICreditCardPaymentDal creditCardPayment)
        {
            _creditCardPayment = creditCardPayment;
        }

        [SecuredOperation("admin, user")]
        [ValidationAspect(typeof(CreditCardPaymentValidator))]
        [CacheRemoveAspect("ICreditCardPaymentService.Get")]
        public IResult AddPaymnet(CreditCard creditCard)
        {
            var results = _creditCardPayment.GetAll(c => c.CustomerId == creditCard.CustomerId);
            foreach (var result in results)
            {
                _creditCardPayment.Update(result);
            }

            _creditCardPayment.Add(creditCard);
            return new SuccessResult(Messages.AddedCreditCardAndToPay);
        }

        [SecuredOperation("admin, user")]
        [ValidationAspect(typeof(CreditCardPaymentValidator))]
        [CacheRemoveAspect("ICreditCardPaymentService.Get")]
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardPayment.Delete(creditCard);
            return new SuccessResult(Messages.AddedCreditCardAndToPay);
        }

        [CacheAspect]
        public IDataResult<CreditCard> Get(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardPayment.Get(c => c.Id == id), Messages.CreditCardListed);
        }

        [CacheAspect]
        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardPayment.GetAll(), Messages.ListedAllCreditCard);
        }

        [CacheAspect]
        public IDataResult<CreditCard> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardPayment.Get(c => c.CustomerId == customerId), Messages.ListedCreditCardbyUserId);
        }

        //[SecuredOperation("admin, user")]
        [ValidationAspect(typeof(CreditCardPaymentValidator))]
        [CacheRemoveAspect("ICreditCardPaymentService.Get")]
        public IResult NotAddPaymnet(CreditCardPaymentDto creditCardPaymentDto)
        {
            return new SuccessResult(Messages.AddedCreditCardAndToPay);
        }

        [SecuredOperation("admin, user")]
        [ValidationAspect(typeof(CreditCardPaymentValidator))]
        [CacheRemoveAspect("ICreditCardPaymentService.Get")]
        public IResult Update(CreditCard creditCard)
        {
            _creditCardPayment.Update(creditCard);
            return new SuccessResult(Messages.AddedCreditCardAndToPay);
        }
    }
}
