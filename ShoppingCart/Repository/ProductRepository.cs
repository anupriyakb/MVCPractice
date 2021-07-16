using ShoppingCart.Models;
using ShoppingCart.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Product product)
    {
        var objFromDb = _db.Products.FirstOrDefault(s => s.ProductID == product.ProductID);
        if (objFromDb != null)
        {
            objFromDb.ProductName = product.ProductName;
                objFromDb.Description = product.Description;
                objFromDb.Quantity = product.Quantity;
                objFromDb.Price = product.Price;
                _db.SaveChanges();
        }
    }
}
}
