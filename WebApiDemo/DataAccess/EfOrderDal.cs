using WebApiDemo.Entities;

namespace WebApiDemo.DataAccess
{
    public class EfOrderDal: EfEntityRepositoryBase<Order,NorthwindContext>,IOrderDal
    {
        
    }
}
