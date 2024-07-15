using Entity;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public interface ICartService
    {
        Task CreateAsync(Cart cart);
        Task DeleteAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        IEnumerable<Cart> GetAll();
        IEnumerable<Cart> GetAllByUsID(int usid);
        public Cart GetByCartID(int cartid);
        Task DeleteById(int cartid);
        Task AddToCart(int usid, int proid);

        public Task<string> AddProduct(string userId, string productId, string quantity);
        public Task<string> RemoveProduct(string userId, string productId, string quantity);
    }
}
