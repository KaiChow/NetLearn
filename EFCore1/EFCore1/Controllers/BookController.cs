

using Microsoft.AspNetCore.Mvc;

namespace EFCore1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public readonly MyDbContext _db;
        public BookController(MyDbContext myDb)
        {
            _db = myDb;
        }

        [HttpGet(Name = "GetBooks")]
        public IEnumerable<Book> Get()
        {
            Book book = new Book()
            {
                Title = "Test",
                Price = 1,
                PubTime = DateTime.Now,
            };
            yield return book;
        }
    }
}
