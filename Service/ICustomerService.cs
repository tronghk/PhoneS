using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICustomerService
    {
        //thêm, sửa, xóa, get all, ...
        Task CreateAsync(Customer customer);
        Task DeleteAsync(Customer customer);

        Task<string> UpdateAsync(Customer customer);
        Customer GetByCustomerUserId(string userId);
        Task<string> DeleteById(int id);

        IEnumerable<Customer> GetAll();
        Customer GetByCustomerId(int CustomerID);
        IEnumerable<Customer> search(string name);
    }
}
