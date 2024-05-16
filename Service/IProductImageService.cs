using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductImageService
    {
        Task CreateAsync(ProductImage productImage);
        Task DeleteAsync(ProductImage productImage);
        Task UpdateAsync(ProductImage productImage);
        Task DeleteById(int id);
        IEnumerable<ProductImage> GetAll();
        ProductImage GetByProductImageId(int productImage);
        IEnumerable<ProductImage> GetAllByID(int id);
    }
}
