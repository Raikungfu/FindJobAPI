using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;

namespace FindJobsApplication.Repository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly ApplicationContext _db;

        public InvoiceRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
