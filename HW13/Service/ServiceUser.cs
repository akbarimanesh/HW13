using HW13.Contract.IRepository;
using HW13.Contract.IService;
using HW13.Dto;
using HW13.Entity;
using HW13.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Service
{
    public class ServiceUser : IServiceUser
    {
        IRepositoryUser repUser;
        IRepositoryBook repBook;
        public ServiceUser()
        {
            repUser = new RepositoryUser();
            repBook = new RepositoryBook();
        }
        public Result BorrowBook(int i, int userId)
        {
            if(repBook.IsBookExists(i))
            {
                repUser.BorrowBook(i, userId);
                return new Result(true, "Book added successfully.");
            }
            else
                return new Result(false, "book is not available..");

        }

        public List<GetBookLibraryDto> GetListOfLibraryBook()
                
        {
            
            return repUser.GetListOfLibraryBook();
        }

        public List<GetBookLibraryDto> GetListOfUserBook(int id)
        {
            return repUser.GetListOfUserBook(id);
        }

        public Result ReturnBook(int i)
        {
            if (repBook.IsBookExists(i))
            {
                repUser.ReturnBook(i);
                return new Result(true, "returned the book.");
            }
            else
                return new Result(false, "book is not available..");
        }

        public List<GetBookDto> ShowBooks()
        {
          return repUser.ShowBooks();
        }

        public List<GetUserDto> ShowUser()
        {
            return repUser.ShowUser();
        }

       
    }
}
