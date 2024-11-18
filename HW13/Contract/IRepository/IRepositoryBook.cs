using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Contract.IRepository
{
    public  interface IRepositoryBook
    {
        public bool IsBookExists(int id);
    }
}
