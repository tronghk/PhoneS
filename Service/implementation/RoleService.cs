using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class RoleService : IRoleService
    {
        private ApplicationDbContext _context;

        public RoleService (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task <string> CreateAsync(Role role)
        {
            try
            {
                _context.Role.Update(role);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "error_create";
            }
            return "success";
           
        }

        public async Task <string> DeleteAsSycn(Role role)
        {
            try
            {
                _context.Role.Remove(role);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex) 
            {
                return "error_delete";
            }
            return "success";
            
        }


        public async Task DeleteById(int id)
        {

           var role = GetByRoleId(id);
            _context.Role.Remove(role);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Entity.Role> GetAll()
        {
           foreach (var role in _context.Role)
            {
                yield return role;
            }
        }

        public Role GetByBillId(int roleId)
        {
            throw new NotImplementedException();
        }

        public Role GetByRoleId(int roleId)
        {
            return _context.Role.Where(x => x.RoleId == roleId).FirstOrDefault();
        }

        public Role GetByRoleName(string name)
        {
            return _context.Role.Where(x => x.RoleName == name).FirstOrDefault();
        }

        public IEnumerable<Role> search(string name)
        {
            List<Role> result = new List<Role>();
            var list = GetAll();
            while (result.Count == 0)
            {
                foreach (Role value in list)
                {
                    string p = value.RoleName.ToString().ToLower();
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

        public async Task UpdateAsync(Role role)
        {

            _context.Role.Update(role);
            await _context.SaveChangesAsync();
        }

    }
}
