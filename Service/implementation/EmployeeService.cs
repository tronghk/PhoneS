using DataAccess;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateAsync(Employee employee)
        {
            try
            {
                var newemployee = new Employee
                {

                    Nationality = employee.Nationality,
                    FullName = employee.FullName,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    CoefSalary = employee.CoefSalary,
                    Salary = employee.Salary,
                    Account = employee.EmployeeID + "",
                };

                _context.Employee.Add(newemployee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_create";
            }
            return "success";
            
        }

        public async Task<string> DeleteAsync(Employee employee)
        {
            try
            {
                _context.Employee.Remove(employee);
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
                var employee = GetByEmployeeId(id);
                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_delete";
            }
            return "success";

            
        }

        public IEnumerable<Entity.Employee> GetAll()
        {
            foreach (var employee in _context.Employee)
            {
                yield return employee;
            }
        }

        public Employee GetByEmployeeId(int employeeID)
        {
            return _context.Employee.Where(x => x.EmployeeID == employeeID).FirstOrDefault();
        }

        public Employee GetByEmployeeEmail(string email)
        {
            return _context.Employee.Where(x => x.Email == email).FirstOrDefault();
        }
        public async Task<string> UpdateAsync(Employee employee)
        {
            try
            {
                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_update";
            }
            return "success";

           
        }

        public IEnumerable<Employee> search(string name)
        {
            List<Employee> result = new List<Employee>();
            var list = GetAll();
            while (result.Count == 0)
            {
                foreach (Employee value in list)
                {
                    string p = value.FullName.ToString().ToLower();
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
    }
}
