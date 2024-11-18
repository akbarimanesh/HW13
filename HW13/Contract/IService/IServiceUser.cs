using HW13.Dto;
using HW13.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Contract.IService
{
    public interface IServiceUser
    {
        public Result BorrowBook(int i, int userId);
        public Result ReturnBook(int i);
        public List<GetBookLibraryDto> GetListOfLibraryBook();
        public List<GetBookLibraryDto> GetListOfUserBook(int id);
        public List<GetBookDto> ShowBooks();
        public List<GetUserDto> ShowUser();
    }
}
