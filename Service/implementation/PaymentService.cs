using DataAccess;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class PaymentService : IPaymentService
    {
        private ApplicationDbContext _context;
        private ApplicationDbContext _newcontext;
        public PaymentService(ApplicationDbContext context, ApplicationDbContext newcontext)
        {
            _context = context;
            _newcontext = newcontext;
        }
        public async Task CreateAsync(Bill bill, int length, int[] IDs)
        {
            await _context.Bill.AddAsync(bill);
            await _context.SaveChangesAsync();
            var billid = bill.BillID;
               for(int i = 0; i < length; i++)
            {
                var productBill = new ProductBill();
                productBill.ProductID = IDs[i];
                productBill.BillID = billid;
                productBill.Quantity = 1;
                await AddProductBill(productBill);
            }
            
        }

        public async Task AddProductBill(ProductBill pbill)
        {
            try
            {
                await _newcontext.ProductBill.AddAsync(pbill);
                await _newcontext.SaveChangesAsync();
                Console.WriteLine("thành công ");
            } catch(Exception ex)
            {
                Console.WriteLine("Thất bại");
            }

            
        }

        public async Task ClearCart(int userid)
        {
            var rowsToDelete = _context.Cart.Where(c => c.UserID == userid);
            _context.Cart.RemoveRange(rowsToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
