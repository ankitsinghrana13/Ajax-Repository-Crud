using Ajax_Repository_Crud.Interface;
using Ajax_Repository_Crud.Models;
using Ajax_Repository_Crud.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajax_Repository_Crud.Repository
{
    public class BookService:GenericInterface<BookWithAuthorViewModel>,IBook
    {
        private ApplicationDbContext dbContext;
        public BookService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool DeleteBook(int id)
        {
            var book = dbContext.Books.SingleOrDefault(e => e.Id == id);
            if (book != null)
            {
                dbContext.Books.Remove(book);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<BookWithAuthorViewModel> GetData()
        {
            var books = (from book in dbContext.Books
                         join
                         Author in dbContext.Author on book.Author_Id equals Author.Id
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
