using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concreate
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameOfTheCard { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
    }
}
