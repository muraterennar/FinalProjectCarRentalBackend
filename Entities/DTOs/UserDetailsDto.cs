using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserDetailsDto : IDto
    {
        public int UserId { get; set; }
        public int CityId { get; set; }
        public int GenderId { get; set; }
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public string CityName { get; set; }
        public string GenderName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }

    }
}
