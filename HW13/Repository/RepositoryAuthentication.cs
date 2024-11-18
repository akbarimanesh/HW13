using HW13.Contract.IRepository;
using HW13.DataBase;
using HW13.Entity;
using HW13.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Repository
{
    internal class RepositoryAuthentication : IRepositoryAuthentication
    {
        private readonly AppDbContext appDbContext;
        public RepositoryAuthentication()
        {
            appDbContext = new AppDbContext();
        }
        public bool IsUserExists(string userName, string password)
        {
            return appDbContext.users.AsNoTracking().Any(x => x.UserName == userName && x.Password == password);
        }

        public User Login(string userName, string password)
        {
            return appDbContext.users.Where(x => x.UserName == userName && x.Password == password).AsNoTracking().FirstOrDefault();
        }

        public void Register(User user)
        {
            appDbContext.users.Add(user);
            appDbContext.SaveChanges();
        }
    }
}
