using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationContext _db;
        public OrderRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Order order)
        {
            var objFromDb = _db.Orders.FirstOrDefault(s => s.OrderId == order.OrderId);
            if (objFromDb != null)
            {
                objFromDb.OrderStatus = order.OrderStatus;
                objFromDb.PaymentMethod = order.PaymentMethod;
                objFromDb.PaymentDate = order.PaymentDate;
                objFromDb.PaymentRef = order.PaymentRef;
                objFromDb.PaymentStatus = order.PaymentStatus;

            }
            else
            {
                throw new Exception("Order not found");
            }
        }
    }
}
