using Microsoft.AspNetCore.Mvc;
using WebCoreApi1.Entitys;
using WebCoreApi1.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCoreApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ArticleController(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<Article> SaveArticle()
        {
            Article article = new Article();
            article.Title = "牛逼的文章";
            article.Content = "这是一篇牛逼的文章，不得不看啊，各位老铁";
            Comment comment1 = new Comment { Message = "牛逼", TheArticle = article };
            Comment comment2 = new Comment { Message = "牛逼,是吹牛逼吧！！！SB", TheArticle = article };
            article.Comments.Add(comment1);
            article.Comments.Add(comment2);

            _appDbContext.Articles.Add(article);
            await _appDbContext.SaveChangesAsync();
            return article;
        }
        // GET: api/<ArticleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArticleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
