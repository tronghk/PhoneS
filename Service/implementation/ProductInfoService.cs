using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class ProductInfoService : IProductInfoService
    {
        //TODO: Add ProductInfo Database then uncommend bellow
        private ApplicationDbContext _context;
        public ProductInfoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(ProductInfo productInfo)
        {
            _context.ProductInfo.AddAsync(productInfo);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(ProductInfo productInfo)
        {
            _context.ProductInfo.Remove(productInfo);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteById(int id)
        {

            var productInfo = GetByProductInfoId(id);
            _context.ProductInfo.Remove(productInfo);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Entity.ProductInfo> GetAll()
        {
            foreach (var productInfo in _context.ProductInfo)
            {
                yield return productInfo;
            }
        }
        public ProductInfo GetByProductInfoId(int productID)
        {
            return _context.ProductInfo.Where(x => x.ProductID == productID).FirstOrDefault();
        }

        public async Task UpdateAsync(ProductInfo productInfo)
        {
            
            _context.ProductInfo.Update(productInfo);
            await _context.SaveChangesAsync();
        }

        //    var productInfo = GetByProductInfoId(id);
        //    _context.ProductInfo.Remove(productInfo);
        //    await _context.SaveChangesAsync();
        //}

        //public IEnumerable<Entity.ProductInfo> GetAll()
        //{
        //    foreach (var productInfo in _context.ProductInfo)
        //    {
        //        yield return productInfo;
        //    }
        //}
        //public ProductInfo GetByProductInfoId(int productID)
        //{
        //    return _context.ProductInfo.Where(x => x.ProductID == productID).FirstOrDefault();
        //}
        //public async Task UpdateAsync(ProductInfo productInfo)
        //{
        //    _context.ProductInfo.Update(productInfo);
        //    await _context.SaveChangesAsync();
        //}
    }
}
