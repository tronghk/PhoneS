using DataAccess;
using Entity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;
        readonly private IEmailSender _emailSender;
        readonly private ICustomerService _customer;
        public UserService(ApplicationDbContext context, IEmailSender emailSender, ICustomerService customer)
        {
            _context = context;
            _emailSender = emailSender;
            _customer = customer;
        }
        public async Task<bool> CreateAsync(User user)
        {
            var checkUser = _context.TaiKhoan.Where(x => x.Account == user.Account).FirstOrDefault();
            if (checkUser != null)
            {
                return false;
            }
            var newUser = new User();
            newUser.Account = user.Account;
            newUser.Password = user.Password;
            newUser.UserID = user.UserID;
            newUser.RoleId = 2;
            _context.TaiKhoan.Add(newUser);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task DeleteAsync(User user)
        {
            _context.TaiKhoan.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<string> DeleteById(int id)
        {
            try
            {
                var user = GetByUserId(id);
                _context.TaiKhoan.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_update";
            }
            return "success";
           
        }

        //public IEnumerable<Entity.User> GetAll()
        //{
        //    foreach (var user in _context.TaiKhoan)
        //    {
        //        yield return user;
        //    }
        //}

        public User GetByUserAccount(string Account, string Password)
        {
            var user = _context.TaiKhoan.Where(x => x.Account == Account).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public async Task<bool> CreateUserAccount(User user, Customer customer)
        {
            var check = _context.TaiKhoan.Where(x => x.Account == user.Account).FirstOrDefault();
            if (check != null)
            {
                return false;
            }
            var newuser = new User()
            {
                ForgotPassowrd = "",
                Account = user.Account,
                Password = user.Password,
                RoleId = 2
            };

            _context.TaiKhoan.Add(newuser);

            await _context.SaveChangesAsync();  
            var userId = newuser.UserID;    

            var newcustomer = new Customer()
            {
                FullName = customer.FullName,
                Nationality = customer.Nationality,
                Phone = customer.Phone,
                Address = customer.Address,
                Email = user.Account,
                Account = userId.ToString()
            };
            _context.Customer.Add(newcustomer);
            return await _context.SaveChangesAsync() > 0;


        }

        public async Task<string> CreateAsyncEmployee(User user)
        {
            try
            {
                var newuser = new User()
                {
                    Account = user.Account,
                    Password = user.Password,
                    RoleId = 3
                };
                _context.TaiKhoan.AddAsync(newuser);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_create";
            }
            return "success";
            

        }

        public IEnumerable<User> GetAll()
        {
            foreach (var value in _context.TaiKhoan)
            {
                yield return value;
            }
        }
        public User GetByUserId(int idUser)
        {
            return _context.TaiKhoan.Where(x => x.UserID == idUser).FirstOrDefault()!;
        }

        public User GetByUserAccount(string user)
        {
            return _context.TaiKhoan.Where(x => x.Account == user).FirstOrDefault()!;
        }

        public async Task <string> UpdateAsync(User user)
        {
            try
            {
                _context.TaiKhoan.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_update";
            }
            return "success";
            
        }

        public IEnumerable<User> search(string name)
        {
            List<User> result = new List<User>();
            var list = GetAll();
            while (result.Count == 0)
            {
                foreach (User value in list)
                {
                    string p = value.Account.ToString().ToLower();
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

        public async Task<string> ForgotPassword(string email)
        {

            if (!checkUser(email))
            {
                return "error";
            }
            string code = RandomCode();

            User user = GetByUserAccount(email);
            user.ForgotPassowrd = code;
             await UpdateAsync(user);
            string name = _customer.GetByCustomerUserId(user.UserID + "").FullName!;
            string subject = "Quên mật khẩu - Mộng Mơ";
            string content = " Chào " + name + ",\n"
                + "Cảm ơn bạn đã sử dụng phần mềm của chúng tôi, mã code quên mật khẩu của bạn là "+ code
                + "\n Cảm ơn bạn đã dùng website của chúng tôi";

            await _emailSender.SendEmailAsync(email, subject, content);
            return "Vui lòng kiểm tra mail";
        }
        public string RandomCode()
        {
            string s = "";
            Random random = new Random();
            int i = 6;
            while (i > 0)
            {
                s = s + random.Next(9);
                i--;
            }
            return s;
        }
        public bool checkUser(string email)
        {

            foreach (var value in _context.TaiKhoan)
            {
                if (value.Account == email)
                    return true;
            }
            return false;
        }

        public async Task<User> ForgotPassword(string email, string code)
        {
            User user = GetByUserAccount(email);

            if (user.ForgotPassowrd == null || user.ForgotPassowrd == "")
                return null;
            if (user.Account == email && code == user.ForgotPassowrd)
                return user;
            return null;
        }



        public async Task<string> ChangePassword(string email, string code, string password)
        {
            User us = GetByUserAccount(email);

            if(us.Account == email && us.ForgotPassowrd == code)
            {
                us.ForgotPassowrd = "";
                us.Password = password;

                await UpdateAsync(us);

                return "success";
            }
            return "error";
            

        }
    }
}
