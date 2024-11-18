using HW13.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.MyMemory
{
    public static class MemoryDb
    {
        public static User? CurrentUser { get; set; }
        public static void CheckUserLogin()
        {
            if(CurrentUser == null)
            {
                throw new Exception("You do not have access to this operation, please log in.");
            }
        }
    }
}
