using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CustomerDetailDTO : IDto
    {
        public string FirstNam { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}
