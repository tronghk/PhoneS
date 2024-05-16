using DataAccess;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateAsync(Product product)
        {
            try
            {
                _context.Product.AddAsync(product);
                await _context.SaveChangesAsync(true);
            }
            catch (Exception ex)
            {
                return "error_create";
            }
            return "success";
          
            
        }
        public async Task<string> DeleteAsync(Product product)
        {
            try
            {
                _context.Product.Remove(product);
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
                var product = GetByProductId(id);
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_delete";
            }
            return "success";

            
        }

        public IEnumerable<Entity.Product> GetAll()
        {
            foreach (var product in _context.Product)
            {
                yield return product;
            }
        }
        public Product GetByProductId(int productID)
        {
            return _context.Product.Where(x => x.ProductID == productID).FirstOrDefault();
        }
        public async Task<string> UpdateAsync(Product product)
        {
            try
            {
                _context.Product.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_update";
            }
            return "success";

            
        }

        public int GetCount()
        {

            var list = GetAll();
            return list.Count();
        }

        public Product GetByProductName(string name)
        {
            return _context.Product.Where(x => x.ProductName == name).FirstOrDefault();
        }

        public IEnumerable<Product> searchProduct(string name)
        {
            List<Product> list = new List<Product>();
            var products = GetAll();
            while (list.Count == 0)
            {
                foreach(Product product in products)
                {
                    string p = product.ProductName.ToLower();
                    string pnew = name.ToLower();
                    if(p.Length >=pnew.Length)
                    if (p.Substring(0,pnew.Length) == pnew)
                    {
                        list.Add(product);
                    }
                }
                if (name.Length > 1)
                    name = name.Substring(0, name.Length - 1);
                else
                    break;
            }
            Console.WriteLine(list.Count);
            return list;
            
        }
        public async Task<List<Product>> GetProducts(int pageNumber, int pageSize)
        {
            var products = _context.Product
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return await Task.FromResult(products);
        }
        public async Task<List<Product>> GetProductsByCategory(int categoryId, int pageNumber, int pageSize)
        {
            var products = _context.Product.Where(x => x.ProdCateID == categoryId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return await Task.FromResult(products);
        }
        public int GetTotalCount()
        {
            return _context.Product.Count();
        }
    }
}
