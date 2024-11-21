using HW13.Dto;
using HW13.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Contract.IRepository
{
    public interface IRepositoryUser
    {
        public void BorrowBook(int i, int userId);
        public void ReturnBook(int i);
     
        public List<GetBookDto> ShowDateBorrowBook();
        public void AddDateBorrowBook(int id,int i);
        public List<GetBookLibraryDto> GetListOfLibraryBook();
        public List<GetBookLibraryDto> GetListOfUserBook(int id);
        public List<GetBookDto> ShowBooks();
       public List<GetUserDto> ShowUser();
    }
}
