using Entity;

namespace Service
{
    public interface IProductService
    {
        //thêm, sửa, xóa, get all, ...
        Task<string> CreateAsync(Product product);
        Task<string> DeleteAsync(Product product);

        Task<string> UpdateAsync(Product product);
        Task<string> DeleteById(int id);

        Product GetByProductId(int product);
        Product GetByProductName(string name);
        int GetCount();
        public IEnumerable<Entity.Product> GetAll();

        IEnumerable<Product> searchProduct(string name);
        Task<List<Product>> GetProducts(int pageNumber, int pageSize);
        Task<List<Product>> GetProductsByCategory(int categoryId, int pageNumber, int pageSize);
        int GetTotalCount();
        public Product GetProductById(int product);
    }
}
