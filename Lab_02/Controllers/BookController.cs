using Lab_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_02.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS Responsive web Design cookbook - Author Name book 2");
            books.Add("Professional ASP.NET MVC5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }
        //Get Book/EditBook/Id
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1,"HTML5 & CSS3 The complete Manual", "Author Name Book 1","/Content/Images/meok_logo.PNG"));
            books.Add(new Book(2,"HTML5 & CSS Responsive web Design cookbook","Author Name book 2", "/Content/Images/meok_logo.PNG"));
            books.Add(new Book(3,"Professional ASP.NET MVC5","Author Name Book 2", "/Content/Images/meok_logo.PNG"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/meok_logo.PNG"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name book 2", "/Content/Images/meok_logo.PNG"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/Images/meok_logo.PNG"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if(b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        
        
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost,ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "id, Title, Author, ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/meok_logo.PNG"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name book 2", "/Content/Images/meok_logo.PNG"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/Images/meok_logo.PNG"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch
            {

            }
            return View("ListBookModel", books);
        }
    }
}