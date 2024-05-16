using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductSaleService
    {
        //thêm, sửa, xóa, get all, ...
        Task<string> CreateAsync(ProductSale productSale);
        Task<string> DeleteAsync(ProductSale productSale);

        Task<string> UpdateAsync(ProductSale productSale);
        Task<string> DeleteById(int id);

        IEnumerable<ProductSale> GetAll();
        Task<List<ProductSale>> GetAllProductSale();
        ProductSale GetByProductSaleId(int productSale);

        IEnumerable<ProductSale> search(string name);

    }
}
