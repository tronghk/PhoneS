using DataAccess;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class BillService : IBillService
    {
        private ApplicationDbContext _context;

        public BillService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task CreateAsync(Bill bill)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Bill bill)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity.Bill> GetAll()
        {
            foreach (var bill in _context.Bill)
            {
                yield return bill;
            }
        }

        public Bill GetByBillId(int billId)
        {
            return _context.Bill.Where(x => x.BillID == billId).FirstOrDefault();
        }

        public IEnumerable<Bill> search(string name)
        {
            List<Bill> result = new List<Bill>();
            var list = GetAll();
            foreach (Bill value in list)
            {
                string p = value.BillID.ToString().ToLower();
                string pnew = name.ToLower();
                if (p.Length >= pnew.Length)
                    if (p.Substring(0, pnew.Length) == pnew)
                    {
                        result.Add(value);
                    }
            }
            return result;
        }

        public Task UpdateAsync(Bill bill)
        {
            throw new NotImplementedException();
        }
    }
}
