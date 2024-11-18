using HW13.Contract.IRepository;
using HW13.DataBase;
using HW13.Dto;
using HW13.Entity;
using HW13.MyMemory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Repository
{
    public class RepositoryUser : IRepositoryUser
    {
        AppDbContext appDbContext;
        public RepositoryUser()
        {
            appDbContext = new AppDbContext();
        }
        public List<GetBookDto> ShowBooks()
        {
            return appDbContext.books.AsNoTracking().OrderByDescending(t => t.IsBorrow)
                .Select(x => new GetBookDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    IsBorrow = x.IsBorrow,
                    UserName = x.User.UserName,
                }).ToList(); 
        }

        public List<GetUserDto> ShowUser()
        {
            return appDbContext.users.AsNoTracking().OrderBy(t => t.Role)
                .Select(x => new GetUserDto()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Password = x.Password,
                    Role = x.Role,
                    NumberBorrowed = x.books.Count()

                }).ToList();

        }
        public void BorrowBook(int i, int userId)
        {
            var book = appDbContext.books.Where(x => x.Id == i).FirstOrDefault();
            book.IsBorrow = true;
            book.UserId = userId;
            appDbContext.SaveChanges();

        }

        public List<GetBookLibraryDto> GetListOfLibraryBook()
        {
            
                return appDbContext.books.Where(x => x.IsBorrow == false).AsNoTracking()
                .Select(x => new GetBookLibraryDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                   Author=x.Author,
                   IsBorrow=x.IsBorrow,
                    
                }).ToList();

        }

        public List<GetBookLibraryDto> GetListOfUserBook(int id)
        {
            return appDbContext.books.Where(x => x.UserId == id && x.IsBorrow == true).AsNoTracking()
                .Select(x => new GetBookLibraryDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    IsBorrow = x.IsBorrow,
                    
                }).ToList();
        }

        public void ReturnBook(int i)
        {
            var book = appDbContext.books.Where(x => x.Id == i).FirstOrDefault();
            book.UserId = null;
            book.IsBorrow = false;
            appDbContext.SaveChanges();

        }
    }
}

