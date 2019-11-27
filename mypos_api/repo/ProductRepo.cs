using System.Collections.Generic;
using System.Linq;
using mypos_api.Database;
using mypos_api.Models;

namespace mypos_api.repo
{
    public class ProductRepo : IProductRepo
    {
        public ProductRepo(DatabaseContext context)
        {
            _context = context;
        }

        public DatabaseContext _context { get; }

        public IEnumerable<Products> GetProduct()
        {
            return _context.Products.ToList();
        }
    }
}