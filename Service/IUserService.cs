using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        //thêm, sửa, xóa, get all, ...
        Task<bool> CreateAsync(User user);
        Task<string> CreateAsyncEmployee(User user);
        Task DeleteAsync(User user);

        Task <string> UpdateAsync(User user);
        Task<string> DeleteById(int id);

        IEnumerable<User> GetAll();
        User GetByUserAccount(string Account, string Password);
        Task<bool> CreateUserAccount(User user, Customer customer);

        User GetByUserId(int idUser);
        public User GetByUserAccount(string user);
        IEnumerable<User> search(string name);

        public Task<string> ForgotPassword(string email);

        public Task<User> ForgotPassword(string email, string code );

        public Task<string> ChangePassword(string email, string code, string password);
    }
}
