using System.Collections.Generic;
using mypos_api.Models;

namespace mypos_api.repo
{
    public interface IProductRepo
    {
        IEnumerable<Products> GetProduct();
    }
}