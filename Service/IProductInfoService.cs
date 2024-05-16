using Entity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductInfoService
    {
        Task CreateAsync(Entity.ProductInfo productInfo);
        Task DeleteAsync(Entity.ProductInfo productInfo);
        //Task CreateAsync(Entity.ProductInfo productInfo);
        //Task DeleteAsync(Entity.ProductInfo productInfo);

        Task UpdateAsync(Entity.ProductInfo productInfo);
        Task DeleteById(int id);

        //IEnumerable<Entity.ProductInfo> GetAll();
        public Entity.ProductInfo GetByProductInfoId(int productInfo);

    }
   
}
