using WebApiDemo.Entities;
using WebApiDemo.Models;

namespace WebApiDemo.DataAccess
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
    {
        public List<CustomerModel> GetCustomerOrders(string customerId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //var result = from c in context.Customers
                //             join o in context.Orders
                //             on c.Id equals o.CustomerId
                //             where c.Id == customerId
                //             select new CustomerModel
                //             {
                //                 Id = c.Id,
                //                 CompanyName = c.CompanyName,
                //                 ContactName = c.ContactName,
                //                 ContactTitle = c.ContactTitle,
                //                 Address = c.Address,
                //                 City = c.City,
                //                 Region = c.Region,
                //                 PostalCode = c.PostalCode,
                //                 Country = c.Country,
                //                 Phone = c.Phone,
                //                 Fax = c.Fax
                //             };

                //join customer and order without LinqToSql
                var result = context.Customers.Where(c => c.CustomerId == customerId)
                    .Join(context.Orders, c => c.CustomerId, o => o.CustomerId, (customer, order) => new CustomerModel
                    {
                        CustomerId = customer.CustomerId,
                        CompanyName = customer.CompanyName,
                        ContactName = customer.ContactName,
                        ContactTitle = customer.ContactTitle,
                        Address = customer.Address,
                        City = customer.City,
                        Region = customer.Region,
                        PostalCode = customer.PostalCode,
                        Country = customer.Country,
                        Phone = customer.Phone,
                        Fax = customer.Fax,
                        ShipName=order.ShipName,
                        ShipAddress = order.ShipAddress,
                        ShipCity = order.ShipCity,
                        ShipRegion = order.ShipRegion,
                        ShipPostalCode = order.ShipPostalCode,
                        ShipCountry = order.ShipCountry
                        
                    }).ToList();

                return result.ToList();
            }
        }
    }
}
