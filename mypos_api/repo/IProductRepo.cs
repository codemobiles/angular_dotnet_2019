using System.Collections.Generic;
using System.Threading.Tasks;
using mypos_api.Models;

namespace mypos_api.repo
{
    public interface IProductRepo
    {
        IEnumerable<Products> GetProduct();
        Products GetProduct(int id);
        Task<Products> AddProduct(Products product);
        Task<Products> EditProduct(Products product, int id);
        bool DeleteProduct(int id);
    }
}