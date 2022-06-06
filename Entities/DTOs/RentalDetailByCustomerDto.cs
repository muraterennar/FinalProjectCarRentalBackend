using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailByCustomerDto : IDto
    {
        public int CutomerId { get; set; }
        public int UserId { get; set; }
        public int BrandId { get; set; }
        public int CarId { get; set; }
        public int ColorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
