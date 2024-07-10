using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class CustomerService : ICustomerService
    {
        private ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Customer customer)
        {
            _context.Customer.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<string> DeleteById(int id)
        {
            try
            {
                var customer = GetByCustomerId(id);
                _context.Customer.Remove(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_update";
            }
            return "success";
           
        }

        public IEnumerable<Entity.Customer> GetAll()
        {
            foreach (var customer in _context.Customer)
            {
                yield return customer;
            }
        }

        public Customer GetByCustomerId(int customerID)
        {
            return _context.Customer.Where(x => x.CustomerID == customerID).FirstOrDefault();
        }
        public Customer GetByCustomerUserId(string userId)
        {
            return _context.Customer.Where(x => x.Account == userId).FirstOrDefault()!;
        }


        public IEnumerable<Customer> search(string name)
        {
            List<Customer> result = new List<Customer>();
            var list = GetAll();
            while (result.Count == 0)
            {
                foreach (Customer value in list)
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

        public async Task<string> UpdateAsync(Customer customer)
        {
            try
            {
                _context.Customer.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_update";
            }
            return "success";
        }
    }
}
