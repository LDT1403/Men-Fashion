using Men_Fashion.Repo.GenericRepository;
using Men_Fashion.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Men_Fashion.Repo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MenShopContext _context;
        private IGenericRepository<Category> categoryRepository;
        private IGenericRepository<Cart> cartRepository;
        private IGenericRepository<Order> orderRepository;
        private IGenericRepository<OrderDetail> orderDetailRepository;
        private IGenericRepository<Product> productRepository;
        private IGenericRepository<Address> addressRepository;
        private IGenericRepository<Payment> paymentRepository;
        private IGenericRepository<User> userRepository;

        public UnitOfWork(MenShopContext context)
        {
            _context = context;
        }
        public IGenericRepository<Category> category
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new GenericRepository<Category>(_context);
                }
                return categoryRepository;
            }
            set => throw new NotImplementedException();
        }
        public IGenericRepository<Cart> cart
        {
            get
            {
                if (cartRepository == null)
                {
                    cartRepository = new GenericRepository<Cart>(_context);
                }
                return cartRepository;
            }
            set => throw new NotImplementedException();
        }
        public IGenericRepository<Order> order
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new GenericRepository<Order>(_context);
                }
                return orderRepository;
            }
            set => throw new NotImplementedException();
        }
        public IGenericRepository<OrderDetail> orderdetail
        {
            get
            {
                if (orderDetailRepository == null)
                {
                    orderDetailRepository = new GenericRepository<OrderDetail>(_context);
                }
                return orderDetailRepository;
            }
            set => throw new NotImplementedException();
        }
        public IGenericRepository<Product> product
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new GenericRepository<Product>(_context);
                }
                return productRepository;
            }
            set => throw new NotImplementedException();
        }

        public IGenericRepository<Address> address
        {
            get
            {
                if (addressRepository == null)
                {
                    addressRepository = new GenericRepository<Address>(_context);
                }
                return addressRepository;
            }
            set => throw new NotImplementedException();
        }
        public IGenericRepository<Payment> payment
        {
            get
            {
                if (paymentRepository == null)
                {
                    paymentRepository = new GenericRepository<Payment>(_context);
                }
                return paymentRepository;
            }
            set => throw new NotImplementedException();
        }
        public IGenericRepository<User> user
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new GenericRepository<User>(_context);
                }
                return userRepository;
            }
            set => throw new NotImplementedException();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
