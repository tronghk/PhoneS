using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IRoleService
    {
        //thêm, sửa, xóa, lấy all, ...
        Task<string> CreateAsync(Role role);
        Task <string> DeleteAsSycn(Role role);

        Task UpdateAsync(Role role);
        Task DeleteById(int id);

        IEnumerable<Role> GetAll();
        Role GetByRoleId(int roleId);
        Role GetByRoleName(string name);
        IEnumerable<Role> search(string name);

    }
}
