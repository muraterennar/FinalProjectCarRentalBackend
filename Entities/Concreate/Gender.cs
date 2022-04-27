using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class Gender : IEntity
    {
        public int Id { get; set; }
        public string GenderType { get; set; }
    }
}
