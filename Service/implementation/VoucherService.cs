using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{

    public class VoucherService : IVoucherService
    {
        private ApplicationDbContext _context;
        public VoucherService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task <string> CreateAsync(Voucher voucher)
        {
            try
            {
                _context.Voucher.Update(voucher);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_create";
            }
            return "success";
           
        }

        public async Task<string> DeleteAsync(Voucher voucher)
        {
            try
            {
                _context.Voucher.Remove(voucher);
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
                var voucher = GetByVoucherId(id);
                _context.Voucher.Remove(voucher);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_delete";
            }
            return "success";
           
        }

        public IEnumerable<Entity.Voucher> GetAll()
        {
            foreach (var voucher in _context.Voucher)
            {
                yield return voucher;
            }
        }

        public Voucher GetByVoucherCode(string code)
        {
            return _context.Voucher.Where(x => x.Code == code).FirstOrDefault();
        }

        public Voucher GetByVoucherId(int voucherID)
        {
            return _context.Voucher.Where(x => x.VoucherID == voucherID).FirstOrDefault();
        }

        public IEnumerable<Voucher> search(string name)
        {
            List<Voucher> result = new List<Voucher>();
            var list = GetAll();
                foreach (Voucher value in list)
                {
                    string p = value.VoucherID.ToString().ToLower();
                    string pnew = name.ToLower();
                    if (p.Length >= pnew.Length)
                        if (p.Substring(0, pnew.Length) == pnew)
                        {
                            result.Add(value);
                        }
                }


            return result;

        }

        public async Task<string> UpdateAsync(Voucher voucher)
        {
            try
            {
                _context.Voucher.Update(voucher);
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
