using EFcore_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFcore_CRUD.Repositories
{
    public class ProductRepo : IRepository<Product>
    {
        private readonly ProductDbContext _context;

        public ProductRepo(ProductDbContext context)
        {
            _context = context;
        }

        public void AddRecord(Product model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public Product DeleteRecord(Product model)
        {
            _context.Remove(model);
            _context.SaveChanges(); // Ensure changes are saved
            return model;
        }

        public IEnumerable<Product> GetAllRecords()
        {
            return _context.Products.ToList();
        }

        public Product GetSingleRecord(int id)
        {
            return _context.Products.Find(id);
        }

        public Product UpdateRecord(Product model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
