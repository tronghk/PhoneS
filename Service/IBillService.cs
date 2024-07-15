using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBillService
    {
        //thêm, sửa, xóa, lấy all, ...
        Task CreateAsync(Bill bill);
        Task DeleteAsync(Bill bill);
        Task UpdateAsync(Bill bill);
        Task DeleteById(int id);
        IEnumerable<Bill> GetAll();
        Bill GetByBillId(int billId);

        IEnumerable<Bill> search(string name);
        IEnumerable<Bill> searchAsync(int customerId);
    }
    
}
