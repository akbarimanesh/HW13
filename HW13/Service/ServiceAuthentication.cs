using HW13.Contract.IRepository;
using HW13.Contract.IService;
using HW13.Entity;
using HW13.Enum;
using HW13.MyMemory;
using HW13.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Service
{
    public class ServiceAuthentication : IServiceAuthentication
    {
        IRepositoryAuthentication repositoryAuthentication;
        public ServiceAuthentication()
        {
            repositoryAuthentication = new RepositoryAuthentication();
        }
        
        public Result Login(string userName, string password)
        {
            MemoryDb.CurrentUser = repositoryAuthentication.Login(userName,password);
            if (MemoryDb.CurrentUser == null)
            {
                return new Result(false, "User or password is incorrect.");
            }
            return new Result(true, "You have successfully logged in..");
        }

        public Result Register(User user)
        {
            if (!repositoryAuthentication.IsUserExists(user.UserName, user.Password))
            {
                if (user.UserName != "" && user.Password != "")
                {
                    repositoryAuthentication.Register(user);

                    return new Result(true, "User registered successfully.");
                }
                else
                {
                    return new Result(false, "Please complete the form.");
                }

            }
            else
            {

                return new Result(false, "User already exists.");
            }

        }
    }
}
