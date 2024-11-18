using HW13.Entity;
using HW13.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Contract.IRepository
{
   public interface IRepositoryAuthentication
    {
        public User Login(string userName,string password);
        public void Register(User user);
        public bool IsUserExists(string userName, string password);
    }
}
