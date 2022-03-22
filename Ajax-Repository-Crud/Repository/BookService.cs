using Ajax_Repository_Crud.Interface;
using Ajax_Repository_Crud.Models;
using Ajax_Repository_Crud.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajax_Repository_Crud.Repository
{
    public class BookService:GenericInterface<BookWithAuthorViewModel>
    {
        private ApplicationDbContext dbContext;
        public BookService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<BookWithAuthorViewModel> GetData()
        {
            var books = (from book in dbContext.Books
                         join
                         Author in dbContext.Author on book.Authar_Id equals Author.Id
                         select new BookWithAuthorViewModel()
                         {
                             id=book.Id,
                             Title=book.Title,
                             Price=book.Price,
                             Quantity=book.Quantity,
                             Published_On=book.Published_On,
                             AuthorName=Author.Name,
                             AuthorEmail=Author.Email,
                             AuthorMobile=Author.Mobile


                         }).ToList();
            return books;
        }
    }
}
