using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class ProductImageService : IProductImageService
    {
        private ApplicationDbContext _context;
        public ProductImageService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(ProductImage productImage)
        {
            _context.ProductImage.Update(productImage);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(ProductImage productImage)
        {
            _context.ProductImage.Remove(productImage);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteById(int id)
        {

            var productImage = GetByProductImageId(id);
            _context.ProductImage.Remove(productImage);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ProductImage> GetAll()
        {
            foreach (var productImage in _context.ProductImage)
            {
                yield return productImage;
            }
        }
        public ProductImage GetByProductImageId(int productImageID)
        {
            return _context.ProductImage.Where(x => x.ProductID == productImageID).FirstOrDefault();
        }
        public async Task UpdateAsync(ProductImage productImage)
        {
            _context.ProductImage.Update(productImage);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ProductImage> GetAllByID(int id)
        {
            return _context.ProductImage.Where(pi => pi.ProductID == id).AsEnumerable();
        }
    }
}
