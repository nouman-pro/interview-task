using DataAccess;
using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private bool disposed = false;
        private readonly MainContext _context;


        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        public IRepository<SYS_Logins> _loginRepo;

        public IRepository<SYS_Users> _userRepo;



        public IRepository<SYS_Logins> LoginRepo
        {
            get
            {
                return _loginRepo ??
                    (_loginRepo = new Repository<SYS_Logins>(_context));
            }
        }

        public IRepository<SYS_Users> UserRepo
        {
            get
            {
                return _userRepo ??
                    (_userRepo = new Repository<SYS_Users>(_context));
            }
        }


        public async Task<int> Save()
        {
            var res = await _context.SaveChangesAsync();
            return res;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
