using WebApiDemo.Entities;
using WebApiDemo.Models;

namespace WebApiDemo.DataAccess
{
    public interface ICustomerDal: IEntityRepository<Customer>
    {

        //get customerORders
        List<CustomerModel> GetCustomerOrders(string customerId);
    }
}
