using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class ProductSaleService : IProductSaleService
    {
        private ApplicationDbContext _context;
        public ProductSaleService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateAsync(ProductSale productSale)
        {
            try
            {
                _context.ProductSale.Update(productSale);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_create";
            }
            return "success";
           
        }
        public async Task<string> DeleteAsync(ProductSale productSale)
        {
            try
            {
                _context.ProductSale.Remove(productSale);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_delete";
            }
            return "success";
           
        }
        public async Task<string> DeleteById(int id)
        {
            try
            {
                var productSale = GetByProductSaleId(id);
                _context.ProductSale.Remove(productSale);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_delete";
            }
            return "success";

           
        }

        public IEnumerable<Entity.ProductSale> GetAll()
        {
            foreach (var productSale in _context.ProductSale)
            {
                yield return productSale;
            }
        }
        public async Task<List<ProductSale>> GetAllProductSale()
        {
            var procate = _context.ProductSale.ToList();
            return await Task.FromResult(procate);
        }
        public ProductSale GetByProductSaleId(int ProductSaleID)
        {
            return _context.ProductSale.Where(x => x.ProdSaleID == ProductSaleID).FirstOrDefault();
        }

        public IEnumerable<ProductSale> search(string name)
        {
            List<ProductSale> result = new List<ProductSale>();
            var list = GetAll();
            foreach (ProductSale value in list)
            {
                string p = value.ProdSaleID.ToString().ToLower();
                string pnew = name.ToLower();
                if (p.Length >= pnew.Length)
                    if (p.Substring(0, pnew.Length) == pnew)
                    {
                        result.Add(value);
                    }
            }


            return result;

        }

        public async Task<string> UpdateAsync(ProductSale ProductSale)
        {
            try
            {
                _context.ProductSale.Update(ProductSale);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_update";
            }
            return "success";
           
        }
    }
}
