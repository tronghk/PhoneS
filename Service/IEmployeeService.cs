using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IEmployeeService
    {
        //thêm, sửa, xóa, get all, ...
        Task<string> CreateAsync(Employee employee);
        Task<string> DeleteAsync(Employee employee);

        Task<string> UpdateAsync(Employee employee);
        Task<string> DeleteById(int id);

        IEnumerable<Employee> GetAll();
        Employee GetByEmployeeId(int employeeID);
        public Employee GetByEmployeeEmail(string email);
        IEnumerable<Employee> search(string name);
    }
}
