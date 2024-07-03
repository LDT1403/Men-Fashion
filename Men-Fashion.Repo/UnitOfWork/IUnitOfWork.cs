using Men_Fashion.Repo.GenericRepository;
using Men_Fashion.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Men_Fashion.Repo.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Address> address { get; set; }

        IGenericRepository<Category> category { get; set; }
        IGenericRepository<Cart> cart { get; set; }
        IGenericRepository<Order> order { get; set; }
        IGenericRepository<OrderDetail> orderdetail { get; set; }
        IGenericRepository<Product> product { get; set; }

        IGenericRepository<Payment> payment { get; set; }
        IGenericRepository<User> user { get; set; }

        void save();
    }
}
