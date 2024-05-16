using DataAccess;
using Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private ApplicationDbContext _context;
        public ProductCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateAsync(ProductCategory productCategory)
        {
            try
            {
                _context.ProductCategory.Update(productCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_create";
            }
            return "success";
            
        }
        public async Task<string> DeleteAsync(ProductCategory productCategory)
        {
            try
            {
                _context.ProductCategory.Remove(productCategory);
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
                var productCategory = GetByProductCategoryId(id);
                _context.ProductCategory.Remove(productCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_delete";
            }
            return "success";
           
        }
        public IEnumerable<ProductCategory> GetAll()
        {
            foreach (var procate in _context.ProductCategory)
            {
                yield return procate;
            }
        }
        public async Task<List<ProductCategory>> GetAllProduct()
        {
            var procate = _context.ProductCategory.ToList();
            return await Task.FromResult(procate);
        }
        public ProductCategory GetByProductCategoryId(int productCategoryID)
        {
            return _context.ProductCategory.Where(x => x.ProdCateID == productCategoryID).FirstOrDefault();
        }

        public ProductCategory GetByProductCategoryName(string name)
        {
            return _context.ProductCategory.Where(x => x.ProdCateName == name).FirstOrDefault();
        }

        public IEnumerable<ProductCategory> search(string name)
        {
            List<ProductCategory> result = new List<ProductCategory>();
            var list = GetAll();
            while (result.Count == 0)
            {
                foreach (ProductCategory value in list)
                {
                    string p = value.ProdCateName.ToString().ToLower();
                    string pnew = name.ToLower();
                    if (p.Length >= pnew.Length)
                        if (p.Substring(0, pnew.Length) == pnew)
                        {
                            result.Add(value);
                        }
                }
                if (name.Length > 1)
                    name = name.Substring(0, name.Length - 1);
                else
                    break;
            }

            return result;

        }

        public async Task<string> UpdateAsync(ProductCategory productCategory)
        {
            try
            {
                _context.ProductCategory.Update(productCategory);
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
