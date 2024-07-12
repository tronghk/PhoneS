using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IVoucherService
    {
        //thêm, sửa, xóa, get all, ...
        Task<string> CreateAsync(Voucher voucher);
        Task <string> DeleteAsync(Voucher voucher);

        Task <string> UpdateAsync(Voucher voucher);
        Task<string> DeleteById(int id);

        IEnumerable<Voucher> GetAll();
        Voucher GetByVoucherId(int voucherID);

        Voucher GetByVoucherCode(string code);
        IEnumerable<Voucher> search(string name);
    }
}
