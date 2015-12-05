using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication.ViewModels.Book;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class BookController : Controller
    {
		IBookFetcher _bookFetcher;
		public BookController(IBookFetcher bookFetcher) {
			_bookFetcher = bookFetcher;
		}
		
		public IActionResult Index()
        {
            return View();
        }
		
		public async Task<IActionResult> FetchBook(string url) 
		{
			var bookContent = await _bookFetcher.FetchBook();
			var bookViewModel = new BookViewModel("Test", bookContent);
            return View(bookViewModel);
		}
	}
}