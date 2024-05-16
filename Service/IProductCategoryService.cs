using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductCategoryService
    {
        //thêm, sửa, xóa, get all, ...
        Task<string> CreateAsync(ProductCategory productCategory);
        Task<string> DeleteAsync(ProductCategory productCategory);

        Task<string> UpdateAsync(ProductCategory productCategory);
        Task<string> DeleteById(int id);

        IEnumerable<ProductCategory> GetAll();
        Task<List<ProductCategory>> GetAllProduct();
        ProductCategory GetByProductCategoryId(int productCategory);
        ProductCategory GetByProductCategoryName(string name);
        IEnumerable<ProductCategory> search(string name);
    }
}
