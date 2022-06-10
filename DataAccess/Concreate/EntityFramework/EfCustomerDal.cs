using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public CustomerDetailDto GetCustomerDetailByEmail(Expression<Func<CustomerDetailDto, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 UserId = user.Id,
                                 CompanyName = customer.CompanyName,
                                 Id = customer.Id,
                                 Email = user.Email,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 PhoneNumber = user.PhoneNumber,
                                 Status = user.Status,
                             };
                return result.SingleOrDefault(filter);

            }
        }

        public CustomerDetailDto GetCustomerDetailById(Expression<Func<Customer, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from customer in filter is null ? context.Customers : context.Customers.Where(filter)
                             join user in context.Users on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CompanyName = customer.CompanyName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 UserId = user.Id,
                                 Id = customer.Id,
                                 Email = user.Email,
                                 PhoneNumber = user.PhoneNumber,
                                 Status = user.Status,
                             };

                return result.FirstOrDefault();
            }
        }

        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from customer in filter is null ? context.Customers : context.Customers.Where(filter)
                             join user in context.Users on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 UserId = user.Id,
                                 CompanyName = customer.CompanyName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Id = customer.Id,
                                 Email = user.Email,
                                 PhoneNumber = user.PhoneNumber,
                                 Status = user.Status
                             };
                return result.ToList();
            }
        }
    }
}
