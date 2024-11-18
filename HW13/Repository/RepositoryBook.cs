using HW13.Contract.IRepository;
using HW13.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Repository
{
    public class RepositoryBook : IRepositoryBook
    {
        AppDbContext appDbContext;
        public RepositoryBook()
        {
            appDbContext = new AppDbContext();
        }
        public bool IsBookExists(int id)
        {
            return appDbContext.books.AsNoTracking().Any(x => x.Id == id);
        }
    }
}
