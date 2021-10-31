using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDTO> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id                             
                             select new CustomerDetailDTO
                             {
                                 FirstNam = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName                               
                             };
                return result.ToList();

            }
        }
    }
}
