using Ajax_Repository_Crud.Interface;
using Ajax_Repository_Crud.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajax_Repository_Crud.Controllers
{
    public class BooksController : Controller
    {
        private GenericInterface<BookWithAuthorViewModel> _Bookservices;
        private IBook _Bookservices2;
        public BooksController(GenericInterface<BookWithAuthorViewModel> _Bookservices, IBook _Bookservices2)
        {
           this. _Bookservices = _Bookservices;
            this._Bookservices2 = _Bookservices2;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetBooks()
        {
            var books = _Bookservices.GetData();
            return Json(books);
        }
        [HttpPost]
        public JsonResult DeleteBook(int id)
        {
            var Result = _Bookservices2.DeleteBook(id);
            if (Result)
            {
                return Json(new { message="book deleted",ok=true});
            }
            return Json(new { message = "book not deleted", ok = false });
        }
    }
}
/*CREATE TABLE Author
(Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(100),
Mobile VARCHAR(20),
Email VARCHAR(100)
)

CREATE TABLE Books
(Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(100),
Price MONEY,
Quantity INT,
Published_On VARCHAR(100),
Author_Id INT FOREIGN KEY REFERENCES Author(Id)
)

INSERT INTO Author(Name,Mobile,Email) VALUES
('Aman','83462233','aman@gail.com'),
('rahul','2339629681','rahul@gmail.com'),
('shubham','28715282','subham@gmail');


INSERT INTO Books (Title,Price,Quantity,Published_On,Author_Id) VALUES
('Angualr',1200,100,getDate(),1),
('Rectjs',1300,200,getDate(),2),
('Javascript',500,300,getDate(),2),
('Phython',1600,400,getDate(),3);
*/