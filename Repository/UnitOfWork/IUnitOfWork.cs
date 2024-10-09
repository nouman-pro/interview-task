using DataAccess;
using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<SYS_Logins> LoginRepo { get; }
        IRepository<SYS_Users> UserRepo { get; }




        Task<int> Save();
    }
}
