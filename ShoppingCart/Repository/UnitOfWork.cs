
using ShoppingCart.Models;
using ShoppingCart.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Repository { 
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

       
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
           
            Product = new ProductRepository(_db);
            Category = new CategoryRepository(_db);
        }
        public IProductRepository Product { get; private set; }

        public ICategoryRepository Category { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
