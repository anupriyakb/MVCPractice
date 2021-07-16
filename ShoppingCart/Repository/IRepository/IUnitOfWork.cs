using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }
        // ISP_Call SP_Call { get; }

        void Save();
    }
}
