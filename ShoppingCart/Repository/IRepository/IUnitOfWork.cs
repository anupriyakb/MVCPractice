using ShoppingCart.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }

        ICategoryRepository Category { get; }

        // ISP_Call SP_Call { get; }

        void Save();
    }
}
