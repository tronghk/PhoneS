using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class ProductBillService : IProductBillService
    {
        private ApplicationDbContext _context;
        public ProductBillService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(ProductBill procductBill)
        {
            _context.ProductBill.Update(procductBill);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(ProductBill procductBill)
        {
            _context.ProductBill.Remove(procductBill);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteById(int productID, int billID)
        {
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Entity.ProductBill> GetAll()
        {
            foreach (var item in _context.ProductBill)
            {
                yield return item;
            }
        }


        public IEnumerable<ProductBill> GetByProductBillId(int billID)
        {
            return _context.ProductBill.Where(x=> x.BillID == billID);
        }

        public IEnumerable<ProductBill> GetByProductBillId(int productID, int billID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ProductBill item)
        {
            _context.ProductBill.Update(item);
            await _context.SaveChangesAsync();
        }

    }
}
