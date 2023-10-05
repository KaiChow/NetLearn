using Microsoft.AspNetCore.Mvc;
using WebCoreApi1.Entitys;
using WebCoreApi1.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCoreApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public BookController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        // GET: api/<BookController>/<GetBooks>
        [HttpGet]
        public async Task<int> GetBooks()
        {
            Book book = new Book()
            {
                Title = "Test",
                Price = 1,
                PubTime = DateTime.Now,
                AuthorName = "Kevin",
            };
            _appDbContext.Books.Add(book);
            var result = await _appDbContext.SaveChangesAsync();
            return result;
        }

    }
}
